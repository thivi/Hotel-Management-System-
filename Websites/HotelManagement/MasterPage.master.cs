using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    HotelManDBDataContext db = new HotelManDBDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["user"] == null)
        {
            LinkButton7.Enabled = true;
            LinkButton7.Visible = true;
            LinkButton8.Visible = true;
            login.Visible = true;
            Label1.Enabled = false;
            Label1.Visible = false;
            LinkButton4.Visible = false;
            Label2.Visible = false;
            notify.Visible = false;
            logout.Visible = false;
            useredit.Visible = false;
        }
        else
        {
            Customer c = db.Customers.Single(cu => cu.CustomerID== Int32.Parse(Session["user"].ToString()));
            LinkButton7.Enabled = false;
            LinkButton8.Visible = false;
            login.Visible = false;
            useredit.Visible = true;
            LinkButton7.Visible = false;
            Label1.Text = c.FirstName + " " + c.LastName;
            LinkButton4.Visible = true;

            ArrayList ls = (ArrayList)Session["rooms"];
            ArrayList hl = (ArrayList)Session["halls"];
            if (ls.Count == 0 && hl.Count==0)
            {
                Label2.Visible = false;
                notify.Visible = false;
            }
            else
            {
                Label2.Visible = true;
                notify.Visible = true;
                Label2.Text = (ls.Count+hl.Count).ToString();
            }

        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookaroom.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookahall.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("default.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Response.Redirect("cart.aspx");
        }
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("registerusers.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("editusers.aspx");
    }
}
