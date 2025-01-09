import React from 'react';
import '../styles/vertical_navbar.css';

const VerticalBar = () => {
    return (
        <div className="verticalbar-container">
            <div className="logo">
                <h1>SNS - Baixas Médicas</h1>
            </div>
            <div className="menu-horizontal">
                <select className="dropdown">
                    <option>Médico [NOME]</option>
                </select>
                <span className="menu-item">Consultar Baixas</span>
                <span className="menu-item">Emitir Baixas</span>
                <span className="menu-item">Relatórios</span>
                <span className="menu-item">Perfil</span>
            </div>
        </div>
    );
};

export default VerticalBar;
