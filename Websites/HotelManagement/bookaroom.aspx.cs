using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(TextBox1.Text) >= Convert.ToDateTime(checkout.Text))
        {
            Label1.Text = "Check in date cannot be greater than or equal to the Check out date";
            Label1.ForeColor = System.Drawing.Color.DarkRed;
        }
        else if (Convert.ToDateTime(TextBox1.Text) < DateTime.Today)
        {
            Label1.Text = "Check in date cannot be less than today's date!";
            Label1.ForeColor = System.Drawing.Color.DarkRed;
        }
        else
        {
            if (Button1.Text != "Book")
            {
                ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
                if (cp.bookroomavail(type.SelectedValue.ToString(), Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(checkout.Text)))
                {
                    Label1.Text = "Room Available!";
                    Button1.Text = "Book";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    Label1.Text = "Room Not Available!";
                    Label1.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                if (Session["user"] == null)
                {
                    Label1.Text = "Please login to book a room!";
                    Label1.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    HotelManDBDataContext db = new HotelManDBDataContext();
                    var all = from room in db.RoomBookings select room;
                    var ta = from room in db.RoomBookings where Convert.ToDateTime(TextBox1.Text) < room.BookFrom where Convert.ToDateTime(checkout.Text) < room.BookTo select room;
                    var tb = from room in db.RoomBookings where Convert.ToDateTime(TextBox1.Text) > room.BookFrom where Convert.ToDateTime(checkout.Text) > room.BookTo select room;

                    ta.Concat(tb);

                    var tb2 = from room in db.Rooms where room.RoomType == type.SelectedValue.ToString() select room;
                    int rid = -99;
                    string roomno = null;
                    double cost = 0;
                    double tot = 0;
                    ArrayList rooml = (ArrayList)Session["rooms"];
                    bool booked = false;
                    int i = 0;
                    foreach (var b in tb2)
                    {
                        booked = false;
                        foreach (roomClass r in rooml)
                        {

                            if (r.roomid == b.RoomID)
                            {

                                booked = true;
                                break;
                            }
                        }
                        if (booked)
                        {
                            continue;
                        }
                        if (all.Count() == 0)
                        {
                            rid = b.RoomID;
                            roomno = b.RoomNo;
                            cost = (double)b.Price;
                            break;
                        }
                        foreach (var a in all)
                        {
                            if (a.RoomID == b.RoomID)
                            {
                                foreach (var t in ta)
                                {
                                    if (b.RoomID == t.RoomID)
                                    {
                                        rid = b.RoomID;
                                        roomno = b.RoomNo;
                                        cost = (double)b.Price;
                                        break;
                                    }
                                }
                                if (roomno != null)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                rid = b.RoomID;
                                roomno = b.RoomNo;
                                cost = (double)b.Price;
                                break;
                            }

                        }

                        if (roomno != null)
                        {
                            break;
                        }

                    }
                    if (rid == -99)
                    {
                        Label1.Text = "All rooms have been reserved. Please check again to see if any one them has been cancelled!";
                        Label1.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        DateTime checkin = Convert.ToDateTime(TextBox1.Text);
                        DateTime checkoutd = Convert.ToDateTime(checkout.Text);
                        TimeSpan days = checkoutd.Subtract(checkin);
                        tot = cost * days.TotalDays;


                        ArrayList roomlist = (ArrayList)Session["rooms"];



                        roomlist.Add(new roomClass { roomtype = type.SelectedValue.ToString(), checkin = Convert.ToDateTime(TextBox1.Text).Date, checkout = Convert.ToDateTime(checkout.Text).Date, noguests = Convert.ToInt32(guests.Text), roomid = rid, rno = roomno, cost = tot });
                        Session["rooms"] = roomlist;


                        Response.Redirect("cart.aspx");
                    }



                }
            }
        }
        
    }
}