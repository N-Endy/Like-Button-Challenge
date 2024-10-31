using LikeButtonProject.Entities.Models;

namespace LikeButtonProject.Entities.Dtos;
public record ArticleLikeDto
(
    int Id,
    int ArticleId,
    int UserId,
    DateTime LikedAt
);