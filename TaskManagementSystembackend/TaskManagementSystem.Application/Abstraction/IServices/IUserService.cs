using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Application.RRModel.Auth;
using TaskManagementSystem.Application.Utility;

namespace TaskManagementSystem.Application.Abstraction.IServices
{
    public interface IUserService
    {
        Task<Result<IEnumerable<SignUpResponse>>> GetAllUsers();

        Task<Result<SignUpResponse>> UserProfile();
    }
}
