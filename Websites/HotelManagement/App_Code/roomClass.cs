using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for room
/// </summary>
public class roomClass
{
    public  string roomtype {get;set;}
    public DateTime checkin { get; set; }
    public DateTime checkout { get; set; }
    public int noguests { get; set; }

    public int roomid { get; set; }

    public string rno { get; set; }

    public double cost { get; set; }

    public roomClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}