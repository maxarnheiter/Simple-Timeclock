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

        public ClockStatus status;

        public string employeeName;

        public ClockAction()
        {
        }

        public ClockAction(DateTime clockTime, ClockStatus clockStatus, string empName)
        {
            time = clockTime;
            status = clockStatus;
            employeeName = empName;
        }

    }
}
