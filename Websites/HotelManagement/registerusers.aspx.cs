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
        if (Session["user"] != null)
        {
            Response.Redirect("default.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
        if (!cp.username(TextBox5.Text))
        {
            Label9.Text = "Username already exists!";
        }
        else
        {
            cp.saveReg(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, Convert.ToDateTime(TextBox8.Text), TextBox5.Text, TextBox6.Text );
            Response.Write("<script type=\"text/javascript\"> Registration successfull!</script>");
            Response.Redirect("login.aspx");
        }
    }
}