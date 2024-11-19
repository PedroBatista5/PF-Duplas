import React from "react";

const FormButton = ({ text, type }) => {
  return (
    <button
      type={type}
      style={{
        width: "100%",
        padding: "10px",
        marginTop: "10px",
        backgroundColor: "#007BFF",
        color: "#fff",
        border: "none",
        borderRadius: "4px",
        cursor: "pointer",
      }}
    >
      {text}
    </button>
  );
};

export default FormButton;
