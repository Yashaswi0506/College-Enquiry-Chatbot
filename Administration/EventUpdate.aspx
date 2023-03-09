<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventUpdate.aspx.cs" Inherits="Administration_EventUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../style.css" />
<title>Know your College ChatBot</title>
</head>
<body>
    <form id="form1" runat="server">
     <div id="page">
        <div id="header">
        	<div id="headerTitle">ChatBot</div>
            <div id="headerSubText">Know your College...</div>
            
        </div>
        <div id="bar">
        	<a href="../Default.aspx">home</a>
            <a href="#">Register/Login</a>&nbsp;
            <a href="EventUpdate.aspx">EventsUpdate</a>&nbsp;
            <a href="#">Admin</a>
           
            <a href="../Default.aspx">Logout</a>
      </div>

             <div class="contentTitle"><h1>Welcome To MGMs 
            <asp:Label ID="LblUser" runat="server" ForeColor="#FF9900" Text="..."></asp:Label>
            </h1></div>
        <div class="contentText">
          <hr />
            <asp:Panel ID="PnlEvents" runat="server">
                <table> 
                <tr>
                    <td>
                        Enter Your Event Details :- 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEvent" runat="server" TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox>
                    </td>
                </tr>
                    <caption>
                        <hr />
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="BtnSend" runat="server" Height="30px" onclick="BtnSend_Click" 
                                    Text="Publish Event" Width="700px" />
                            </td>
                        </tr>
                    </caption>
                </table>
            </asp:Panel>           
            <hr />
            <br />
          
            <asp:GridView ID="GvMail" runat="server">
                
            </asp:GridView>
            <hr />
        </div>
        
        
        
</div>
        <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a></div>
    </form>
</body>
</html>
