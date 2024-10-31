namespace LikeButtonProject.Entities.Exceptions;
public class DuplicateLikeException : ConflictException
{
    public DuplicateLikeException(int userId) : base($"This article has already been liked by user with id: {userId}.)")
    {
        
    }
}