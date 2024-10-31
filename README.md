# Like Button Challenge - ASP.NET Core Project

## Project Overview
A high-performance Like Button system built with ASP.NET Core, implementing distributed caching with Redis, rate limiting, and clean architecture patterns. The system handles article management and like functionality with robust protection against abuse.

## Architecture
The project follows clean architecture principles with distinct layers:

### Controllers
* ArticlesController: Manages article operations with Redis caching
* ArticleLikesController: Handles like functionality with abuse protection
### Services
* ArticleService: Business logic for article management
* IArticleService: Contract defining article operations
* IServiceManager: Centralized service management
### Repository Layer
* RepositoryManager: Manages data access operations
* ArticleRepository: Handles article data persistence
* IRepositoryManager: Defines repository contracts

## Key Features

### Rate Limiting
```
"IpRateLimiting": {
    "EnableEndpointRateLimiting": true,
    "GeneralRules": [
      {
        "Endpoint": "*",
        "Period": "1m",
        "Limit": 5
      }
    ]
}
```
### Distributed Caching
Redis implementation for high-performance caching:
```
"Redis": {
    "Configuration": "localhost:6379",
    "InstanceName": "LikeButton_"
}
```
### CORS Configuration
```
services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .WithMethods("POST", "GET")
        .AllowAnyHeader());
});
```

## API Endpoints
### Articles
* GET `/api/articles`: Retrieve all articles
* GET `/api/articles/{id}`: Get specific article
* POST `/api/articles`: Create new article
### Likes
* GET `/api/articles/{articleId}/likes`: Get like count
* POST `/api/articles/{articleId}/likes`: Add like

## Database Configuration
SQL Server connection with Entity Framework Core:
```
"ConnectionStrings": {
    "sqlConnection": "Server=localhost,1433;Database=LikeButtonServer;..."
}
```

## Setup Instructions
1. Clone the Repository
```
git clone [repository-url]
cd LikeButtonProject
```
2. Install Dependencies:
`dotnet restore`
3. Database Setup:
`dotnet ef database update`
4. Redis Setup:
* Install Redis server
* Configure connection in appsettings.json
5. Run Application:
`dotnet run`

## Dependencies
* ASP.NET Core 6.0
* Entity Framework Core
* StackExchange.Redis
* AspNetCoreRateLimit
* Microsoft.Extensions.Caching.StackExchangeRedis