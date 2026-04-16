import { useEffect, useState } from "react"
import type { SignUpResponse } from "../../models/signup/signup"
import { adminProfiledetails } from "../../core/services/userService"
import { useNavigate } from "react-router-dom";
import { authToken } from "../../constants/storage-names";

const Profile = () => {

      const navigate=useNavigate();
    const removeToken=()=>{
        localStorage.removeItem(authToken);
        navigate("/login")
    }
   const [state,SetState]= useState<SignUpResponse>()
   const profile=async()=>{
    const data=await adminProfiledetails();
    if(data.isSuccess){
        SetState(data.value)
    }
   }

   useEffect(()=>{
     profile();
   },[])
  return (

<div className="min-h-screen bg-gray-100 flex items-center justify-center p-6">

  <div className="bg-white w-full max-w-md rounded-2xl shadow-lg p-8">

    {/* Title */}
    <h2 className="text-2xl font-bold text-center mb-6">
      My Profile
    </h2>

    {/* Email */}
    <div className="mb-4">
      <p className="text-gray-500 text-sm">Email</p>
      <p className="font-medium text-lg">{state?.email}</p>
    </div>

    {/* Contact */}
    <div className="mb-4">
      <p className="text-gray-500 text-sm">Contact</p>
      <p className="font-medium text-lg">{state?.contactNo}</p>
    </div>

    {/* Role */}
    <div className="mb-6">
      <p className="text-gray-500 text-sm">Role</p>
      <span className={`inline-block px-3 py-1 rounded-full text-sm font-medium
        ${state?.userRole === 1 
          ? "bg-green-100 text-green-700" 
          : "bg-gray-200 text-gray-700"}`}>
        {state?.userRole === 1 ? "Admin" : "User"}
      </span>
    </div>

    {/* Logout Button */}
    <button
      onClick={() => removeToken()}
      className="w-full bg-red-500 hover:bg-red-600 text-white py-2 rounded-lg font-medium transition"
    >
      Logout
    </button>

  </div>

</div>
  


  )
}

export default Profile
