using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LikeButtonProject.Repository;
public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RepositoryContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Article>> GetAllArticlesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(a => a.Title)
            .ToListAsync();

    public async Task<Article?> GetArticleAsync(int id, bool trackChanges) =>
        await FindByCondition(a => a.Id == id, trackChanges)
        .SingleOrDefaultAsync();

    public void AddArticle(Article article) => Add(article);
}