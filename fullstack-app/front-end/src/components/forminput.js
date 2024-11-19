import React from "react";
import "../styles/form_input.css";

const FormInput = ({ type = "text", placeholder, value, onChange }) => {
  return (
    <input
      type={type}
      placeholder={placeholder}
      value={value}
      onChange={onChange}
      className="form-input"
    />
  );
};

export default FormInput;
