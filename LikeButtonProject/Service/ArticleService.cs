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

    public IEnumerable<ArticleDto> GetAllArticles(bool trackChanges)
    {
        var articles = _repository.Article.GetAllArticles(trackChanges);

        return articles.Select(a => new ArticleDto(a.Id, a.Title, a.Content, a.CreationDate)).ToList();
    }

    public ArticleDto GetArticle(int id, bool trackChanges)
    {
        var article = _repository.Article.GetArticle(id, trackChanges) ?? throw new ArticleNotFoundException(id);
        
        return new ArticleDto(article.Id, article.Title, article.Content, article.CreationDate);
    }

    public ArticleDto AddArticle(ArticleForCreationDto article)
    {
        var newArticle = new Article
        {
            Title = article.Title,
            Content = article.Content,
            CreationDate = DateTime.UtcNow
        };

        _repository.Article.AddArticle(newArticle);
        _repository.Save();

        return new ArticleDto(newArticle.Id, newArticle.Title, newArticle.Content, newArticle.CreationDate);
    }
}