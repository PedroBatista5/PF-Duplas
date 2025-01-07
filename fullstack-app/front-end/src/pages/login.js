import React from "react";
import LoginForm from "../components/loginform"; 
import "../styles/login.css";
import HorizontalBar from "../components/horizontal_bar";  // Importando a barra horizontal

const Login = () => {
  return (
    <div className="main-container">
      {/* Barra Horizontal no topo da página */}
      <HorizontalBar />

      <div className="login-container">
        <div className="login-card">
          <div className="login-image">
            <img src="/path-to-your-image/logo.png" alt="Logo" />
          </div>

          <LoginForm />
        </div>
      </div>
    </div>
  );
};

export default Login;
