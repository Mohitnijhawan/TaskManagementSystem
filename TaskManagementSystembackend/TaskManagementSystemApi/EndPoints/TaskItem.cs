using Carter;
using TaskManagementSystem.Application.Abstraction.IServices;
using TaskManagementSystem.Application.RRModel.Task;

namespace TaskManagementSystemApi.EndPoints
{
    public class TaskItem : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder appbuilder)
        {
            var app = appbuilder.MapGroup("api/tasks").WithTags("tasks");
            app.MapPost("", async (ITaskService taskService, TaskRequest model) =>
            {
                return await taskService.CreateTask(model);

            }).DisableAntiforgery();

            app.MapGet("", async (ITaskService taskService) =>
            {
                return await taskService.GetAllTasks();

            });

            app.MapGet("{id:guid}", async (ITaskService taskService,Guid id) =>
            {
                return await taskService.GetTasksById(id);

            });

            app.MapPut("", async (ITaskService taskService, TaskUpdateRequest model) =>
            {
                return await taskService.UpdateTask(model);

            }).DisableAntiforgery();

            app.MapDelete("{id:guid}", async (ITaskService taskService,Guid id) =>
            {
                return await taskService.DeleteTask(id);

            }).DisableAntiforgery();
        }
    }
}
