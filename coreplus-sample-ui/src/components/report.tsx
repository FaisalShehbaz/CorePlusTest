import React, { useState, useEffect } from "react";
import { variables } from '../constants/variables';
import { IUser,IDateRangePickerData,IFinancialSummaryReport,IFinancialDetailReport } from "./interface";
import FinancialSummaryReport from "./financialSummaryReport";
import FinancialDetailReport from "./financialDetailReport";
import { DateRangePicker } from "react-date-range";
import { addDays, subDays } from "date-fns";
import 'react-date-range/dist/styles.css'; // main style file
import 'react-date-range/dist/theme/default.css'; // theme css file

interface IProps {
   practitioner: IUser;
 }

const Report: React.FunctionComponent<IProps> = props => {
    
    const [financialSummaryReport, setFinancialSummaryReport] = useState([]);
    const [financialDetailReport, setFinancialDetailReport] = useState([]);
    const [dateRangePickerState, setDateRangePickerState] = useState([
        {
          startDate: subDays(new Date(), 1095),
          endDate: addDays(new Date(), 1),
          key: "selection"
        }]);
      const handleOnChange = (ranges:IDateRangePickerData) => {
        const { selection } = ranges;
        if(ranges.selection.startDate && ranges.selection.endDate){
            fetch(variables.API_URL + `financialSummaryReport?practitionerId=${props.practitioner.id}&startDate=${ new Date(ranges.selection.startDate).toISOString().split('T')[0] }&endDate=${ new Date(ranges.selection.endDate).toISOString().split('T')[0]}`)
            .then(response => response.json())
            .then(data => {
               setFinancialSummaryReport(data);
            });
        }
        setDateRangePickerState([selection]);
      };

      const handleOnGetDetials = (filter:IFinancialSummaryReport) =>{
          fetch(variables.API_URL + `financialDetailReport?practitionerId=${props.practitioner.id}&month=${filter.month}&startDate=${ new Date(dateRangePickerState[0].startDate).toISOString().split('T')[0] }&endDate=${ new Date(dateRangePickerState[0].endDate).toISOString().split('T')[0]}`)
          .then(response => response.json())
          .then(data => {
            setFinancialDetailReport(data);
          });
      }

  return (
    <div>
        <h3 className="p-2 shadow-sm">
             {props.practitioner.name}
        </h3>
        <div>
          <div className="text-black p-2">
            <DateRangePicker
              onChange={handleOnChange}
              showSelectionPreview={true}
              moveRangeOnFirstSelection={false}
              months={1}
              ranges={dateRangePickerState}
              direction="horizontal"
              />
          </div>
          
          <div className="">
            {
              financialSummaryReport.length > 0 ?
              <FinancialSummaryReport data={financialSummaryReport} onGetDetials={handleOnGetDetials} /> : ""
            }
          </div>
          <div className="">
            {
              financialDetailReport.length > 0 ?
              <FinancialDetailReport data={financialDetailReport} /> : ""
            }
          </div>

        </div>
       
       
    </div> 
  );
};
export default Report;