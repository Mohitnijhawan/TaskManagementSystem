import { NavLink, Outlet, useNavigate } from "react-router-dom";
import { authToken } from "../../constants/storage-names";
import { toast } from "react-toastify";

const UserLayout = () => {
  const navigate = useNavigate();

  const removeToken = () => {
    localStorage.removeItem(authToken);
    toast.success("Logout Successfully");
    navigate("/login");
  };

  return (
    <div className="min-h-screen flex flex-col bg-gray-100">

      {/* Topbar */}
      <header className="bg-white shadow-sm px-3 sm:px-6 py-3 flex justify-between items-center sticky top-0 z-50">

        <h2 className="text-sm sm:text-lg font-semibold text-gray-800">
          Dashboard
        </h2>

        {/* Desktop Nav */}
        <nav className="hidden sm:flex items-center gap-4">
          <NavLink
            to="/user"
            end
            className={({ isActive }) =>
              isActive
                ? "text-blue-600 font-medium"
                : "text-gray-600 hover:text-blue-500"
            }
          >
            Home
          </NavLink>

          <NavLink
            to="/user/create"
            className={({ isActive }) =>
              isActive
                ? "bg-blue-600 text-white px-4 py-1.5 rounded-lg"
                : "bg-blue-100 text-blue-700 px-4 py-1.5 rounded-lg hover:bg-blue-200"
            }
          >
            + Task
          </NavLink>
        </nav>

        {/* Logout */}
        <button
          onClick={removeToken}
          className="text-xs sm:text-sm bg-red-500 text-white px-3 sm:px-4 py-1.5 rounded-lg hover:bg-red-600 transition"
        >
          Logout
        </button>
      </header>

      {/* Content (NO EXTRA TOP GAP) */}
      <main className="flex-1 overflow-auto px-3 sm:px-5 py-4 pb-20 sm:pb-6">
        <Outlet />
      </main>

      {/* Bottom Navbar (Mobile) */}
      <div className="sm:hidden fixed bottom-0 left-0 w-full bg-white border-t shadow-md flex justify-around py-2 z-50">

        <NavLink
          to="/user"
          end
          className={({ isActive }) =>
            `flex flex-col items-center text-xs ${
              isActive ? "text-blue-600" : "text-gray-500"
            }`
          }
        >
          🏠
          Home
        </NavLink>

        <NavLink
          to="/user/create"
          className={({ isActive }) =>
            `flex flex-col items-center text-xs ${
              isActive ? "text-blue-600" : "text-gray-500"
            }`
          }
        >
          ➕
          Add
        </NavLink>

        <button
          onClick={removeToken}
          className="flex flex-col items-center text-xs text-red-500"
        >
          🚪
          Logout
        </button>

      </div>
    </div>
  );
};

export default UserLayout;