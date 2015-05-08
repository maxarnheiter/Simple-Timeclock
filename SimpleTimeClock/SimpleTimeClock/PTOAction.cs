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

    public int employeeId;

    public int month;

    public int year;

    public string description;

    public PTOAction()
    {
    }

    public PTOAction(DateTime time, float PTOAmount, string employeeName, int employeeId, int month, int year, string description)
    {
        this.time = time;
        this.PTOAmount = PTOAmount;
        this.employeeName = employeeName;
        this.employeeId = employeeId;
        this.month = month;
        this.year = year;
        this.description = description;
    }

    public string Print()
    {
        return "  " + employeeName + " [id: " + employeeId + "]   PTO Amount: " + PTOAmount + " Month/Year: " + month + "/" + year + " Description: " + description + Environment.NewLine;
    }
}

