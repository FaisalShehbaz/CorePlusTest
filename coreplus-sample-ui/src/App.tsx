import React, { useState, useEffect } from "react";
import * as ReactDOM from "react-dom";
import Practitioners from './components/practitioner';
import Supervisors from './components/supervisor';
import { variables } from './constants/variables';
import { IUser } from "./components/interface";
import "./app.css";
import { getPractitionerApi, getSupervisorsApi } from "./api/users";
import Report from "./components/report";

function App() {


  const [practitioner, setPractitioner] = useState<IUser[]>([]);
  const [supervisor, setSupervisor] = useState<IUser[]>([]);
  const [selectedPractitioner, setSelectedPractitioner] = useState<IUser>({});


  const refreshList = (user: IUser) => {
    // Add logic to fetch and show report data
  }
  
  const onPractitionerClick = (user: IUser) => {
    setSelectedPractitioner(user);
  };

  useEffect(() => {
    fetch(variables.API_URL + 'practitioners')
        .then(response => response.json())
        .then(data => {
          setPractitioner(data);
        });

    fetch(variables.API_URL + 'supervisors')
        .then(response => response.json())
        .then(data => {
          setSupervisor(data);
        });

  }, []);

  return (
    <div className="h-screen w-full appshell">
      <div className="header flex flex-row items-center p-2 bg-primary shadow-sm">
        <p className="font-bold text-lg">coreplus</p>
      </div>
      <Supervisors currentPractitioner={selectedPractitioner} supervisor={supervisor} onPractitionerClick={onPractitionerClick} />
      <Practitioners practitioner={practitioner} onPractitionerClick={onPractitionerClick} />
      {
        selectedPractitioner.id &&
        <Report practitioner={selectedPractitioner} />
      }
    </div>
  );
}

export default App;
