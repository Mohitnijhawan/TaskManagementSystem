using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TaskManagementSystem.Application.RRModel.Auth;
using TaskManagementSystem.Application.RRModel.Task;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.MapperProfile
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpRequest, User>().ReverseMap();

            CreateMap<User,SignUpResponse>().ReverseMap();

        }
    }

    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskRequest, TaskItem>().ReverseMap();

            CreateMap<TaskItem, TaskResponse>().ReverseMap();
            CreateMap<TaskUpdateRequest, TaskItem>().ReverseMap();

        }
    }
}
