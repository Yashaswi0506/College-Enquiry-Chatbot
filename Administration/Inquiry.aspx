<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Inquiry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="style.css" />
<title>Inquiry</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
        	<div id="headerTitle">ChatBot</div>
            <div id="headerSubText">Know your College...</div>
            
        </div>
        <div id="bar">
        	<a href="Default.aspx">Home</a>
            <a href="#">about</a>&nbsp;
            <a href="Administration/Events.aspx">Events</a>
            <a href="#">Calender</a>
            <a href="Administration/RegisterLogin.aspx">Admin</a>
            <a href="#">contact</a>
      </div>
        <div class="contentTitle"><h1>May I Help you ?</h1></div>
        <div class="contentText">
          <table>
          <tr>
          <td>CLEAR:-
          </td>
          <td>
          <asp:Button ID="BtnClear" runat="server" Text="Clear" onclick="BtnClear_Click" />
          </td>
          </tr>
              

            <tr>
                <td>
                    Ask me Anything :-
                </td>
                <td>
                    <asp:TextBox ID="TxtAskme" runat="server" Width="500px" Height="50px" 
                        ontextchanged="TxtAskme_TextChanged" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
            Search:-
            </td>
            <td>
                <asp:Button ID="BtnSearch" runat="server" Text="Button" 
                    onclick="BtnSearch_Click" />

            </td>
            </tr>
            

            <tr>
                <td>
                    
                    You know this :-
                </td>
                <td>
                    <asp:TextBox ID="TxtAnswer" runat="server" TextMode="MultiLine" Width="500px" 
                        Height="200px" ontextchanged="TxtAnswer_TextChanged"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    You know this :-
                </td>
                <td>
                  <asp:Button 
                ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Convert to Speech" Width="390px" />    
                </td>



          </table>
            <asp:Panel ID="PnlAnswer" runat="server">
                <asp:GridView ID="GvAnswer" runat="server">
                </asp:GridView>
            </asp:Panel>

             <hr />
            <asp:Panel ID="PnlCalender" runat="server" Visible="false">

                                        <hr />
                                        <asp:GridView ID="GVCalender" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkCalenderView" runat="server" Text="View" OnClick="CalenderView" OnClientClick="aspnetForm.target ='_blank';" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                          <div>
                                            <asp:Literal ID="ltEmbedCalender" runat="server" />
                                        </div>

            </asp:Panel>

                        <asp:Panel ID="PnlSyllabus" runat="server" Visible="false">

                                        <hr />
                                        <asp:GridView ID="GvSyllabus" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSyllabusView" runat="server" Text="View" OnClick="SyllabusView" OnClientClick="aspnetForm.target ='_blank';" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbedSyllabus" runat="server" />
                                        </div>
                    </asp:Panel>

                    <asp:Panel ID="PnlAdmission" runat="server" Visible="false">

                                        <hr />
                                        <asp:GridView ID="GvAdmission" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkAdmissionView" runat="server" Text="View" OnClick="AdmissionView" OnClientClick="aspnetForm.target ='_blank';" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbedAdmission" runat="server" />
                                        </div>
                    </asp:Panel>
                                        <asp:Panel ID="PnlFees" runat="server" Visible="false">

                                        <hr />
                                        <asp:GridView ID="GVFees" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkFeesView" runat="server" Text="View" OnClick="FeesView" OnClientClick="aspnetForm.target ='_blank';" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                        <div>
                                            <asp:Literal ID="ltEmbedFees" runat="server" />
                                        </div>
                    </asp:Panel>
        </div>
</div>


           
            















        <div id="footer"><a href="#">Idea Development</a> by <a href="#">Yashaswi Shah, Pratiksha Patni</a>
                </div>
    </form>
</body>
</html>