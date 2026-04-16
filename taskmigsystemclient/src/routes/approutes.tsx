import { Navigate, Route, Routes} from "react-router-dom"
import Signup from "../pages/auth/signup"
import Login from "../pages/auth/login"
import About from "../pages/about"
import UserLayout from "../layout/user-layout/user-layout"
import UserDashboard from "../pages/user/UserDashboard"
import CreateTask from "../pages/user/CreateTask"
import GetTasks from "../pages/user/GetTasks"
import UpdateTask from "../pages/user/UpdateTask"
import OAuthSuccess from "../pages/auth/oauth"
import AdminLayout from "../layout/admin-layout/admin-layout"
import Dashboard from "../pages/admin/DashBoard"
import Users from "../pages/admin/Users"
import Profile from "../pages/admin/Profile"

const Approutes = () => {
  
  


  return (
    <Routes>
     <Route path="/" element={<Navigate to ="/signup"/>}/>
      <Route path="/signup" element={<Signup/>} />
      <Route path="/login" element={<Login/>} />
      <Route path="/about" element={<About/>} />
      
      <Route path="/oauth-success" element={<OAuthSuccess/>} />

      <Route path="/user" element={<UserLayout />}>
  <Route index element={<UserDashboard />} />
   <Route path="create" element={<CreateTask />} />
   <Route path="tasks" element={<GetTasks/>} />
   <Route path="tasks/:id" element={<UpdateTask/>} />



    
  
</Route>

 <Route path="/admin" element={<AdminLayout />}>
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="users" element={<Users />} />
          <Route path="profile" element={<Profile />} />
        </Route>
    </Routes>
// user layout

  )
}

export default Approutes
