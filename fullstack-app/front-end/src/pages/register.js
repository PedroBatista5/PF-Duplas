
import React, { useState } from "react";
import FormInput from "../components/forminput";
import FormButton from "../components/formbutton";
import "../styles/register.css";

const Register = () => {
  const [utente, setUtente] = useState("");
  const [dataNascimento, setDataNascimento] = useState("");
  const [contacto, setContacto] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Nº Utente:", utente);
    console.log("Data de Nascimento:", dataNascimento);
    console.log("Contacto:", contacto);
    console.log("Palavra-Passe:", password);
  };

  return (
    <div className="register-container">
      <div className="login-card">
        <div className="login-image"></div>
        <form onSubmit={handleSubmit}>
          <FormInput
            type="text"
            placeholder="Nº Utente de Saúde"
            value={utente}
            onChange={(e) => setUtente(e.target.value)}
          />
          <FormInput
            type="date"
            placeholder="Data de Nascimento"
            value={dataNascimento}
            onChange={(e) => setDataNascimento(e.target.value)}
          />
          <FormInput
            type="text"
            placeholder="Contacto"
            value={contacto}
            onChange={(e) => setContacto(e.target.value)}
          />
          <FormInput
            type="password"
            placeholder="Palavra-Passe"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <FormButton text="Registrar" type="submit" />
        </form>
        <div className="login-register">
          Já possui conta? <a >Faça login</a>
        </div>
      </div>
    </div>
  );
};
export default Register;
