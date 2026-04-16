import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { LoginSchema } from "../../models/schema/loginschema"
import type { LoginRequest } from "../../models/login/login"
import { login } from "../../core/services/authService"
import { toast } from "react-toastify/unstyled"
import { UserRole } from "../../models/enums/enums"
import { Link, useNavigate } from "react-router-dom"
import { authToken } from "../../constants/storage-names"
import bgimage from "../../assets/bg.png";
import { useState } from "react"; // ✅ added

const Login = () => {

  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: zodResolver(LoginSchema)
  })

  const [showPassword, setShowPassword] = useState(false); // ✅ added

  const navigate = useNavigate();

  const submit = async (model: LoginRequest) => {
    const response = await login(model);
    if (response.isSuccess) {
      toast.success(response.message || "Login Sucessfully");
    }
    console.log(response);
    localStorage.setItem(authToken, response.value.token);

    if (response.value.userRole === UserRole.Admin) {
      navigate("/admin/dashboard")
    }
    else if (response.value.userRole === UserRole.User) {
      navigate("/user")
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

      {/* Main Content */}
      <div className="relative z-10 w-full max-w-6xl flex flex-col md:flex-row items-center justify-center gap-8 md:gap-12">

        {/* LEFT TEXT */}
        <div className="text-white max-w-md text-center md:text-left">
          <h1 className="text-2xl sm:text-3xl md:text-4xl font-bold mb-3 md:mb-4">
            Welcome Back 👋
          </h1>
          <p className="text-gray-200 text-sm sm:text-base">
            Login to manage your tasks, stay organized, and boost your productivity.
          </p>
        </div>

        {/* LOGIN CARD */}
        <div className="w-full max-w-md bg-white/90 backdrop-blur-md p-5 sm:p-6 rounded-2xl shadow-xl">

          <h2 className="text-xl sm:text-2xl font-bold mb-5 text-center">
            Login
          </h2>

          <form onSubmit={handleSubmit(submit)} className="space-y-4">

            {/* Email */}
            <div>
              <label className="block mb-1 font-medium text-sm">Email</label>
              <input
                type="text"
                {...register("email")}
                placeholder="Enter your email"
                className="w-full border rounded-lg px-3 py-2 text-sm sm:text-base focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              <span className="text-red-500 text-xs">
                {errors.email && errors.email.message}
              </span>
            </div>

            {/* Password ✅ UPDATED */}
            <div className="relative">
              <label className="block mb-1 font-medium text-sm">Password</label>

              <input
                type={showPassword ? "text" : "password"}
                {...register("password")}
                placeholder="Enter your password"
                className="w-full border rounded-lg px-3 py-2 pr-10 text-sm sm:text-base focus:outline-none focus:ring-2 focus:ring-blue-500"
              />

              <button
                type="button"
                onClick={() => setShowPassword(!showPassword)}
                className="absolute right-3 top-9 text-sm text-gray-600"
              >
                {showPassword ? "Hide" : "Show"}
              </button>

              <span className="text-red-500 text-xs">
                {errors.password && errors.password.message}
              </span>
            </div>

            {/* Button */}
            <button
              type="submit"
              className="w-full bg-blue-600 text-white py-2.5 rounded-lg text-sm sm:text-base hover:bg-blue-700 transition"
            >
              Login
            </button>
          </form>

          {/* Bottom link */}
          <p className="mt-4 text-center text-xs sm:text-sm text-gray-600">
            Don't have an account?{" "}
            <Link
              to="/signup"
              className="text-blue-600 font-medium hover:text-blue-700 transition-colors"
            >
              Sign Up
            </Link>
          </p>
        </div>
      </div>

      {/* FOOTER */}
      <footer className="w-full text-center text-white text-xs sm:text-sm py-3 bg-black/40 mt-6 absolute bottom-0">
        © 2026 Task Manager | Built with ❤️ by Mohit
      </footer>
    </div>
  )
}

export default Login  