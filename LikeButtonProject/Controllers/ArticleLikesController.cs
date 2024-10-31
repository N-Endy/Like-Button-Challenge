using System.Text.Json;
using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LikeButtonProject.Controllers;
[Route("api/articles/{articleId}/likes")]
[ApiController]
public class ArticleLikesController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IDistributedCache _cache;

    public ArticleLikesController(IServiceManager service, IDistributedCache cache)
    {
        _service = service;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetLikes(int articleId)
    {
        string cacheKey = $"article_likes_{articleId}";
        var cachedLikes = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedLikes))
            return Ok(JsonSerializer.Deserialize<object>(cachedLikes));
        
        var articleLikes = await _service.ArticleLikeService.GetArticleLikesAsync(articleId, trackChanges: false);
        var articleLikesCount = articleLikes.Count();
        var result = new { articleLikesCount };

        await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddLike(int articleId, [FromBody] ArticleLikeForCreation articleLikeForCreation)
    {
        if (articleLikeForCreation is null)
            return BadRequest("Article like is required and can't be null.");

        var createdArticleLike = await _service.ArticleLikeService.AddArticleLikeAsync(articleId, articleLikeForCreation, trackChanges: false);

        // Invalidate the cache when a new like is added
        string cacheKey = $"article_likes_{articleId}";
        await _cache.RemoveAsync(cacheKey);

        return Created("", createdArticleLike);
    }
}