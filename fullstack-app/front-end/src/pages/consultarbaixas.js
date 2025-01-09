import React from 'react';
import TopBar from '../components/vertical_navbar.js';
import '../styles/consultarbaixas.css';

const ConsultarBaixas = () => {
    return (
        <div className="consultarbaixas-container">
            <TopBar />
            <div className="content">
                <h2>Baixas Emitidas</h2>
                <table className="baixas-table">
                    <thead>
                        <tr>
                            <th>Paciente</th>
                            <th>Data de Fim</th>
                            <th>Instituição</th>
                            <th>Status</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>[Paciente]</td>
                            <td>[Data de Fim]</td>
                            <td>[Instituição]</td>
                            <td>[Status]</td>
                            <td><button className="view-button">Ver</button></td>
                        </tr>
                        <tr>
                            <td>[Paciente]</td>
                            <td>[Data de Fim]</td>
                            <td>[Instituição]</td>
                            <td>[Status]</td>
                            <td><button className="view-button">Ver</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default ConsultarBaixas;
