using LikeButtonProject.Entities.Dtos;

namespace LikeButtonProject.Service.Contracts;
public interface IArticleService
{
    Task<IEnumerable<ArticleDto>> GetAllArticlesAsync(bool trackChanges);
    Task<ArticleDto> GetArticleAsync(int id, bool trackChanges);
    Task<ArticleDto> AddArticleAsync(ArticleForCreationDto article);
}