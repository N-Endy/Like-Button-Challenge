namespace LikeButtonProject.Entities.Dtos;
public record ArticleForCreationDto
(
    string? Title,
    string? Content,
    DateTime CreationDate
);