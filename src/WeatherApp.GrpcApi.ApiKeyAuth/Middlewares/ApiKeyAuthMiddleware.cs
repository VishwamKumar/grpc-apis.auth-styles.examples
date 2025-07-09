namespace WeatherApp.GrpcApi.ApiKeyAuth.Middlewares;

public class ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
   
    private readonly List<ApiKey> apiKeys = configuration.GetSection("ApiKeys").Get<List<ApiKey>>()??[]; //This can be changed to database and APIKey will be mapped to a client 
    
    public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedApiKey))
            {
               throw new RpcException(new Status(StatusCode.Unauthenticated, "API Key was not provided."));
            }

            var apiKey = apiKeys.FirstOrDefault(k => k.Key == extractedApiKey) ?? throw new RpcException(new Status(StatusCode.Unauthenticated, "Unauthorized client."));
            await next(context);
        }

}

