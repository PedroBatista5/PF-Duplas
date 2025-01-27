import React, { useState } from "react";
import FormInput from "../components/forminput";
import FormButton from "../components/formbutton";
import { useNavigate } from "react-router-dom"; // Hook para navegação
import axios from "axios"; // Importando axios para fazer requisições HTTP
import "../styles/login.css";

const Login = () => {
  const [NSaude, setNSaude] = useState(""); // Estado para o Nº de Saúde (Utente)
  const [Passe, setPassword] = useState(""); // Estado para a Palavra-Passe
  const [errorMessage, setErrorMessage] = useState(""); // Estado para mensagens de erro
  const navigate = useNavigate(); // Hook para navegação programática

  const handleSubmit = async (e) => {
    e.preventDefault();

    console.log("Nº de Saúde:", NSaude);
    console.log("Palavra-Passe:", Passe);

    try {
      // Fazer a requisição para o backend
      const response = await axios.post("http://localhost:5000/api/utilizador/login", {
        NSaude: NSaude, // Enviar o número de saúde
        Passe: Passe, // Enviar a senha
      });

      if (response.status === 200) {
        // Se o login for bem-sucedido, redireciona o usuário
        alert("Login bem-sucedido!");
        localStorage.setItem("authToken", response.data.token); // Armazenando o token de autenticação
        navigate("/consultarbaixas"); // Redireciona para a página "consultarbaixas"
      }
    } catch (error) {
      console.error("Erro no login:", error);
      setErrorMessage("Credenciais inválidas. Tente novamente.");
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
          {/* Campo para o Nº de Saúde (Utente) */}
          <FormInput
            type="text"
            placeholder="Nº de Saúde"
            value={NSaude}
            onChange={(e) => setNSaude(e.target.value)}
          />

          {/* Campo para a Palavra-Passe */}
          <FormInput
            type="password"
            placeholder="Palavra-Passe"
            value={Passe}
            onChange={(e) => setPassword(e.target.value)}
          />

          {/* Mensagem de erro */}
          {errorMessage && <p className="error-message">{errorMessage}</p>}

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
