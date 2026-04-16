using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Application.RRModel.Auth;
using TaskManagementSystem.Application.Utility;

namespace TaskManagementSystem.Application.Abstraction.IServices
{
    public interface IAuthService
    {
        Task<Result<SignUpResponse>> SignUp (SignUpRequest model);
        Task<Result<LoginResponse>> Login(LoginRequest model);
        Task<Result<SignUpResponse>> BlockUser(Guid id);


    }
}
