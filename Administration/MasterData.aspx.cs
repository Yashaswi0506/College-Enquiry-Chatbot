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

public partial class Administration_MasterData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            BindSyllabusGrid();
            BindCalenderGrid();
            BindAdmissionGrid();
            BindFeesGrid();
        }
    }
    private void BindSyllabusGrid()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Tbl_Syllabus";
                cmd.Connection = con;
                con.Open();
                GvSyllabus.DataSource = cmd.ExecuteReader();
                GvSyllabus.DataBind();
                con.Close();
            }
        }
    }
    private void BindCalenderGrid()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Tbl_Calender";
                cmd.Connection = con;
                con.Open();
                GvCalender.DataSource = cmd.ExecuteReader();
                GvCalender.DataBind();
                con.Close();
                
            }
        }
    }
    private void BindAdmissionGrid()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Tbl_Admission";
                cmd.Connection = con;
                con.Open();
                GvAdmissionFrm.DataSource = cmd.ExecuteReader();
                GvAdmissionFrm.DataBind();
                con.Close();

            }
        }
    }
    private void BindFeesGrid()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Tbl_Fees";
                cmd.Connection = con;
                con.Open();
                GvFees.DataSource = cmd.ExecuteReader();
                GvFees.DataBind();
                con.Close();
                
            }
        }
    }
    protected void BtnSyllabusUpload_Click(object sender, EventArgs e)
    {

        string filename = Path.GetFileName(FUSyllabus.PostedFile.FileName);
        string contentType = FUSyllabus.PostedFile.ContentType;
        using (Stream fs = FUSyllabus.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
                {
                    string query = "insert into Tbl_Syllabus values (@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void BtnCalenderUpload_Click(object sender, EventArgs e)
    {

        string filename = Path.GetFileName(FUCalender.PostedFile.FileName);
        string contentType = FUCalender.PostedFile.ContentType;
        using (Stream fs = FUCalender.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
                {
                    string query = "insert into Tbl_Calender values (@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void BtnAdmissionFrmUpload_Click(object sender, EventArgs e)
    {

        string filename = Path.GetFileName(FUAdmission.PostedFile.FileName);
        string contentType = FUAdmission.PostedFile.ContentType;
        using (Stream fs = FUAdmission.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
                {
                    string query = "insert into Tbl_Admission values (@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void BtnFeesUpload_Click(object sender, EventArgs e)
    {

        string filename = Path.GetFileName(FUFees.PostedFile.FileName);
        string contentType = FUFees.PostedFile.ContentType;
        using (Stream fs = FUFees.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
                {
                    string query = "insert into Tbl_Fees values (@Name, @ContentType, @Data)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void ViewSyllabus(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbed.Text = string.Format(embed, ResolveUrl("~/Syllabus.ashx?Id="), id);
    }
    protected void ViewCalender(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbed1.Text = string.Format(embed, ResolveUrl("~/Calender.ashx?Id="), id);
    }
    protected void ViewAdmission(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbed2.Text = string.Format(embed, ResolveUrl("~/Admission.ashx?Id="), id);
    }
    protected void ViewFeesstructure(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        ltEmbed3.Text = string.Format(embed, ResolveUrl("~/Fees.ashx?Id="), id);
    }
    protected void BtnSyllabus_Click(object sender, EventArgs e)
    {
        PnlSyllabus.Visible=true;
        PnlCalender.Visible=false;
        PnlAdmissionPnl.Visible=false;
        PnlCollegeFees.Visible=false;
    }
    protected void BtnCalender_Click(object sender, EventArgs e)
    {
        PnlSyllabus.Visible = false;
        PnlCalender.Visible = true; 
        PnlAdmissionPnl.Visible = false;
        PnlCollegeFees.Visible = false;
    }
    protected void BtnAdmission_Click(object sender, EventArgs e)
    {
        PnlSyllabus.Visible = false;
        PnlCalender.Visible = false;
        PnlAdmissionPnl.Visible = true; 
        PnlCollegeFees.Visible = false;
    }
    protected void BtnFees_Click(object sender, EventArgs e)
    {
        PnlSyllabus.Visible = false;
        PnlCalender.Visible = false;
        PnlAdmissionPnl.Visible = false;
        PnlCollegeFees.Visible = true; 
    }
}