using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using TaskManagementSystem.Application.Abstraction.Identity;
using TaskManagementSystem.InfraStructure.JWTProvider;

namespace TaskManagementSystem.InfraStructure.Identity
{
    public class HttpContextService(IHttpContextAccessor httpContext) : IHttpContextService
    {
        public string GetCurrentClientUrl()
        {
            return httpContext.HttpContext.Request.Host.Value;
        }

        public string GetCurrentUrl()
        {
            return httpContext.HttpContext.Request.Headers["referer"]!;
        }

        public Guid GetUserId()
        {
            var strId = httpContext?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == UserClaims.UserId)?.Value;
            if (Guid.TryParse(strId, out Guid userId)) return userId;
                return Guid.Empty;
        }
    }
}
