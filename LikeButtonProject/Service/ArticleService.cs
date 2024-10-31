using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Dtos;
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
        try
        {
            var articles = _repository.Article.GetAllArticles(trackChanges);
            
            return articles.Select(a => new ArticleDto(a.Id, a.Title, a.Content, a.CreationDate)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllArticles)} service method. {ex}");
            throw;
        }
    }
}