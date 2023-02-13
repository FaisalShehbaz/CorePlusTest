import React from "react";
import { variables } from '../constants/variables';
import { IUser } from "./interface";
interface IProps {
    supervisor: Array<IUser>;
  onPractitionerClick: (user: IUser) => void;
 }

const Supervisor: React.FunctionComponent<IProps> = props => {
  return (
    <div className="supervisors">Supervisor practitioners 
      <ol>
        {props.supervisor.length > 0 ? (
              props.supervisor.map(i => (
                <li>
                  <button onClick={() => props.onPractitionerClick(i)}>{i["name"]}</button>
                </li>
              ))
            ) : (
              <li> <a href="#" > No Supervisor found. </a> </li>
            )}
      </ol>
    </div>
  );
};
export default Supervisor;
