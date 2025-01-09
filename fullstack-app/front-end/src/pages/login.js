import React, { useState } from "react";
import FormInput from "../components/forminput";
import FormButton from "../components/formbutton";
import { useNavigate } from "react-router-dom"; // Hook para navegação
import "../styles/login.css";

const Login = () => {
  const [utente, setUtente] = useState(""); // Estado para o Nº de Utente
  const [password, setPassword] = useState(""); // Estado para a Palavra-Passe
  const navigate = useNavigate(); // Hook para navegação programática

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Nº Utente:", utente);
    console.log("Palavra-Passe:", password);

    // Simulação de autenticação
    if (utente === "medico" && password === "senha123") {
      navigate("/consultarbaixas"); // Redireciona para a página consultarbaixas
    } else {
      alert("Credenciais inválidas");
    }
  };

  return (
    <div className="login-container">
      <div className="login-card">
        {/* Imagem ou logo */}
        <div className="login-image">
          <img src="/path-to-your-image/logo.png" alt="Logo" />
        </div>

        {/* Formulário de Login */}
        <form onSubmit={handleSubmit}>
          {/* Campo para o Nº de Utente */}
          <FormInput
            type="text"
            placeholder="Nº Utente de Saúde"
            value={utente}
            onChange={(e) => setUtente(e.target.value)}
          />

          {/* Campo para a Palavra-Passe */}
          <FormInput
            type="password"
            placeholder="Palavra-Passe"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />

          {/* Botão para Login */}
          <FormButton text="Login" type="submit" />
          {/* Link para Registo */}
          <div className="register-login">
            <h1>Não possui conta?<button onClick={() => navigate('/register')}>Faça Registo</button></h1>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;