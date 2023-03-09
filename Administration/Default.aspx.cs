using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            if (Session["user"] == null)
            {
                Session["user"] = "Guest";
                LblUser.Text = "Welcome " + Session["user"];
            }
            else
            {
                LblUser.Text = "Welcome " + Session["user"];
            }
        }

    }
}