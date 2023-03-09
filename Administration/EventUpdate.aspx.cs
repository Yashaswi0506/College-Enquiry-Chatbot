using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;


public partial class Administration_EventUpdate : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmail();
        }
       
    }

    private void BindEmail()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Db_ChatBot;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Email FROM Tbl_Evt";
                cmd.Connection = con;
                con.Open();
                GvMail.DataSource = cmd.ExecuteReader();
                GvMail.DataBind();
                con.Close();
            }
        }
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grow in GvMail.Rows)
        {
            string gMailAccount = "chatbot27@gmail.com";
            string to;
            string subject = "Event Notification";
            to = grow.Cells[0].Text.Trim();
            NetworkCredential loginInfo = new NetworkCredential(gMailAccount, "22222227");
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(gMailAccount);

            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = TxtEvent.Text.Trim();
            msg.IsBodyHtml = true;
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = loginInfo;
                client.Send(msg);
                Response.Write("<script>alert('Email Sent to User')<script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.Message + ")<script>");
            }
        }
    }
}