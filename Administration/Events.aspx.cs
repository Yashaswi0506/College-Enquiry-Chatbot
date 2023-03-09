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

public partial class Administration_Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"); 

    protected void Submit_Click(object sender, EventArgs e)
    {
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Tbl_Evt (Name,Email)" +
        "values(@name,@email)";
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TxtName.Text;
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TxtEmail.Text;

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            LblStatus.Text = "Registration Success";
            con.Close();
            //PnlRegister.Visible = false;
            //PnlLogin.Visible = true;
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