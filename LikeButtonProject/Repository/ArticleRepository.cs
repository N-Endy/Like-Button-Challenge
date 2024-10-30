using LikeButtonProject.Contracts;
using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Repository;
public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RepositoryContext context) : base(context)
    {
        
    }
}