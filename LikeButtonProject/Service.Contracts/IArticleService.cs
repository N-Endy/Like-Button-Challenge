using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Service.Contracts;
public interface IArticleService
{
    IEnumerable<Article> GetAllArticles(bool trackChanges);
}