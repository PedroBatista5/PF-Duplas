import React, { useState } from "react";
import FormInput from "../components/forminput";
import FormButton from "../components/formbutton";
import { useNavigate } from "react-router-dom"; // Hook para navegação
import "../styles/register.css";

const Register = () => {
  const [NSaude, setUtente] = useState("");
  const [DataNasc, setDataNascimento] = useState("");
  const [Contacto, setContacto] = useState("");
  const [Passe, setPassword] = useState("");
  const navigate = useNavigate(); // Instância do hook useNavigate
  

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Nº Utente:", NSaude);
    console.log("Data de Nascimento:", DataNasc);
    console.log("Contacto:", Contacto);
    console.log("Palavra-Passe:", Passe);
  };

  return (
    <div className="register-container">
      <div className="login-card">
        <div className="login-image"></div>
        <form onSubmit={handleSubmit}>
          <FormInput
            type="text"
            placeholder="Nº Utente de Saúde"
            value={NSaude}
            onChange={(e) => setUtente(e.target.value)}
          />
          <FormInput
            type="date"
            placeholder="Data de Nascimento"
            value={DataNasc}
            onChange={(e) => setDataNascimento(e.target.value)}
          />
          <FormInput
            type="text"
            placeholder="Contacto"
            value={Contacto}
            onChange={(e) => setContacto(e.target.value)}
          />
          <FormInput
            type="password"
            placeholder="Palavra-Passe"
            value={Passe}
            onChange={(e) => setPassword(e.target.value)}
          />
          <FormButton text="Registrar" type="submit" />
        </form>
        <div className="login-register">
        <h1>Já possui conta? <button onClick={() => navigate('/login')}>Faça Login</button></h1>
        </div>
      </div>
    </div>
  );
};
export default Register;
