import React from "react";
import { variables } from '../constants/variables';
import { IUser } from "./interface";
interface IProps {
  practitioner: Array<IUser>;
  onPractitionerClick: (user: IUser) => void;
 }

const Practitioner: React.FunctionComponent<IProps> = props => {
  return (
    <div className="praclist">
      <div className="p-2 bg-secondary shadow-sm">
        Remaining Practitioners
      </div>
      <ol>
        {props.practitioner.length > 0 ? (
              props.practitioner.map(i => (
                <li key={i["id"]} className="p-1 pl-2">
                  <button onClick={() => props.onPractitionerClick(i)}>{i["name"]}</button>
                </li>
              ))
            ) : (
              <li className="p-1 pl-2"> 
                <a href="#" > no Practitioners found </a> 
              </li>
            )}
      </ol>
    </div>
  );
};
export default Practitioner;
