using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Application.RRModel.Task;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistance.Data;

namespace TaskManagementSystem.Persistance.Repository
{
    public class TaskRepository(TaskManagementSystemDbContext context) : BaseRepository<TaskItem>(context), ITaskItemRepository
    {
        public async Task<int> UpdateTask(Guid userid, Guid taskId)
        {
            return await ExecuteAsync("SpUpdateTask", new { userid, taskId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TaskResponse> GetTaskById(Guid userid, Guid taskId)
        {
            return await FirstOrDefaultAsync<TaskResponse>("SpGetTaskById", new { userid, taskId }, 
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TaskResponse>> GetTasks(Guid userid)
        {
            return await QueryAsync<TaskResponse>(
                "SpGetAllTasks",
                new { id = userid },  
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<TaskResponse> GetById(Guid userid, Guid taskId)
        {
             var query = $@"Select * from TaskItems
                where UserId=@userid and id =@taskId";

            return await FirstOrDefaultAsync<TaskResponse>(query, new { userid, taskId });
        }
    }
}
