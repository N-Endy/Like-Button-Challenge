namespace LikeButtonProject.Entities.Dtos;
public record ArticleDto
(
    int Id,
    string? Title,
    string? Content,
    DateTime CreationDate
);