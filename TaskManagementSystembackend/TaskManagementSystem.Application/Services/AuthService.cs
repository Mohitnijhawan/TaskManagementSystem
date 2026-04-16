using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TaskManagementSystem.Application.Abstraction.AppEncryption;
using TaskManagementSystem.Application.Abstraction.Identity;
using TaskManagementSystem.Application.Abstraction.IJWTProvider;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.Abstraction.IUnitOfWork;
using TaskManagementSystem.Application.RRModel.Auth;
using TaskManagementSystem.Application.Utility;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Services
{
    public class AuthService(IAuthRepository authRepository,IAppEncryption appEncryption,IMapper mapper,IUnitOfWork unitOfWork,IJWTProvider jWTProvider,IHttpContextService httpContextService) : IAuthService
    {
        public async Task<Result<SignUpResponse>> BlockUser(Guid id)
        {
            var transaction = unitOfWork.BeginTransaction();

            var user = await authRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                return Result<SignUpResponse>.Failure("User not found", StatusCodes.Status404NotFound);
            }

            var currentUserId = httpContextService.GetUserId();
            var currentUser = await authRepository.FirstOrDefaultAsync(x => x.Id == currentUserId);
            if (currentUser.Id == id)
            {
                return Result<SignUpResponse>.Failure("You Can't Block Your Own Account", StatusCodes.Status400BadRequest);
            }



            user.IsActive = user.IsActive ? false : true;
            await authRepository.UpdateByIdAsync(user.Id);
            var returnValue = await unitOfWork.SaveChangesAsync();
            if (returnValue > 0)
            {
                transaction.Commit();
                var response = mapper.Map<SignUpResponse>(user);
                return Result<SignUpResponse>.Success(response, user.IsActive ? "User Unblocked successfully" : " User Blocked Successfully");
            }
            return Result<SignUpResponse>.Failure("Something went wrong while blocking the user");
        }


        public async Task<Result<LoginResponse>> Login(LoginRequest model)
        {
            var user = await authRepository.FirstOrDefaultAsync(user => user.Email == model.Email);
            if (user is null)
            {
                return Result<LoginResponse>.Failure("Username or Password is incorrect", StatusCodes.Status400BadRequest);
            }
            var hashPassword = appEncryption.HashPassword(model.Password, user.Salt);
            if (!hashPassword.Equals(user.PasswordHash))
            {
                return Result<LoginResponse>.Failure("Username or Password is incorrect", StatusCodes.Status400BadRequest);
            }
            if (user.IsActive != true)
            {
                return Result<LoginResponse>.Failure("Your Account Is Blocked, Contact Admin", StatusCodes.Status400BadRequest);
            }
            var loginResponse = new LoginResponse()
            {
                UserId = user.Id,
                Email = user.Email,
                Token = jWTProvider.GenerateAuthToken(user),
                UserRole=user.UserRole
                
            };
            return Result<LoginResponse>.Success(loginResponse, "Logged in successfully");
        }

        public async Task<Result<SignUpResponse>> SignUp(SignUpRequest model)
        {
            var isExists = await authRepository.FirstOrDefaultAsync(x => x.Email == model.Email);
            if(isExists is null)
            {
                var user = mapper.Map<User>(model);
                var salt = appEncryption.GenerateSalt();
                var hashPassword = appEncryption.HashPassword(model.Password, salt);
                user.Salt= salt;
                user.PasswordHash= hashPassword;
                user.IsActive=true;
                user.UserRole=Domain.Enums.UserRole.User;
                await authRepository.AddAsync(user);
                var returnVal= await unitOfWork.SaveChangesAsync();
                if(returnVal > 0)
                {
                    var response = mapper.Map<SignUpResponse>(user);
                    return Result<SignUpResponse>.Success(response, 200, "Signup Successfully");
                }
                return Result<SignUpResponse>.Failure("Something went wrong");
            }
            return Result<SignUpResponse>.Failure("Email Already Exists");
        }
    }
}
