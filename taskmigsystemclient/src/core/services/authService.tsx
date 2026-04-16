import type { LoginRequest, LoginResponse } from "../../models/login/login";
import type { SignUpRequest, SignUpResponse } from "../../models/signup/signup";
import { routes } from "../../routes/routes";
import { apiClient } from "../lib/axios";
import type { Result } from "../utilis/result";

export const Signup=async(model:SignUpRequest):Promise<Result<SignUpResponse>>=>{
    return (await apiClient.post<Result<SignUpResponse>>(routes.auth.signup,model))?.data
}

export const login=async(model:LoginRequest):Promise<Result<LoginResponse>>=>{
    return (await apiClient.post<Result<LoginResponse>>(routes.auth.login,model))?.data
}