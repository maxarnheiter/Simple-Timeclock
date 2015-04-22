using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleTimeClock
{
    public static class Dataset
    {

        public static Company company;

        public static List<Window> openWindows;

        static Dataset()
        {
            openWindows = new List<Window>();
        }

    }
}
