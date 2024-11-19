import React, { useState } from "react";
import FormInput from "../components/forminput";
import FormButton from "../components/formbutton";

const LoginForm = () => {
  const [utente, setUtente] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Nº Utente:", utente);
    console.log("Palavra-Passe:", password);
  };

  return (
    <form onSubmit={handleSubmit}>
      <FormInput
        type="text"
        placeholder="Nº Utente de Saúde"
        value={utente}
        onChange={(e) => setUtente(e.target.value)}
      />
      <FormInput
        type="password"
        placeholder="Palavra-Passe"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <FormButton text="Login" type="submit" />
    </form>
  );
};

export default LoginForm;
