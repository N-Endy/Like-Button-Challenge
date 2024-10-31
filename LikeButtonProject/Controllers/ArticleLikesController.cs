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
    public IActionResult GetLikes(int articleId)
    {
        var articleLikes = _service.ArticleLikeService.GetArticleLikes(articleId, trackChanges: false);

        var articleLikesCount = articleLikes.Count();

        return Ok(new { articleLikesCount });
    }
}