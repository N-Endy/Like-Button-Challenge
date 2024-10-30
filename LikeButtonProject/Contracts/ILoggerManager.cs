namespace LikeButtonProject.Contracts;
public interface ILoggerManager
{
    void LogInfo(string message);
    void LogError(string message);
    void LogWarning(string message);
    void LogDebug(string message);
}