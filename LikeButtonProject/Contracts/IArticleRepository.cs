using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Contracts;
public interface IArticleRepository
{
    IEnumerable<Article> GetAllArticles(bool trackChanges);
}