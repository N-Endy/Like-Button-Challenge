using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Dtos;
using LikeButtonProject.Entities.Exceptions;
using LikeButtonProject.Entities.Models;
using LikeButtonProject.Service.Contracts;

namespace LikeButtonProject.Service;
internal sealed class ArticleService : IArticleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ArticleService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<ArticleDto>> GetAllArticlesAsync(bool trackChanges)
    {
        var articles = await _repository.Article.GetAllArticlesAsync(trackChanges);

        return articles.Select(a => new ArticleDto(a.Id, a.Title, a.Content, a.CreationDate)).ToList();
    }

    public async Task<ArticleDto> GetArticleAsync(int id, bool trackChanges)
    {
        var article = await _repository.Article.GetArticleAsync(id, trackChanges) ?? throw new ArticleNotFoundException(id);
        
        return new ArticleDto(article.Id, article.Title, article.Content, article.CreationDate);
    }

    public async Task<ArticleDto> AddArticleAsync(ArticleForCreationDto article)
    {
        var newArticle = new Article
        {
            Title = article.Title,
            Content = article.Content,
            CreationDate = DateTime.UtcNow
        };

        _repository.Article.AddArticle(newArticle);
        await _repository.SaveAsync();

        return new ArticleDto(newArticle.Id, newArticle.Title, newArticle.Content, newArticle.CreationDate);
    }
}