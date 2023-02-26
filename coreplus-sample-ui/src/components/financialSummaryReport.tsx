import React from "react";
import { IUser,IFinancialSummaryReport } from "./interface";

interface IProps {
   data: Array<IFinancialSummaryReport>;
   onGetDetials: (data: IFinancialSummaryReport) => void;
}

const FinancialSummaryReport: React.FunctionComponent<IProps> = props => {
  return (
    <div className="user-table">
    <h2 className="p-2">Financial Summary Report</h2>
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Month</th>
          <th>Revenue</th>
          <th>Cost</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {props.data.length > 0 ? (
          props.data.map(i => (
            <tr key={i.month}>
              <td>{i.practitionerName}</td>
              <td>{i.monthName}</td>
              <td>{i.revenue}</td>
              <td>{i.cost}</td>
              <td>
                <button onClick={() => props.onGetDetials(i)}>Details</button>
              </td>
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan={3}>no report data found.</td>
          </tr>
        )}
      </tbody>
    </table>
  </div>
  );
};
export default FinancialSummaryReport;

