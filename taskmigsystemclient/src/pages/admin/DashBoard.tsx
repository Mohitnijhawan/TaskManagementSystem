import { useEffect, useState } from "react"
import type { SignUpResponse } from "../../models/signup/signup"
import { getUsers } from "../../core/services/userService"

const DashBoard = () => {
  const [user,setusers]=useState<SignUpResponse[]>([])

 const users=async()=>{
  const data=await getUsers();
  if(data.isSuccess){
    setusers(data.value)
  }
 }

 useEffect(()=>{
    users();
 },[])

 const totalUsers = user.length;

const activeUsers = user.filter(u => u.isActive).length;

const blockedUsers = user.filter(u => !u.isActive).length;

const adminCount = user.filter(u => u.userRole === 1).length;

  return (
    
 <div className="p-6 bg-gray-100 h-full">

  <h2 className="text-2xl font-semibold mb-6">Dashboard</h2>

  <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">

    <div className="bg-white p-5 rounded-2xl shadow w-full">
      <p className="text-gray-500 text-sm">Total Users</p>
      <h3 className="text-3xl font-bold">{totalUsers}</h3>
    </div>

    <div className="bg-white p-5 rounded-2xl shadow w-full">
      <p className="text-gray-500 text-sm">Active Users</p>
      <h3 className="text-3xl font-bold text-green-600">
        {activeUsers}
      </h3>
    </div>

    <div className="bg-white p-5 rounded-2xl shadow w-full">
      <p className="text-gray-500 text-sm">Blocked Users</p>
      <h3 className="text-3xl font-bold text-red-600">
        {blockedUsers}
      </h3>
    </div>

    <div className="bg-white p-5 rounded-2xl shadow w-full">
      <p className="text-gray-500 text-sm">Admins</p>
      <h3 className="text-3xl font-bold text-blue-600">
        {adminCount}
      </h3>
    </div>

  </div>

</div>
);
  
}

export default DashBoard
