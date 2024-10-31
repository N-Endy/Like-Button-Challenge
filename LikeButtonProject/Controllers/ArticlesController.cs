using System.Text.Json;
using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LikeButtonProject.Controllers;
[Route("api/articles")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IDistributedCache _cache;

    public ArticlesController(IServiceManager service, IDistributedCache cache)
    {
        _service = service;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        var cacheKey = "articles_all";
        var cachedArticles = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedArticles))
            return Ok(JsonSerializer.Deserialize<IEnumerable<ArticleDto>>(cachedArticles));
        
        var articles = await _service.ArticleService.GetAllArticlesAsync(trackChanges: false);

        await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(articles), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        });
        
        return Ok(articles);
    }

    [HttpGet("{id:int}", Name = "ArticleById")]
    public async Task<IActionResult> GetArticle(int id)
    {
        var article = await _service.ArticleService.GetArticleAsync(id, trackChanges: false);

        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] ArticleForCreationDto article)
    {
        if (article == null)
            return BadRequest("Article is required and can't be null.");

        var createdArticle = await _service.ArticleService.AddArticleAsync(article);

        return CreatedAtRoute("ArticleById", new { id = createdArticle.Id }, createdArticle);
    }
}