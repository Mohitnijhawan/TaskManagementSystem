import { useForm } from "react-hook-form"
import type { TaskRequest } from "../../models/task/taskRequest"
import { createTask } from "../../core/services/taskService"
import { toast } from "react-toastify"
import { enumConversion } from "../../core/utilis/enumToArray"
import { StatusTask, TaskPriority } from "../../models/enums/enums"
import { zodResolver } from "@hookform/resolvers/zod"
import { taskSchema } from "../../models/schema/taskschema"
import { useNavigate } from "react-router-dom"



const CreateTask = () => {
const {register,handleSubmit}=useForm<TaskRequest>({
  resolver:zodResolver(taskSchema)
})

const navigate=useNavigate();

const submit=async(model:TaskRequest)=>{
    const response=await createTask(model);
    if(response.isSuccess){
        toast.success(response.message);
    }
}

  return (
   <div className="flex justify-center items-center min-h-screen">
  <form 
    onSubmit={handleSubmit(submit)} 
    className="bg-white p-6 rounded-2xl shadow-md w-full max-w-md space-y-4"
  >
    <h2 className="text-xl font-semibold text-center">Create Task</h2>

    {/* Title */}
    <div>
      <label className="block mb-1 text-sm font-medium">Title</label>
      <input
        type="text"
        placeholder="Enter title"
        {...register("title")}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      />
    </div>

    {/* Description */}
    <div>
      <label className="block mb-1 text-sm font-medium">Description</label>
      <input
        type="text"
        placeholder="Enter description"
        {...register("description")}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      />
    </div>

    {/* Status */}
    <div>
      <label className="block mb-1 text-sm font-medium">Status</label>
      <select
        {...register("status", { valueAsNumber: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      >
        <option value="">Select Status</option>
        {
          enumConversion(StatusTask).map((status) => (
            <option key={status.key} value={status.key}>
              {status.value as any}
            </option>
          ))
        }
      </select>
    </div>

    {/* Priority */}
    <div>
      <label className="block mb-1 text-sm font-medium">Priority</label>
      <select
        {...register("priority", { valueAsNumber: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      >
        <option value="">Select Priority</option>
        {
          enumConversion(TaskPriority).map((task) => (
            <option key={task.key} value={task.key}>
              {task.value as any}
            </option>
          ))
        }
      </select>
    </div>

    {/* Date */}
    <div>
      <label className="block mb-1 text-sm font-medium">Date</label>
      <input
        type="datetime-local"
        {...register("dueDate", { valueAsDate: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      />
    </div>

    {/* Button */}
    <button onClick={()=>navigate("/user")}
      type="submit"
      className="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition"
    >
      Create Task
    </button>
  </form>
</div>
  )
}

export default CreateTask
