using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Application.RRModel.Task;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Abstraction.IRepository
{
    public interface ITaskItemRepository:IBaseRepository<TaskItem>
    {
        public Task<IEnumerable<TaskResponse>> GetTasks(Guid userid);
        public Task<TaskResponse> GetTaskById(Guid userid,Guid taskId);
        public Task<TaskResponse> GetById(Guid userid,Guid taskId);

    }
}
