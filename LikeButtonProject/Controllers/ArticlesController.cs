using LikeButtonProject.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LikeButtonProject.Controllers;
[Route("api/articles")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IServiceManager _service;

    public ArticlesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetArticles()
    {
        try
        {
            var articles = _service.ArticleService.GetAllArticles(trackChanges: false);
            return Ok(articles);
        }
        catch
        {
            return StatusCode(500, "Internal server error. Unable to retrieve articles.");
        }
    }
}