import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./pages/login";
import Register from "./pages/register";
import ConsultarBaixas from "./pages/consultarbaixas";

ReactDOM.render(
  <Router>
    <Routes>
      <Route path="/" element={<Register />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/consultarbaixas" element={<ConsultarBaixas />} />
    </Routes>
  </Router>,
  document.getElementById("root")
);