<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterData.aspx.cs" Inherits="Administration_MasterData" %>

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
            <a href="EventUpdate.aspx">EventUpdate</a>
            <a href="QuestionAnswer.aspx">Enquiry</a>
            <a href="../Default.aspx">Logout</a>
            <a href="#">contact</a>
      </div>
                  <div class="contentTitle"><h1>Perform opertation ?</h1></div>
                <div class="contentText">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="BtnSyllabus" runat="server" Text="Syllabus" 
                                    onclick="BtnSyllabus_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnCalender" runat="server" Text="Calender" 
                                    onclick="BtnCalender_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnAdmission" runat="server" Text="Admission" 
                                    onclick="BtnAdmission_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnFees" runat="server" Text="Fees Structure" 
                                    onclick="BtnFees_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
        <asp:Panel ID="PnlSyllabus" runat="server" Visible="false">
                <div class="contentTitle"><h1>Upload Syllabus ?</h1></div>
                <div class="contentText">
                    <asp:FileUpload ID="FUSyllabus" runat="server" /> 
                    <asp:Button ID="BtnSyllabusUpload" runat="server" Text="Upload" 
                        onclick="BtnSyllabusUpload_Click" />
                             <hr />
                                        <asp:GridView ID="GvSyllabus" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewSyllabus" runat="server" Text="View" OnClick="ViewSyllabus" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbed" runat="server" />
                                        </div>
                </div>
        </asp:Panel>
        <asp:Panel ID="PnlCalender" runat="server" Visible="false">
                 <div class="contentTitle"><h1>Upload Calender !</h1></div>
        <div class="contentText">
          <asp:FileUpload ID="FUCalender" runat="server" /> 
                    <asp:Button ID="BtnCalenderUpload" runat="server" Text="Upload" 
                onclick="BtnCalenderUpload_Click" />


                                          <hr />
                                        <asp:GridView ID="GvCalender" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewCalender" runat="server" Text="View" OnClick="ViewCalender" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbed1" runat="server" />
                                        </div>
        </div>
        </asp:Panel>
        <asp:Panel ID="PnlAdmissionPnl" runat="server" Visible="false">
                <div class="contentTitle"><h1>Upload Admission Form</h1></div>
                <div class="contentText">
                    <asp:FileUpload ID="FUAdmission" runat="server" /> 
                    <asp:Button ID="BtnAdmissionFrmUpload" runat="server" Text="Upload" 
                        onclick="BtnAdmissionFrmUpload_Click" />

                               <hr />
                                        <asp:GridView ID="GvAdmissionFrm" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewAmission" runat="server" Text="View" OnClick="ViewAdmission" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbed2" runat="server" />
                                        </div>
                </div>  
        </asp:Panel>
        <asp:Panel ID="PnlCollegeFees" runat="server" Visible= "false">
                <div class="contentTitle"><h1>Upload College Fees</h1></div>
                <div class="contentText">
                    <asp:FileUpload ID="FUFees" runat="server" /> 
                    <asp:Button ID="BtnFeesUpload" runat="server" Text="Upload" 
                        onclick="BtnFeesUpload_Click" />

                                        <hr />
                                        <asp:GridView ID="GvFees" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewFees" runat="server" Text="View" OnClick="ViewFeesstructure" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbed3" runat="server" />
                                        </div>

                </div>  
        </asp:Panel>
</div>
        <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a></div>
    </form>
</body>
</html>
