using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null || (Session["rooms"]==null && Session["halls"]==null))
        {
            Response.Redirect("default.aspx");
        }
        details.Text = "An advance of 15% of the total amount need to be paid. Your total amount is: " + Session["total"] + ". Your advance payment should be: " + Session["advance"] + ".";

    }

    protected void Unnamed11_Click(object sender, EventArgs e)
    {
        
        ArrayList hall = (ArrayList)Session["halls"];
        ArrayList room = (ArrayList)Session["rooms"];
        int uid = Convert.ToInt32(Session["user"]);
        double adv= Convert.ToDouble(Session["advance"]);
        double tot = Convert.ToDouble(Session["total"]);
        HotelManDBDataContext db = new HotelManDBDataContext();
        ArrayList roomid = new ArrayList();
        ArrayList hallid = new ArrayList();
        ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
        foreach (hallClass h in hall)
        { 

            hallid.Add(cp.hallb(h.hid, h.time, h.day, h.fid, h.no, uid, h.mealid));
        }

        foreach (roomClass rc in room)
        {
            roomid.Add(cp.roomb(rc.checkin, rc.checkout, uid, rc.noguests,  rc.roomid));
            
        }

       
       
        int abillid = cp.advb(uid, tot, adv); 

        foreach (int rbid in roomid)
        {
            AdvanceBillRoom abr = new AdvanceBillRoom();
            abr.BillID = abillid;
            abr.RoomBookingID = rbid;

            db.AdvanceBillRooms.InsertOnSubmit(abr);
            db.SubmitChanges();
        }

        foreach (int hbid in hallid)
        {
            AdvanceBillHall abh = new AdvanceBillHall();
            abh.BillID = abillid;
            abh.HallBookingID = hbid;

            db.AdvanceBillHalls.InsertOnSubmit(abh);
            db.SubmitChanges();
        }
        

        Response.Redirect("bill.aspx");

    }
}