using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Application.Abstraction.Identity
{
    public interface IHttpContextService
    {
        Guid GetUserId();

        string GetCurrentUrl();

        string GetCurrentClientUrl();
    }
}
