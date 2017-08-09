using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    double tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"]==null)
        {
            Response.Redirect("default.aspx");
        }
        if (!Page.IsPostBack)
        {
            ArrayList roomlist = (ArrayList)Session["rooms"];
            Repeater1.DataSource = roomlist;
            Repeater1.DataBind();

            ArrayList halllist = (ArrayList)Session["halls"];
            Repeater2.DataSource = halllist;
            Repeater2.DataBind();
            


            if(roomlist.Count== 0 && halllist.Count == 0)
            {
                Label8.Text = "The cart is empty!";
                Button2.Visible = false;
            }
            else
            {
                
                foreach(roomClass r in roomlist)
                {
                    tot += r.cost;
                }
                foreach(hallClass h in halllist)
                {
                    tot += h.totcost;
                }
                Panel1.Visible=true;
                Label8.Text = "Total Amount: "+tot.ToString();
                Session["total"] = tot;
                //Response.Write(tot);
                double adv = (15 / 100.0) * tot;
                Session["advance"] = adv;
            }
            
        }
        
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cancel")
        {
            
            ArrayList roomlist = (ArrayList)Session["rooms"];
            roomlist.RemoveAt(e.Item.ItemIndex);
            Response.Redirect("cart.aspx");

        }
    }

    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cancel")
        {
            ArrayList halllist = (ArrayList)Session["halls"];
            halllist.RemoveAt(e.Item.ItemIndex);
            Response.Redirect("cart.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        
        
        Response.Redirect("payment.aspx");
    }
}