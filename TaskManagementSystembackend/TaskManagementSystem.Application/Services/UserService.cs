using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TaskManagementSystem.Application.Abstraction.Identity;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.Abstraction.IUnitOfWork;
using TaskManagementSystem.Application.RRModel.Auth;
using TaskManagementSystem.Application.Utility;

namespace TaskManagementSystem.Application.Services
{
    public class UserService(IUserRepository userRepository,IMapper mapper,IUnitOfWork unitOfWork,IHttpContextService httpContextService): IUserService
    {
        
        public async Task<Result<IEnumerable<SignUpResponse>>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();
            if(users is not null)
            {
                var response = mapper.Map<IEnumerable<SignUpResponse>>(users);
                return Result<IEnumerable<SignUpResponse>>.Success(response,200,"Users fetched successfully");
            }
            return Result<IEnumerable<SignUpResponse>>.Failure("Their is an error please try again later...",500);

        }

       public async Task<Result<SignUpResponse>> UserProfile()
        {
            Guid id = httpContextService.GetUserId();
            if (id == null)
            {
                return Result<SignUpResponse>.Failure("user not found", StatusCodes.Status400BadRequest);
            }

            var user = await userRepository.GetByIdAsync(id);
            if (user is null)
            {
                return Result<SignUpResponse>.Failure("user not found", StatusCodes.Status400BadRequest);
            }

            var response = mapper.Map<SignUpResponse>(user);

            return Result<SignUpResponse>.Success(response, "Admin Details Fetched Successfully");
        }
    }
}
