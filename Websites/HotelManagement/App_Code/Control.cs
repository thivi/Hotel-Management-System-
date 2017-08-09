using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Control
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Control : System.Web.Services.WebService
{
    HotelManDBDataContext db;
    public Control()
    {
        db = new HotelManDBDataContext();
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool bookroomavail(string roomtype, DateTime checkin, DateTime checkout)
    {
        var all = from room in db.RoomBookings select room;
        var ta = from room in db.RoomBookings where checkin < room.BookFrom where checkout < room.BookTo select room;
        var tb = from room in db.RoomBookings where checkin > room.BookFrom where checkout > room.BookTo select room;
        bool available = false;
        ta.Concat(tb);

        var tb2 = from rooms in db.Rooms where rooms.RoomType == roomtype select rooms;
        foreach (var b in tb2)
        {
            if (all.Count() == 0)
            {
                available = true;
                break;

            }
            else
            {
                foreach (var al in all)
                {
                    if (al.RoomID == b.RoomID)
                    {
                        foreach (var t in ta)
                        {
                            if (t.RoomID == b.RoomID)
                            {
                                available = true;
                                break;
                            }
                        }
                        if (available)
                        {
                            break;
                        }
                    }
                    else
                    {
                        available = true;
                        break;
                    }
                }

            }

            if (available)
            {
                break;
            }
        }

        return available;

    }

    [WebMethod]
    public int auth(string uname, string pwd)
    {
        var tb = from users in db.Customers where users.uname == uname where users.pwd == pwd select users;
        if (tb.Count() == 0)
        {
            return -99;
        }
        else
        {
            Customer c = tb.Single(cu => cu.uname == uname);
            int uid = c.CustomerID;
            return uid;
        }


    }

    [WebMethod]
    public bool hallavail(DateTime day, string time)
    {

        var book = from halls in db.HallBookings select halls;
        var bookd = from halls in db.HallBookings where halls.BookDate != day where halls.BookTime != time select halls;
        
        if (book.Count() == 0)
        {
            return true;//true
        }
        else {
            var hall = from halls in db.Halls select halls;
            bool allhall = true;
            foreach (var h in hall)
            {
                
                foreach(var b in book)
                {
                    
                    if (h.HallID != b.HallID)
                    {
                        
                        allhall = false;
                    }
                    else
                    {
                        allhall = true;
                        break;
                    }
                }
                if (allhall==false)
                {
                    return true;//true
                }
            }
            if (bookd.Count() == 0)
            {
                return false;//false
            }
            else
            {
                return true;//true
            }

        }

    }
    [WebMethod]
    public bool username(string unames)
    {
        var user = from users in db.Customers where users.uname == unames select users;
        if (user.Count() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    [WebMethod]
    public bool eusername(string unames, int uid)
    {
        var user = from users in db.Customers where users.uname == unames select users;
        if (user.Count() == 0)
        {
            return true;
        }
        else
        {
            var u = from users in db.Customers where users.CustomerID == uid select users;
            if (u.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

    [WebMethod]

    public void saveReg(string fname, string lname, string contact, string nic, DateTime dob, string uname, string pwd)
    {
        Customer c = new Customer();
        c.FirstName = fname;
        c.LastName = lname;
        c.ContactNo = contact;
        c.NICno = nic;
        c.DOB = dob;
        c.uname = uname;
        c.pwd = pwd;
        c.RegDate = DateTime.Today;

        db.Customers.InsertOnSubmit(c);

        db.SubmitChanges();
    }

  [WebMethod]
    public void editReg(int uid, string fname, string lname, string contact, string nic, DateTime dob, string uname)
    {
        Customer c = db.Customers.Single(n => n.CustomerID == uid);
       
        c.FirstName = fname;
        c.LastName = lname;
        c.ContactNo = contact;
        
        c.DOB = dob;
        
        if (c.uname == uname)
        {

        }
        else
        {
            c.uname = uname;
        }
        if (c.NICno == nic)
        {

        }
        else
        {
            c.NICno = nic;
        }
        

        

        db.SubmitChanges();
        
    }

    [WebMethod]
    public void editRegp(int uid, string fname, string lname, string contact, string nic, DateTime dob, string uname, string pwd)
    {
        Customer c = db.Customers.Single(n => n.CustomerID == uid);

        c.FirstName = fname;
        c.LastName = lname;
        c.ContactNo = contact;

        c.DOB = dob;

        if (c.uname == uname)
        {

        }
        else
        {
            c.uname = uname;
        }
        if (c.NICno == nic)
        {

        }
        else
        {
            c.NICno = nic;
        }
        
        c.pwd = pwd;


        db.SubmitChanges();
    }

    [WebMethod]
    public int hallb(int hid, string time, DateTime day, int fid, int no, int uid, int mealid)
    {
        HallBooking hb = new HallBooking();
        hb.HallID = hid;
        hb.BookTime = time;
        hb.BookDate = day;
        hb.FunctionPack = fid;
        hb.NoOfAtendees = no;
        hb.CustID = uid;
        hb.MealPackID = mealid;

        db.HallBookings.InsertOnSubmit(hb);
        db.SubmitChanges();
        return (hb.HallBookingID);
    }
    [WebMethod]
    public int roomb(DateTime checkin, DateTime checkout, int uid, int noguests, int roomid)
    {
        RoomBooking rb = new RoomBooking();
        rb.BookFrom = checkin;
        rb.BookTo = checkout;
        rb.CustID = uid;
        rb.NoPersons = noguests;
        rb.BookDate = DateTime.Today;
        rb.RoomID = roomid;

        db.RoomBookings.InsertOnSubmit(rb);
        db.SubmitChanges();
        return (rb.BookingID);
    }

    [WebMethod]

    public int advb(int uid, double tot, double adv)
    {
        AdvanceBill ab = new AdvanceBill();
        ab.BillDate = DateTime.Today;
        ab.CustID = uid;
        ab.TotalAmount = tot;
        ab.AdvanceAmount = adv;

        db.AdvanceBills.InsertOnSubmit(ab);
        db.SubmitChanges();
        return ab.BillID;
    }


}
