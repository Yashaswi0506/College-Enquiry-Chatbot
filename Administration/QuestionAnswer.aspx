<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionAnswer.aspx.cs" Inherits="Administration_QuestionAnswer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../style.css" />
<title>MasterData :: ChatBot</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
        	<div id="headerTitle">ChatBot</div>
            <div id="headerSubText">Know your College...</div>
            
        </div>
        <div id="bar">
        	<a href="Default.aspx">home</a>
            <a href="RegisterLogin.aspx">Register/Login</a>&nbsp;
            <a href="EventUpdate.aspx">EventsUpdate</a>
            <a href="#">ENQUIRY</a>
            <a href="../Default.aspx">Logout</a>
            <a href="#">contact</a>
      </div>
                  <div class="contentTitle"><h1>Perform opertation ?</h1></div>
                <div class="contentText">
                   
                </div>
        <asp:Panel ID="PnlFAQ" runat="server" >
                <div class="contentTitle"><h1>Upload Question and Answer?</h1></div>
                <div class="contentText">
                <table>
                    <tr>
                        <td>
                            Question :-
                        </td>
                        <td>
                            <asp:TextBox ID="TxtQuestion" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            keywords :-
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Answer :-
                        </td>
                        <td>
                            <asp:TextBox ID="TxtAnswer" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" 
                                onclick="BtnSubmit_Click" />
&nbsp;

                            <asp:Button ID="BtnClear" runat="server" Text="Clear" 
                                onclick="BtnClear_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="LblStatus" runat="server" Text="..." ForeColor="#FF3300"></asp:Label>
                        </td>
                    </tr>
                </table>
                             <hr />
                    <asp:GridView ID="GvQuestionAnswer" runat="server">
                    </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbed" runat="server" />
                                        </div>
                </div>
        </asp:Panel>
</div>
        <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a></div>
    </form>
</body>
</html>
