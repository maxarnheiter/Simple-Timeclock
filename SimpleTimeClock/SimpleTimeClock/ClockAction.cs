using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTimeClock
{
    public class ClockAction
    {
        public DateTime time;

        public ClockStatus clockStatus;

        public string employeeName;

        public int employeeId;

        public ClockAction()
        {
        }

        public ClockAction(DateTime time, ClockStatus clockStatus, string employeeName, int employeeId)
        {
            this.time = time;
            this.clockStatus = clockStatus;
            this.employeeName = employeeName;
            this.employeeId = employeeId;
        }

        public string Print()
        {
            return "  " + employeeName + " [id: " + employeeId + "] clocked " + clockStatus + " at " + time + "." + Environment.NewLine;
        }

    }
}
