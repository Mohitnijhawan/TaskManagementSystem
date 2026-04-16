
const Topbar = () => {
  return (
    <div className="w-full bg-white shadow-sm px-6 py-4 flex items-center justify-between">

      {/* Left */}
      <h4 className="text-lg font-semibold text-gray-800">
        Admin Panel
      </h4>

      {/* Right */}
      <div className="flex items-center gap-4">

        {/* Profile Icon */}
        <div className="w-10 h-10 rounded-full bg-gray-300 flex items-center justify-center font-semibold text-gray-700">
          A
        </div>

      </div>

    </div>
  );
};



export default Topbar;