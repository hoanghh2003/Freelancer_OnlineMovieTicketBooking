import React from 'react';
import { Link } from 'react-router-dom';
import '../assets/styles/NavBar.css';
import logo from '../assets/images/logo.png'; // Thêm hình ảnh logo của bạn vào thư mục images

const NavBar: React.FC = () => {
  return (
    <nav className="navbar">
      <div className="brand">
        <img src={logo} alt="Logo" />
      </div>
      <div className="links">
        <Link to="/movies">Phim</Link>
        <Link to="/theaters">Rạp</Link>
        <Link to="/members">Thành viên</Link>
        <Link to="/cultureplex">Cultureplex</Link>
      </div>
      <div className="right">
        <Link to="/login">Đăng nhập/Đăng ký</Link>
        <button>Mua vé ngay</button>
      </div>
    </nav>
  );
};

export default NavBar;
