using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Sorteo.Domain.Interfaces;

namespace Sorteo.API
{
    public class ApiKeyAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IApiKeyRepository _apiKeyService;

        public ApiKeyAuthorizationFilter(IApiKeyRepository apiKeyService)
        {
            _apiKeyService = apiKeyService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var apiKey = apiKeyHeader.FirstOrDefault();
            if (!_apiKeyService.IsValidApiKey(apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
