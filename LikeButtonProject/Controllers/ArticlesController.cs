using LikeButtonProject.Entities.Dtos;
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
    public async Task<IActionResult> GetArticles()
    {
        var articles = await _service.ArticleService.GetAllArticlesAsync(trackChanges: false);
        
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