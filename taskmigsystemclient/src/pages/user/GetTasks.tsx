import { useEffect, useState } from "react";
import type { TaskResponse } from "../../models/task/taskRequest";
import { deleteTask, getTasks } from "../../core/services/taskService";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

const GetTasks = () => {
  const navigate = useNavigate();
  const [tasks, Settasks] = useState<TaskResponse[]>([]);

  const Tasks = async () => {
    const data = await getTasks();
    if (data.isSuccess) {
      Settasks(data.value);
    }
  };

  useEffect(() => {
    Tasks();
  }, [tasks]); // same logic

  const DeleteTask = async (id: string) => {
    const data = await deleteTask(id);
    if (data.isSuccess) {
      toast.success(data.message);
    }
  };

  return (
    <div className="w-full">

      {/* Heading */}
      <h1 className="text-lg sm:text-xl font-semibold text-gray-800 mb-4">
        Tasks
      </h1>

      {/* Empty */}
      {tasks.length === 0 && (
        <div className="text-center text-gray-500 mt-10">
          No tasks found 🚀
        </div>
      )}

      {/* Grid */}
      <div className="grid gap-3 sm:gap-4 md:grid-cols-2 xl:grid-cols-3">

        {tasks.map((task) => (
          <div
            key={task.id}
            className="bg-white border border-gray-200 rounded-xl shadow-sm hover:shadow-md transition"
          >
            <div className="p-4 space-y-3">

              {/* Title */}
              <div className="flex justify-between">
                <span className="text-sm font-medium text-gray-600">Title:</span>
                <span className="text-sm text-gray-800 text-right">{task.title}</span>
              </div>

              {/* Description */}
              <div className="flex justify-between">
                <span className="text-sm font-medium text-gray-600">Description:</span>
                <span className="text-sm text-gray-500 text-right">{task.description}</span>
              </div>

              {/* Status */}
              <div className="flex justify-between items-center">
                <span className="text-sm font-medium text-gray-600">Status:</span>
                <span className={`text-xs px-2 py-1 rounded-full ${
                  task.status === 1
                    ? "bg-yellow-100 text-yellow-700"
                    : task.status === 2
                    ? "bg-blue-100 text-blue-700"
                    : task.status === 3
                    ? "bg-green-100 text-green-700"
                    : "bg-gray-100 text-gray-500"
                }`}>
                  {task.status === 1 ? "Pending" :
                   task.status === 2 ? "In Progress" :
                   task.status === 3 ? "Completed" : "Unknown"}
                </span>
              </div>

              {/* Priority */}
              <div className="flex justify-between items-center">
                <span className="text-sm font-medium text-gray-600">Priority:</span>
                <span className={`text-xs px-2 py-1 rounded-full ${
                  task.priority === 1 as any
                    ? "bg-sky-100 text-sky-700"
                    : task.priority === 2 as any
                    ? "bg-amber-100 text-amber-700"
                    : task.priority === 3 as any
                    ? "bg-red-100 text-red-700"
                    : "bg-gray-100 text-gray-500"
                }`}>
                  {task.priority === 1  as any? "Low" :
                   task.priority === 2 as any ? "Medium" :
                   task.priority === 3 as any ? "High" : "Unknown"}
                </span>
              </div>

              {/* Due */}
              <div className="flex justify-between">
                <span className="text-sm font-medium text-gray-600">Due:</span>
                <span className="text-xs text-gray-500 text-right">
                  {task.dueDate
                    ? new Date(task.dueDate).toLocaleString()
                    : "No due date"}
                </span>
              </div>

              {/* Buttons */}
              <div className="flex gap-2 pt-2">
                <button
                  onClick={() => navigate(`/user/tasks/${task.id}`)}
                  className="flex-1 text-sm py-2 rounded-lg bg-indigo-500 text-white hover:bg-indigo-600 transition"
                >
                  Edit
                </button>

                <button
                  onClick={() => DeleteTask(task.id)}
                  className="flex-1 text-sm py-2 rounded-lg bg-red-500 text-white hover:bg-red-600 transition"
                >
                  Delete
                </button>
              </div>

            </div>
          </div>
        ))}

      </div>
    </div>
  );
};

export default GetTasks;