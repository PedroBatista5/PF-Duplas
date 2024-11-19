import React from "react";
import LoginForm from "../components/loginform"; 
import "../styles/login.css"

const Login = () => {
  return (
    <div className="login-container">
      <div className="login-card">
        <div className="login-image">
          <img src="/path-to-your-image/logo.png" alt="Logo" />
        </div>
        <LoginForm />
      </div>
    </div>
  );
};

export default Login;
