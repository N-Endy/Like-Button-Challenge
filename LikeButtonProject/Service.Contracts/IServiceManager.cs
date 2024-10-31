namespace LikeButtonProject.Service.Contracts;
public interface IServiceManager
{
    IArticleService ArticleService { get; }
    IArticleLikeService ArticleLikeService { get; }
}