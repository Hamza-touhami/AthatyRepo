import React from 'react';
import './Sidebar.css'; // Create a corresponding CSS file for styling if needed

const Sidebar = () => {
  return (
    <div className="sidebar">
      <ul>
        <li >Main dashboard</li>
        <li>Admin</li>
        <li>Partners</li>
        <li>Sales</li>
        <li>Messages</li>
        <li>Categories</li>
      </ul>
    </div>
  );
};

export default Sidebar;