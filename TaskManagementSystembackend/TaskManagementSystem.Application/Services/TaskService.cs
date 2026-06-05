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
            var userId = httpContextService.GetUserId();

            var task = mapper.Map<TaskItem>(model);
            task.UserId = userId;

            await taskItemRepository.AddAsync(task);
            var result = await unitOfWork.SaveChangesAsync();

            if (result <= 0)
                return Result<TaskResponse>.Failure("Error while creating task", StatusCodes.Status400BadRequest);

            var response = mapper.Map<TaskResponse>(task);

            return Result<TaskResponse>.Success(response, 200, "Task Added Successfully");
        }

        public async Task<Result<TaskResponse>> DeleteTask(Guid taskId)
        {
            var userId = httpContextService.GetUserId();

            var task = await taskItemRepository.GetEntityById(userId, taskId);

            if (task == null)
                return Result<TaskResponse>.Failure("Task not found", StatusCodes.Status404NotFound);

            await taskItemRepository.DeleteIdAsync(taskId);

            var result = await unitOfWork.SaveChangesAsync();

            if (result <= 0)
                return Result<TaskResponse>.Failure("Error while deleting task");

            var response = mapper.Map<TaskResponse>(task);

            return Result<TaskResponse>.Success(response, 200, "Task deleted successfully");
        }

        public async Task<Result<IEnumerable<TaskResponse>>> GetAllTasks()
        {
            var userId = httpContextService.GetUserId();

            var tasks = await taskItemRepository.GetTasks(userId);

            var response = mapper.Map<IEnumerable<TaskResponse>>(tasks);

            return Result<IEnumerable<TaskResponse>>.Success(response, 200, "Tasks fetched successfully");
        }

        public async Task<Result<TaskResponse>> GetTasksById(Guid taskId)
        {
            var userId = httpContextService.GetUserId();

            var task = await taskItemRepository.GetEntityById(userId, taskId);

            if (task == null)
                return Result<TaskResponse>.Failure("Task not found", StatusCodes.Status404NotFound);

            var response = mapper.Map<TaskResponse>(task);

            return Result<TaskResponse>.Success(response, 200, "Task fetched successfully");
        }

        public async Task<Result<TaskResponse>> UpdateTask(TaskUpdateRequest model)
        {
            var userId = httpContextService.GetUserId();

            var task = await taskItemRepository.GetEntityById(userId, model.Id);

            if (task == null)
                return Result<TaskResponse>.Failure("Task not found", StatusCodes.Status404NotFound);

            mapper.Map(model, task); 
            task.UserId = userId;

            await taskItemRepository.UpdateAsync(task);

            var result = await unitOfWork.SaveChangesAsync();

            if (result <= 0)
                return Result<TaskResponse>.Failure("Error while updating task");

            var response = mapper.Map<TaskResponse>(task);

            return Result<TaskResponse>.Success(response, 200, "Task updated successfully");
        }
    }
}
