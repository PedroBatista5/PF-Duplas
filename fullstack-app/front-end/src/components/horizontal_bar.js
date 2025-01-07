import React from "react";
import "../styles/horizontal_bar.css"

const HorizontalBar = () => {
  return (
    <div className="horizontal-bar">
      <div className="bar-content">
        <img
          src="../images/sns24.png"
          alt="Logo"
          className="bar-logo"
        />
        <span className="bar-text">SNS - Baixas Médicas</span>
      </div>
    </div>
  );
};

export default HorizontalBar;
