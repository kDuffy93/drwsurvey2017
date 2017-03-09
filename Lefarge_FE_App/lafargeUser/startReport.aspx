<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="startReport.aspx.cs" Inherits="Lefarge_FE_App.startReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="well">       
           <div>
               <asp:Label runat="server" Text="which plant is the piece of equipment located at which you want results for?" />
               <asp:DropDownList ID="ddlPlant" DataTextField="Plant_Name" DataValueField="Plant_ID" runat="server"/>
           </div>
           
        <asp:Button runat="server" text="Submit" ID="btnSubmit" OnClick="btnSubmit_OnClick" CssClass="btn btn-primary"/>       
    </div>

</asp:Content>
