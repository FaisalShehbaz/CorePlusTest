import React from "react";
import { variables } from '../constants/variables';
import { IUser } from "./interface";
interface IProps {
    supervisor: Array<IUser>;
  onPractitionerClick: (user: IUser) => void;
 }

const Supervisor: React.FunctionComponent<IProps> = props => {
  return (
    <div className="supervisors"> 
      <div className="p-2 bg-secondary shadow-sm">
        Supervisor practitioners
      </div>
      <ol>
        {props.supervisor.length > 0 ? (
              props.supervisor.map(i => (
                <li className="p-1 pl-2">
                  <button onClick={() => props.onPractitionerClick(i)}>{i["name"]}</button>
                </li>
              ))
            ) : (
              <li className="p-1 pl-2"> 
                <a href="#" > No Supervisor found. </a> 
              </li>
            )}
      </ol>
    </div>
  );
};
export default Supervisor;
