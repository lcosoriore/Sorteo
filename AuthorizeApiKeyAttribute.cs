using Microsoft.AspNetCore.Mvc;

namespace Sorteo.API
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeApiKeyAttribute : TypeFilterAttribute
    {
        public AuthorizeApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
