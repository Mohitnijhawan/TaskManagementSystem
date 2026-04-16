using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Abstraction.IJWTProvider
{
    public interface IJWTProvider
    {
        string GenerateAuthToken(User user);

    }
}
