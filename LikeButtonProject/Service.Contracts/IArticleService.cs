using LikeButtonProject.Entities.Dtos;

namespace LikeButtonProject.Service.Contracts;
public interface IArticleService
{
    IEnumerable<ArticleDto> GetAllArticles(bool trackChanges);
}