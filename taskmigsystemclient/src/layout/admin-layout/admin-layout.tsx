 
import { Outlet } from "react-router-dom";
import Sidebar from "../../components/SideBar";
import Topbar from "../../components/TopBar";

const AdminLayout = () => {
  return (
   <div className="flex h-screen overflow-hidden">

  <Sidebar />

  <div className="flex-1 flex flex-col overflow-hidden">
    
    <Topbar />

    <div className="flex-1 overflow-y-auto bg-gray-100">
      <Outlet />
    </div>

  </div>

</div>
  );
};

export default AdminLayout;