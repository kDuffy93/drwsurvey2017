<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Lefarge_FE_App._default1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server" ID="plhUser">
   <div class="well">
     <header>Home</header>
    <asp:TextBox runat="server" Enabled="false" ID="txtWelcome"></asp:TextBox>
           <p>Click on the <a  href="/admin/startSurvey.aspx">start survey</a> tab to get started on a new survey</p>

        <p>Or view reports with the <a  href="/lafargeUser/startReport.aspx">Generate Reports</a> tab.</p>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="plhMember">
   <div class="well">
     <header>Home</header>
    <asp:TextBox runat="server" Enabled="false" ID="txtWelcomeMember"></asp:TextBox>
        <p>You are able to view reports with the <a href="startReport.aspx">Generate Reports</a> tab.</p>
        </div>
    </asp:PlaceHolder>
</asp:Content>
