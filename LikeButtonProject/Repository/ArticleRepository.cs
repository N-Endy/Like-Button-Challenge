using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Repository;
public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RepositoryContext context) : base(context)
    {
        
    }

    public IEnumerable<Article> GetAllArticles(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(a => a.Title)
            .ToList();

    public Article? GetArticle(int id, bool trackChanges) =>
        FindByCondition(a => a.Id == id, trackChanges)
        .SingleOrDefault();

    public void AddArticle(Article article) => Add(article);
}