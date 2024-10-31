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
        var articles = _service.ArticleService.GetAllArticles(trackChanges: false);
        
        return Ok(articles);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetArticle(int id)
    {
        var article = _service.ArticleService.GetArticle(id, trackChanges: false);

        return Ok(article);
    }
}