import { Link } from "react-router-dom";
import type { SignUpRequest } from "../../models/signup/signup";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { SignUpSchema } from "../../models/schema/signupschema";
import { useState } from "react";
import { Signup } from "../../core/services/authService";
import { toast } from "react-toastify";
import bgimage from "../../assets/bg.png";

const signup = () => {

   const {register,handleSubmit,formState:{errors}}= useForm<SignUpRequest>({
        resolver:zodResolver(SignUpSchema)
    })

    const [showPassword,setShowPassword]=useState(false);

  const submit=async(model:SignUpRequest)=>{
    let data=await Signup(model);
    if(data.isSuccess){
        toast.success(data.message);
    }
  }

  return (
<div className="min-h-screen flex items-center justify-center relative px-4 py-10">

  {/* Background Image */}
  <div className="absolute inset-0">
    <img
      src={bgimage}
      alt="background"
      className="w-full h-full object-cover"
    />
    <div className="absolute inset-0 bg-black/60"></div>
  </div>

  <div className="relative z-10 w-full max-w-6xl flex flex-col md:flex-row items-center justify-center gap-8 md:gap-12">

    <div className="text-white max-w-md text-center md:text-left">
      <h1 className="text-2xl sm:text-3xl md:text-4xl font-bold mb-3 md:mb-4 leading-tight">
        Task Manager 🚀
      </h1>
      <p className="text-gray-200 text-sm sm:text-base">
        Organize your work, track progress, and boost productivity.
      </p>
    </div>

    <div className="w-full max-w-md bg-white/90 backdrop-blur-md p-5 sm:p-6 rounded-2xl shadow-xl">

      <h2 className="text-xl sm:text-2xl font-bold mb-5 text-center">
        Signup
      </h2>

      <form onSubmit={handleSubmit(submit)} className="space-y-4">

        {/* Email */}
        <div>
          <label className="block mb-1 font-medium text-sm">Email</label>
          <input
            type="text"
            {...register("email")}
            className="w-full border rounded-lg px-3 py-2"
          />
          <span className="text-red-500 text-xs">
            {errors.email?.message}
          </span>
        </div>

        {/* Password */}
        <div className="relative">
          <label className="block mb-1 font-medium text-sm">Password</label>
          
          <input
            type={showPassword ? "text" : "password"}
            {...register("password")}
            className="w-full border rounded-lg px-3 py-2 pr-10"
          />

          {/* 👇 FIXED BUTTON */}
          <button
            type="button"  // ❗ VERY IMPORTANT
            onClick={() => setShowPassword(!showPassword)}
            className="absolute right-3 top-9 text-sm text-gray-600"
          >
            {showPassword ? "Hide" : "Show"}
          </button>

          <span className="text-red-500 text-xs">
            {errors.password?.message}
          </span>
        </div>

        {/* Contact */}
        <div>
          <label className="block mb-1 font-medium text-sm">Contact No</label>
          <input
            type="text"
            {...register("contactNo")}
            className="w-full border rounded-lg px-3 py-2"
          />
          <span className="text-red-500 text-xs">
            {errors.contactNo?.message}
          </span>
        </div>

        <button
          type="submit"
          className="w-full bg-blue-600 text-white py-2.5 rounded-lg"
        >
          Sign Up
        </button>
      </form>

      <p className="mt-4 text-center text-xs sm:text-sm text-gray-600">
        Already have an account?{" "}
        <Link to="/login" className="text-blue-600 font-medium">
          Login
        </Link>
      </p>
    </div>
  </div>

  <footer className="w-full text-center text-white text-xs sm:text-sm py-3 bg-black/40 mt-6 absolute bottom-0">
    © 2026 Task Manager | Built with ❤️ by Mohit
  </footer>
</div>
  )
}

export default signup