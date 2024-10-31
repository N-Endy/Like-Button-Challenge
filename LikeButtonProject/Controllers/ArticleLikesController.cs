using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LikeButtonProject.Controllers;
[Route("api/articles/{articleId}/likes")]
[ApiController]
public class ArticleLikesController : ControllerBase
{
    private readonly IServiceManager _service;

    public ArticleLikesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetLikes(int articleId)
    {
        var articleLikes = await _service.ArticleLikeService.GetArticleLikesAsync(articleId, trackChanges: false);

        var articleLikesCount = articleLikes.Count();

        return Ok(new { articleLikesCount });
    }

    [HttpPost]
    public async Task<IActionResult> AddLike(int articleId, [FromBody] ArticleLikeForCreation articleLikeForCreation)
    {
        if (articleLikeForCreation is null)
            return BadRequest("Article like is required and can't be null.");

        var createdArticleLike = await _service.ArticleLikeService.AddArticleLikeAsync(articleId, articleLikeForCreation, trackChanges: false);

        return Created("", createdArticleLike);
    }
}