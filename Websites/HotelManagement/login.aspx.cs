using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    int uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Response.Redirect("default.aspx");
        }

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        ControlProxy.ControlSoapClient cp = new ControlProxy.ControlSoapClient();
        uid = cp.auth(TextBox1.Text, TextBox2.Text);
        if (uid == -99)
        {
            Label2.Text = "Username or Password is incorrect!";
        }
        else
        {
            ArrayList roomlist=new ArrayList();
            ArrayList halllist=new ArrayList();
            Session["user"] = uid;
            Session["rooms"] = roomlist;
            Session["halls"] = halllist;
            Response.Redirect("default.aspx");
        }
    }
}