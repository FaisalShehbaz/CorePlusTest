export interface IUser {
    id: number;
    name: string;
  }


export interface IDateRangePickerData{
  selection:{
    startDate:Date;
    endDate: Date;
    key: "selection";
  }
}

export interface IFinancialSummaryReport{
  practitionerName: string,
  monthName: number,
  month: number,
  revenue: number,
  cost: number
}

export interface IFinancialDetailReport{
  practitionerid: number,
  date: string,
  practitionername: string,
  clientName: string,
  appointmentType: string,
  duration: number,
  revenue: number,
  cost: number
}