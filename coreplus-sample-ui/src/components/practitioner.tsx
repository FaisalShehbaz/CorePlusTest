import React from "react";
import { variables } from '../constants/variables';
import { IUser } from "./interface";
interface IProps {
  practitioner: Array<IUser>;
  onPractitionerClick: (user: IUser) => void;
 }

const Practitioner: React.FunctionComponent<IProps> = props => {
  return (
    <div className="praclist">Remaining Practitioners 
      <ol>
        {props.practitioner.length > 0 ? (
              props.practitioner.map(i => (
                <li>
                  <button onClick={() => props.onPractitionerClick(i)}>{i["name"]}</button>
                </li>
              ))
            ) : (
              <li> <a href="#" > no Practitioners found </a> </li>
            )}
      </ol>
    </div>
  );
};
export default Practitioner;
