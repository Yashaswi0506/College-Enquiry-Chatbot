<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterLogin.aspx.cs" Inherits="Administration_RegisterLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../style.css" />
<title>Register-Login :: ChatBot</title>
 <script language="javascript" type="text/javascript">

     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
             return false;

         return true;
     }
     function AllowAlphabet(e) {
         isIE = document.all ? 1 : 0
         keyEntry = !isIE ? e.which : event.keyCode;
         if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
             return true;
         else {
             alert('Please Enter Only Character values.');
             return false;
         }
     }
    
   </script>
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
            <a href="Events.aspx">Events</a>
            <a href="#">Calender</a>
            <a href="#">Admin</a>
            <a href="#">contact</a>
      </div>
        
            <asp:Panel ID="PnlRegister" runat="server" Visible="false">

            <div class="contentTitle"><h1>Register Your Self !&nbsp;
                <asp:Label ID="LblStatus" runat="server" ForeColor="#FF9900" Text="..."></asp:Label>
                </h1></div>
        <div class="contentText">
               <table>
                <tr>
                    <td> 
                        Full Name :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtFullName" runat="server" Width="300px" onkeypress="return AllowAlphabet(event)" ></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td> 
                        Mobile :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtMobile" runat="server" Width="300px" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> 
                        User Name :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtUserName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> 
                        Password :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtPassword" runat="server" Width="300px" TextMode="Password" ></asp:TextBox>
                    </td>
                </tr>

                    <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="ImgBtnCreateAcc" runat="server" Height="70px" 
                            ImageUrl="~/register_button.png" Width="419px" 
                            onclick="ImgBtnCreateAcc_Click" />
                    </td>
                </tr>
               </table>
               </div>
            </asp:Panel>
        
        
            <asp:Panel ID="PnlLogin" runat="server" Visible="false">

            <div class="contentTitle"><h1>Login Your Self !
                <asp:Label ID="LblStatus0" runat="server" ForeColor="#FF9900" Text="..."></asp:Label>
                </h1></div>
        <div class="contentText">

               <table>
                <tr>
                    <td> 
                        User Name :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtUName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> 
                        Password :- 
                    </td>
                    <td style="width:auto" >
                        <asp:TextBox ID="TxtPass" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:ImageButton ID="ImgBtnLoginHere" runat="server" Height="67px" 
                            ImageUrl="~/Login-button.png" Width="320px" 
                            onclick="ImgBtnLoginHere_Click" />
                    </td>
                </tr>
               </table>

               </div>
            </asp:Panel>
        
        <div class="contentTitle"><h1>Choose Option ?</h1></div>
        <div class="contentText">
            <asp:ImageButton ID="ImgBtnRegister" runat="server" Height="67px" 
                ImageUrl="~/register_button.png" Width="310px" 
                onclick="ImgBtnRegister_Click" />
            <asp:ImageButton ID="ImgBtnLogin" runat="server" Height="67px" 
                ImageUrl="~/Login-button.png" Width="320px" onclick="ImgBtnLogin_Click" />
            </div>  
</div>
        <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a></div>
    </form>
</body>
</html>
