using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for hallClass
/// </summary>
public class hallClass
{
    public int no { get; set; }
    public int mealid { get; set; }
    public double totcost { get; set; }

    public int fid { get; set; }

    public string mealtype { get; set; }

    public string functiontype { get; set; }

    public int hid { get; set; }
    public string hallno { get; set; }

    public DateTime day { get; set; }

    public string time { get; set; }



    public hallClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}