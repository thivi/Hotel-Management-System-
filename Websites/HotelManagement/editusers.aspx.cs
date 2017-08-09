using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registerusers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Session["user"] != null)
            {
                HotelManDBDataContext db = new HotelManDBDataContext();
                Customer c = db.Customers.Single(n => n.CustomerID == Convert.ToInt32(Session["user"]));
                TextBox1.Text = c.FirstName;
                TextBox2.Text = c.LastName;
                TextBox3.Text = c.ContactNo;
                TextBox4.Text = c.NICno;
                TextBox8.Text = Convert.ToDateTime(c.DOB).Date.ToString("yyyy-MM-dd");
                
                TextBox5.Text = c.uname;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
        if (!cp.eusername(TextBox5.Text, Convert.ToInt32(Session["user"])))
        {
            Label9.Text = "Username already exists!";
        }
        else
        {
            if (TextBox6.Text == "")
            {
                
                cp.editReg(Convert.ToInt32(Session["user"]), TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, Convert.ToDateTime(TextBox8.Text), TextBox5.Text);
                    
            }
            else
            {
                cp.editRegp(Convert.ToInt32(Session["user"]),TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, Convert.ToDateTime(TextBox8.Text), TextBox5.Text, TextBox6.Text);
            }
                Response.Write("<script type=\"text/javascript\"> Registration successfull!</script>");
                Response.Redirect("login.aspx");
        }
        


    }
}