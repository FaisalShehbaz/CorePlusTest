import React from "react";
import { IFinancialDetailReport } from "./interface";

interface IProps {
   data: Array<IFinancialDetailReport>;
}

const FinancialDetailReport: React.FunctionComponent<IProps> = props => {
  return (
    <div className="user-table">
    <h2 className="p-2 mt-5">Financial Detail Report</h2>
    <table>
      <thead>
        <tr>
          <th>Date</th>
          <th>Practitioner Name</th>
          <th>Client Name</th>
          <th>Appointment Type</th>
        </tr>
      </thead>
      <tbody>
        {props.data.length > 0 ? (
          props.data.map((i,index) => (
            <tr key={index}>
              <td>{i.date}</td>
              <td>{i.practitionername}</td>
              <td>{i.clientName}</td>
              <td>{i.appointmentType}</td>
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan={3}>No detial data found</td>
          </tr>
        )}
      </tbody>
    </table>
  </div>
  );
};
export default FinancialDetailReport;

