import type { UserRole } from "../enums/enums"

export interface LoginRequest{
    email:string,
    password:string
}

export interface LoginResponse
{
    email:string,
    userId:string,
    token:string,
    isActive:boolean,
    userRole:UserRole
}