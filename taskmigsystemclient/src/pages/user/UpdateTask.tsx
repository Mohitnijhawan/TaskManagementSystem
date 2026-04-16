import { useNavigate, useParams } from "react-router-dom"
import { getTaskById, updateTask } from "../../core/services/taskService";
import { useForm } from "react-hook-form";
import { useEffect } from "react";
import type { TaskUpdateRequest } from "../../models/task/taskRequest";
import { toast } from "react-toastify";
import { enumConversion } from "../../core/utilis/enumToArray";
import { StatusTask, TaskPriority } from "../../models/enums/enums";

const UpdateTask = () => {
    const { register,handleSubmit,reset } = useForm<TaskUpdateRequest>();
    const { id } = useParams();

    const navigate=useNavigate();

    const GetById = async () => {
        let data = await getTaskById(id as string);
        if (data.isSuccess)
            reset(data.value)
    }

    useEffect(() => {
        GetById();
    }, [])

const submit=async(model:TaskUpdateRequest)=>{
    let data=await updateTask(model);
    if(data.isSuccess){
        toast.success(data.message)
    }

}

    return (
       <div className="p-4 max-w-md mx-auto">
  <form onSubmit={handleSubmit(submit)}>
    {/* Title */}
    <div className="mb-4">
      <label htmlFor="title" className="block mb-1 text-sm font-medium">
        Title
      </label>
      <input
        id="title"
        type="text"
        {...register("title", { required: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
        placeholder="Enter task title"
      />
    </div>

    {/* Description */}
    <div className="mb-4">
      <label htmlFor="description" className="block mb-1 text-sm font-medium">
        Description
      </label>
      <input
        id="description"
        type="text"
        {...register("description")}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
        placeholder="Enter task description"
      />
    </div>

    {/* Status */}
    <div className="mb-4">
      <label className="block mb-1 text-sm font-medium">Status</label>
      <select
        {...register("status", { valueAsNumber: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      >
        <option value="">Select Status</option>
        {enumConversion(StatusTask).map((status) => (
          <option key={status.key} value={status.key}>
            {status.value as any}
          </option>
        ))}
      </select>
    </div>

    {/* Priority */}
    <div className="mb-4">
      <label className="block mb-1 text-sm font-medium">Priority</label>
      <select
        {...register("priority", { valueAsNumber: true })}
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      >
        <option value="">Select Priority</option>
        {enumConversion(TaskPriority).map((task) => (
          <option key={task.key} value={task.key}>
            {task.value as any}
          </option>
        ))}
      </select>
    </div>

    {/* Date */}
    <div className="mb-6">
      <label className="block mb-1 text-sm font-medium">Due Date</label>
      <input
        type="datetime-local"
        {...register("dueDate")} // do not use `valueAsDate: true` with `datetime-local`; convert in your `submit` handler
        className="w-full border p-2 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
      />
    </div>

    {/* Button */}
    <button onClick={()=>navigate("/user")}
      type="submit"
      className="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition"
    >
      Edit
    </button>
  </form>
</div>
    )
}

export default UpdateTask
