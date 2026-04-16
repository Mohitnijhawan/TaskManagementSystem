using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TaskManagementSystem.Application.Abstraction.Identity;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.Abstraction.IUnitOfWork;
using TaskManagementSystem.Application.RRModel.Task;
using TaskManagementSystem.Application.Utility;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Services
{
    public class TaskService(ITaskItemRepository taskItemRepository, IMapper mapper, IUnitOfWork unitOfWork,IHttpContextService httpContextService) : ITaskService
    {
        public async Task<Result<TaskResponse>> CreateTask(TaskRequest model)
        {
            var task=mapper.Map<TaskItem>(model);
            task.UserId = httpContextService.GetUserId();
            var response = mapper.Map<TaskResponse>(task);
            await taskItemRepository.AddAsync(task);
            var returnVal=await unitOfWork.SaveChangesAsync();
            if(returnVal > 0)
            {
                return Result<TaskResponse>.Success(response, 200, "Task Added Successfully");
            }
            return Result<TaskResponse>.Failure("Their is an error please try again later...",StatusCodes.Status400BadRequest);
        }

        public async Task<Result<TaskResponse>> DeleteTask(Guid taskid)
        {
            var userid = httpContextService.GetUserId();
            var taskResponse = await taskItemRepository.GetById(userid,taskid);
            if(taskResponse is null)
            {
                return Result<TaskResponse>.Failure("No task found");
            }

            var taskitem = mapper.Map<TaskItem>(taskResponse);
            await taskItemRepository.DeleteIdAsync(taskid);
            var returnVal=await unitOfWork.SaveChangesAsync();
            if(returnVal > 0)
            {
                return Result<TaskResponse>.Success(taskResponse, "Task Deleted Successfully");
            }
            return Result<TaskResponse>.Failure("Their is an problem try again later....");

        }

        public async Task<Result<IEnumerable<TaskResponse>>> GetAllTasks()
        {
            var userid = httpContextService.GetUserId();
            var tasks = await taskItemRepository.GetTasks(userid);
            if(tasks is not null)
            {
                var response = mapper.Map<IEnumerable<TaskResponse>>(tasks);
                return Result<IEnumerable<TaskResponse>>.Success(response, 200, "Task Fetched");
            }
            return Result<IEnumerable<TaskResponse>>.Failure("Something went wrong....");

        }

        public async Task<Result<TaskResponse>> GetTasksById(Guid taskid)
        {
            var userId = httpContextService.GetUserId();
            var task = await taskItemRepository.GetById(userId, taskid);
            if(task is not null)
            {
                return Result<TaskResponse>.Success(task, 200, $@"Task with specific {taskid} fetched");
            }

            return Result<TaskResponse>.Failure("Their is an error try again later...");
        }

        public async Task<Result<TaskResponse>> UpdateTask(TaskUpdateRequest model)
        {
            var userId = httpContextService.GetUserId();
           var taskResponse= await taskItemRepository.GetById(userId, model.Id);
            var task = mapper.Map<TaskItem>(taskResponse);
            mapper.Map(model, task);
            task.UserId=userId;
            await taskItemRepository.UpdateAsync(task);
          var returnVal =  await unitOfWork.SaveChangesAsync();
            if(returnVal > 0)
            {
                return Result<TaskResponse>.Success(taskResponse,200, "Task Updated Successfully");
            }
            return Result<TaskResponse>.Failure("Their is an error try again later...");

        }
    }
}
