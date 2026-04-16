import type { UserRole } from "../enums/enums"

export interface SignUpRequest
{
    email:string,
    password:string,
    contactNo:string
}


export interface SignUpResponse
{
    id:string,
   email:string,
   contactNo:string,
   isActive:true,
   userRole:UserRole
}