import { Link } from "react-router-dom";

const Sidebar = () => {
  return (

<div className="w-64 h-screen bg-gray-900 text-white p-6 flex flex-col">

  {/* Title */}
  <h2 className="text-2xl font-bold mb-10">Admin Panel</h2>

  {/* Links */}
  <nav className="flex flex-col gap-3">

    <Link 
      to="/admin/dashboard" 
      className="px-4 py-2 rounded-lg text-gray-300 hover:bg-gray-800 hover:text-white transition"
    >
      📊 Dashboard
    </Link>

    <Link 
      to="/admin/users" 
      className="px-4 py-2 rounded-lg text-gray-300 hover:bg-gray-800 hover:text-white transition"
    >
      👥 Users
    </Link>

    <Link 
      to="/admin/profile" 
      className="px-4 py-2 rounded-lg text-gray-300 hover:bg-gray-800 hover:text-white transition"
    >
      🙍 My Profile
    </Link>

  </nav>

  {/* Footer */}
  <div className="mt-auto text-sm text-gray-500">
    © Admin Panel
  </div>

</div>
  );
};

export default Sidebar;