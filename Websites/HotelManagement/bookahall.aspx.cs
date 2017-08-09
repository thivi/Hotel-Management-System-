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
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(TextBox2.Text) < DateTime.Today)
        {
            Label6.Text = "Date cannot be less than today's date!";
            Label6.ForeColor = System.Drawing.Color.DarkRed;
        }
        else
        {
            if (Button1.Text != "Book")
            {
                ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
                if (cp.hallavail(Convert.ToDateTime(TextBox2.Text), DropDownList1.SelectedValue.ToString()))
                {
                    Label6.Text = "Hall Available";
                    Button1.Text = "Book";
                    Label6.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label6.Text = "Hall Not Available!";
                    Label6.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else
            {
                if (Session["user"] == null)
                {
                    Label6.Text = "Please login to book a hall!";
                    Label6.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    HotelManDBDataContext db = new HotelManDBDataContext();
                    int hallid = -99;
                    double pricet = 0;
                    double pricep = 0;

                    var hall = from hallss in db.Halls select hallss;
                    var booked = from h in db.HallBookings select h;
                    var match = from h in db.HallBookings where h.BookTime != DropDownList1.SelectedValue.ToString() where h.BookDate != Convert.ToDateTime(TextBox2.Text) select h;
                    bool found = false;
                    ArrayList hallslist = (ArrayList)Session["halls"];
                    bool existhall = false;
                    int i = 0;
                    foreach (var h in hall)
                    {
                        existhall = false;
                        foreach (hallClass ha in hallslist)
                        {
                            if (ha.hid == h.HallID && ha.time == DropDownList1.SelectedValue.ToString() && Convert.ToDateTime(TextBox2.Text) == ha.day)
                            {
                                existhall = true;
                                break;
                            }

                        }
                        if (existhall)
                        {
                            continue;
                        }
                        if (booked.Count() == 0)
                        {
                            hallid = h.HallID;
                            pricep = (double)h.PricePerPerson;
                            if (DropDownList1.SelectedValue.ToString() == "Morning")
                            {
                                pricet = (double)h.PriceMorn;
                            }
                            else if (DropDownList1.SelectedValue.ToString() == "Evening")
                            {
                                pricet = (double)h.PriceEven;
                            }
                            else
                            {
                                pricet = (double)h.PriceNight;
                            }
                            break;
                        }
                        if (match.Count() ==0)
                        {
                            hallid = h.HallID;
                            pricep = (double)h.PricePerPerson;
                            if (DropDownList1.SelectedValue.ToString() == "Morning")
                            {
                                pricet = (double)h.PriceMorn;
                            }
                            else if (DropDownList1.SelectedValue.ToString() == "Evening")
                            {
                                pricet = (double)h.PriceEven;
                            }
                            else
                            {
                                pricet = (double)h.PriceNight;
                            }
                            break;
                        }
                        foreach (var ma in match)
                        {
                            if (h.HallID == ma.HallID)
                            {
                                hallid = h.HallID;
                                pricep = (double)h.PricePerPerson;
                                if (DropDownList1.SelectedValue.ToString() == "Morning")
                                {
                                    pricet = (double)h.PriceMorn;
                                }
                                else if (DropDownList1.SelectedValue.ToString() == "Evening")
                                {
                                    pricet = (double)h.PriceEven;
                                }
                                else
                                {
                                    pricet = (double)h.PriceNight;
                                }
                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            break;
                        }

                    }
                    if (hallid == -99)
                    {
                        Label6.Text = "All the available halls have been reserved. Try again in a few hours to see if anyone of them has been cancelled!";
                        Label6.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        double function;



                        FunctionPack f = db.FunctionPacks.Single(c => c.FunctionName == DropDownList2.SelectedValue.ToString());
                        function = (double)f.Price;
                        int functionid = f.FuncID;
                        double meal;
                        MealPackage m = db.MealPackages.Single(c => c.MealName == DropDownList3.SelectedValue.ToString());
                        meal = (double)m.UnitPrice;
                        int mid = m.MealID;

                        int noofp = Convert.ToInt32(TextBox1.Text);
                        double tot = (meal * noofp) + (pricep * noofp) + function + pricet;

                        Hall halls = db.Halls.Single(ca => ca.HallID == hallid);
                        string halln = halls.HallNo;
                        ArrayList list = (ArrayList)Session["halls"];

                        list.Add(new hallClass { no = noofp, day = Convert.ToDateTime(TextBox2.Text).Date, fid = functionid, functiontype = DropDownList2.SelectedValue.ToString(), hid = hallid, mealid = mid, mealtype = DropDownList3.SelectedValue.ToString(), time = DropDownList1.SelectedValue.ToString(), hallno = halln, totcost = tot });
                        Session["halls"] = list;
                        Response.Redirect("cart.aspx");
                    }
                }
            }
        }
    }
}