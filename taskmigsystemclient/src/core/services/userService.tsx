import type { Result } from "../utilis/result";
import type { SignUpResponse } from "../../models/signup/signup";
import { apiClient } from "../lib/axios";

export const getUsers=async():Promise<Result<SignUpResponse[]>>=>{
    return (await apiClient.get<Result<SignUpResponse[]>>("users"))?.data;
}

export const adminProfiledetails = async ():Promise<Result<SignUpResponse>> => {
    return (await apiClient.get<Result<SignUpResponse>>("users/user-details"))?.data;
}

export const blockToggle = async (id: string):Promise<Result<SignUpResponse>> => {
     return (await apiClient.put<Result<SignUpResponse>>(`/auth/block-user/${id}`))?.data;
}