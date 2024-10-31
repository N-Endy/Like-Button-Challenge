using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Dtos;
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
        var article = _repository.Article.GetArticle(id, trackChanges);
        if (article == null)
        {
            throw new Exception($"Article with id: {id} doesn't exist in the database.");
        }
        return new ArticleDto(article.Id, article.Title, article.Content, article.CreationDate);
    }
}