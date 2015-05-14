using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleTimeClock
{
    public class Exporter
    {

        public void Export(Company company, DateTime start, DateTime end)
        {

            //TODO redo all of this
            
        }

        

        

    }
}

/*
		public void Export(Company company, DateTime start, DateTime end)
        {


            int daysInPeriod = end.Subtract(start).Days;

            string output = "";

            output += Environment.NewLine;

            foreach (Employee employee in company.employees)
            {

                bool hasError = false;

                float amountWorkedForMonth = 0;

                output += "Printing records for " + employee.fullname + Environment.NewLine;

                for (int day = 1; day <= daysInPeriod; day++)
                {

                    List<ClockAction> dayClockActions = company.clockLog.Where(ca => ca.employeeId == employee.id
                                                                                && ca.time >= start
                                                                                && ca.time <= end).
                                                                                OrderBy(ca => ca.time).ToList();

                    if (dayClockActions != null && dayClockActions.Count > 0)
                    {
                        DateTime temp = new DateTime(year, month, day);

                        output += " " + temp.DayOfWeek + " " + day + "/" + month + "/" + year + Environment.NewLine;

                        foreach (ClockAction clockAction in dayClockActions)
                        {
                            output += clockAction.Print();
                        }

                        bool errorForDay = false;
                        float amountWorkedForDay = 0;

                        output += PrintHoursWorked(dayClockActions.ToArray(), out errorForDay, out amountWorkedForDay);

                        if (amountWorkedForDay > 0)
                            amountWorkedForMonth += amountWorkedForDay;

                        if (errorForDay)
                            hasError = true;

                    }
                }

                output += " Total hours worked for this month: " + amountWorkedForMonth;

                if (hasError)
                    output += " - NOTICE: Errors were reported. Total must be manually checked.";

                output += Environment.NewLine;

                List<PTOAction> ptoActions = company.ptoLog.Where(pa => pa.employeeId == employee.id
                                                                    && pa.year == year
                                                                    && pa.month == month).ToList();

                if (ptoActions != null && ptoActions.Count > 0)
                {
                    output += " Begin PTO Records:" + Environment.NewLine;

                    foreach (PTOAction ptoAction in ptoActions)
                    {
                        output += ptoAction.Print();
                    }

                    output += PrintPTOSummary(ptoActions.ToArray());
                }

                output += Environment.NewLine;

                Console.Write(output);

                //Mailer mailer = new Mailer(output, company.exportEmail);
            }
        }
		
		private string PrintHoursWorked(ClockAction[] dayClockActions, out bool hasError, out float totalHoursWorked)
        {
            totalHoursWorked = 0;

            if (dayClockActions.Length % 2 != 0)
            {
                hasError = true;
                return "  ERROR: Could not calculate hours worked, reason: uneven number of clock in/out events." + Environment.NewLine;

            }

            if (dayClockActions[0].clockStatus == ClockStatus.Out)
            {
                hasError = true;
                return "  ERROR: Could not calculate hours worked, reason: day started with clock out event." + Environment.NewLine;

            }

            int hoursWorked = 0;
            int minutesWorked = 0;

            for (int i = 0; i < dayClockActions.Length; i += 2)
            {
                hoursWorked += dayClockActions[i + 1].time.Subtract(dayClockActions[i].time).Hours;
                minutesWorked += dayClockActions[i + 1].time.Subtract(dayClockActions[i].time).Minutes;
            }

            totalHoursWorked = hoursWorked + ((float)minutesWorked / 60);
            hasError = false;
            return "   Total hours worked: " + totalHoursWorked + Environment.NewLine;
        }

        private string PrintPTOSummary(PTOAction[] ptoActions)
        {
            return "   PTO total for this month: " + ptoActions.Sum(pa => pa.PTOAmount) + Environment.NewLine;
        }
*/