import type { StatusTask } from "../enums/enums";

export interface TaskRequest
{
    title:string,
    description:string,
    status:StatusTask,
    priority:TaskPriority,
    dueDate?:Date
}

export interface TaskResponse
{
    id:string,
    title:string,
    description:string,
    status:StatusTask,
    priority:TaskPriority,
    dueDate?:Date

}

export interface TaskUpdateRequest
{
    id:string,
     title:string,
    description:string,
    status:StatusTask,
    priority:TaskPriority,
    dueDate?:Date

}