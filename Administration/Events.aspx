<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Administration_Events" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../style.css" />
<title>MasterData :: ChatBot</title>

    <style type="text/css">
        .style1
        {
            color: #000000;
            font-weight: bold;
        }
        .style2
        {
            width: 300px;
        }
    </style>

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
            <a href="RegisterLogin.aspx">Register/Login</a>&nbsp;
            <a href="Events.aspx">Events</a>
            <a href="Inquiry.aspx">Enquiry</a>&nbsp;&nbsp;
            


      </div>
          <asp:Panel ID="Panel1" runat="server">
          <div class="contentTitle"><h1>Register to get Recent Updates</h1></div>
                <div class="contentText">
                    
              </div>

                    <table>
                    <tr>
                        <td >
                        Name:-
                        </td>
                        <td class="style2">
                         <asp:TextBox ID="TxtName" runat="server"  Width="300px"></asp:TextBox>
 
                            </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Email:-
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="TxtEmail" runat="server"  Width="300px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
              ErrorMessage="*" ControlToValidate="txtEmail"
                  ValidationGroup="vgSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
              runat="server" ErrorMessage="Please Enter Valid Email ID"
                  ValidationGroup="vgSubmit" ControlToValidate="txtEmail"
                  CssClass="requiredFieldValidateStyle"
                  ForeColor="Red"
                  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                  </asp:RegularExpressionValidator>
                    
                        </td>
                    </tr>
                        
                    <tr>
                    <td>
                    <asp:Button ID="Submit" runat="server" Text="Button" onclick="Submit_Click" 
                            Width="128px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    </tr>
                        
                    <tr>
                    <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        
                    <td>
                    <asp:Label ID="LblStatus" runat="server"></asp:Label>
                    </td>
                    </tr>
                   
                        </table>






          </asp:Panel>
      
    
         </div>
         
    <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a></div>
    </form>
</body>
</html>
