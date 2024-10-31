using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Contracts;
public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges);
    Task<Article?> GetArticleAsync(int id, bool trackChanges);
    void AddArticle(Article article);
}