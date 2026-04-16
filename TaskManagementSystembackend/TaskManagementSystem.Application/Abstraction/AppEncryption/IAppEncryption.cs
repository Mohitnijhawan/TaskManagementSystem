using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Application.Abstraction.AppEncryption
{
    public interface IAppEncryption
    {
        string GenerateSalt();

        string HashPassword(string password,string salt);
    }
}
