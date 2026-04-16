import type { TaskRequest, TaskResponse, TaskUpdateRequest } from "../../models/task/taskRequest";
import { routes } from "../../routes/routes";
import { apiClient } from "../lib/axios";
import type { Result } from "../utilis/result";

export const createTask=async(model:TaskRequest):Promise<Result<TaskResponse>>=>{
    return (await apiClient.post<Result<TaskResponse>>(routes.task.create,model))?.data
}

export const getTasks=async():Promise<Result<TaskResponse[]>>=>{
    return (await apiClient.get<Result<TaskResponse[]>>(routes.task.get))?.data

}

export const getTaskById=async(id:string):Promise<Result<TaskResponse>>=>{
    return (await apiClient.get<Result<TaskResponse>>(`tasks/${id}`))?.data
}

export const updateTask=async(model:TaskUpdateRequest):Promise<Result<TaskResponse>>=>{
    return (await apiClient.put<Result<TaskResponse>>(routes.task.put,model))?.data

}

export const deleteTask=async(id:string):Promise<Result<TaskResponse>>=>{
    return (await apiClient.delete<Result<TaskResponse>>(`tasks/${id}`))?.data
}
