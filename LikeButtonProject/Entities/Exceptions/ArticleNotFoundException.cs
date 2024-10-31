namespace LikeButtonProject.Entities.Exceptions;
public class ArticleNotFoundException : NotFoundException
{
    public ArticleNotFoundException(int id) : base($"The article with id: {id} does not exist in the database.")
    {
        
    }
}