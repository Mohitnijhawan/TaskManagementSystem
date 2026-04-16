using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Application.RRModel.Task;
using TaskManagementSystem.Application.Utility;

namespace TaskManagementSystem.Application.Abstraction.IServices
{
    public interface ITaskService
    {
        Task<Result<TaskResponse>> CreateTask(TaskRequest model);
        Task<Result<IEnumerable<TaskResponse>>> GetAllTasks();
        Task<Result<TaskResponse>> GetTasksById(Guid taskid);
        Task<Result<TaskResponse>> UpdateTask(TaskUpdateRequest model);
        Task<Result<TaskResponse>> DeleteTask(Guid taskid);
    }
}
