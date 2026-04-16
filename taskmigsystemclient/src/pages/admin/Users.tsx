import { useEffect, useState } from "react"
import type { SignUpResponse } from "../../models/signup/signup"
import { blockToggle, getUsers } from "../../core/services/userService"
import { toast } from "react-toastify"

const GetUsers = () => {

const [users,Setusers]=useState<SignUpResponse[]>([])

const Users=async()=>{

  const data= await getUsers();
  if(data.isSuccess){
   Setusers(data.value)
  }
}

 const toggleBlock = async (userId: string) => {
    const response = await blockToggle(userId);
    if (response.isSuccess) {
      toast.success(response.message);
    }
    await Users();
  };
useEffect(()=>{
  Users();
},[])

  return (
    
  <div className="p-6 bg-gray-100 min-h-screen">

  <h2 className="text-2xl font-semibold mb-6">Users</h2>

  <div className="bg-white rounded-2xl shadow-md overflow-hidden">
    
    <table className="w-full text-sm text-left">
      
      {/* Header */}
      <thead className="bg-gray-50 text-gray-600 uppercase text-xs">
        <tr>
          <th className="px-6 py-4">Email</th>
          <th className="px-6 py-4">Contact</th>
          <th className="px-6 py-4">Role</th>
          <th className="px-6 py-4">Status</th>
          <th className="px-6 py-4">Action</th>
        </tr>
      </thead>

      {/* Body */}
      <tbody className="divide-y">
        {users.map((user, index) => (
          <tr key={index} className="hover:bg-gray-50 transition">

            <td className="px-6 py-4">{user.email}</td>

            <td className="px-6 py-4">{user.contactNo}</td>

            {/* Role */}
            <td className="px-6 py-4">
              <span className={`px-3 py-1 rounded-full text-xs font-medium
                ${user.userRole === 1 
                  ? "bg-green-100 text-green-700" 
                  : "bg-gray-200 text-gray-700"}`}>
                {user.userRole === 1 ? "Admin" : "User"}
              </span>
            </td>

            {/* Status */}
            <td className="px-6 py-4">
              <span className={`px-3 py-1 rounded-full text-xs font-medium
                ${user.isActive 
                  ? "bg-green-100 text-green-700" 
                  : "bg-red-100 text-red-700"}`}>
                {user.isActive ? "Active" : "Blocked"}
              </span>
            </td>

            {/* Action */}
           <td className="px-6 py-3">
  {user.isActive ? (
    <button
      onClick={() => toggleBlock(user.id)}
      className="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600 transition-colors"
    >
      Block
    </button>
  ) : (
    <button
      onClick={() => toggleBlock(user.id)}
      className="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600 transition-colors"
    >
      Unblock
    </button>
  )}
</td>

          </tr>
        ))}
      </tbody>

    </table>
  </div>
</div>
  )
}

export default GetUsers
