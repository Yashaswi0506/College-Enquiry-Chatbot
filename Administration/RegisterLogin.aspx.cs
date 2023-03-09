using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class Administration_RegisterLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"); 

    protected void ImgBtnRegister_Click(object sender, ImageClickEventArgs e)
    {
        PnlRegister.Visible=true;
        PnlLogin.Visible=false;
    }
    protected void ImgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        PnlRegister.Visible = false;
        PnlLogin.Visible = true;
    }
    protected void ImgBtnCreateAcc_Click(object sender, ImageClickEventArgs e)
    {
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Tbl_Register (Full_Name,Mobile,UName,Password)" +
        "values(@fname,@mobile,@uname,@password)";
        cmd.Parameters.Add("@fname", SqlDbType.VarChar, 50).Value = TxtFullName.Text;
        //cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TxtEmail.Text;
        cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 50).Value = TxtMobile.Text;
        cmd.Parameters.Add("@uname", SqlDbType.VarChar, 50).Value =TxtUserName.Text;
        cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = TxtPassword.Text;
        
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            LblStatus.Text = "Registration Success";
            con.Close();
            PnlRegister.Visible=false;
            PnlLogin.Visible=true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    protected void ImgBtnLoginHere_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataReader dr;
        try
        {
            con.Open();
            cmd = new SqlCommand("Select Password from Tbl_Register where UName='" + TxtUName.Text + "'", con);
            dr = cmd.ExecuteReader(); 
            if (!dr.Read()) 
            {

                LblStatus0.Text="Wrong User Name";
                TxtUName.Focus();
                TxtUName.Text = "";
                TxtPass.Text = "";
            }
            else
            {
                if (dr[0].ToString() == TxtPass.Text)
                {
                    Session["user"] = TxtUName.Text;
                    LblStatus0.Text="Login sucess";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    LblStatus0.Text="Wrong Password";
                    TxtPass.Text = "";
                    TxtPass.Focus();
                }
            }
            con.Close(); 
            dr.Close(); 
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}