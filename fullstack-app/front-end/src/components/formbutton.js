import React from "react";
import "../styles/form_button.css"

const FormButton = ({ text, onClick, type = "button" }) => {
  return (
    <button className="form-button" onClick={onClick} type={type}>
      {text}
    </button>
  );
};

export default FormButton;
