using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PTOAction
{

    public  DateTime time;

    public float PTOAmount;

    public string employeeName;

    public float month;

    public float year;

    public string description;

    public PTOAction()
    {
    }

    public PTOAction(DateTime time, float PTOAmount, string employeeName, float month, float year, string description)
    {
        this.time = time;
        this.PTOAmount = PTOAmount;
        this.employeeName = employeeName;
        this.month = month;
        this.year = year;
        this.description = description;
    }
}

