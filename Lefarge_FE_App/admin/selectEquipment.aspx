<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="selectEquipment.aspx.cs" Inherits="Lefarge_FE_App.survey" %>

    <asp:Content ID="cntMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well" style="width:748px; height:300px">
        <div style="float:left" >
        <div>
        <asp:Label runat="server">Selected Plant:</asp:Label>
        <asp:TextBox ID="txtPlant" style="text-align:center" runat="server" Enabled="false" Text="0" Width="250"></asp:TextBox>
            </div>
        <div>
        <asp:Label runat="server">Selected Category</asp:Label>
        <asp:TextBox ID="txtCategory" style="text-align:center" runat="server" Enabled="false" Text="0" Width="250" ></asp:TextBox>
            </div>
            </div>
        <div style="float:right; border-bottom:dotted; border-bottom-width:2px">
            <div style="vertical-align:top; padding-bottom:1em;">
                <asp:Label runat="server" Text="If you need to change the plant or category" Width="300"></asp:Label>
            </div>
            <div style="vertical-align:bottom; align-items:center">
                <asp:Button runat="server" PostBackUrl="~/admin/startSurvey.aspx" Width="70" Text="Go Back"/>
            </div>
        </div>
      
        <div style="float:right; padding-top:1em">
            <div style="vertical-align:top">
                <asp:Label runat="server" Text="Dont see the piece of Equipment in these selections? <br /> Why dont you add it by clicking the button below." Width="300"></asp:Label>
            </div>
            <div style=" vertical-align:top" >
                <asp:Button runat="server" PostBackUrl="~/admin/equipment.aspx" Text="Add New Equipment"/>
            </div>
            
        </div>
        </div>


        <div>
            <h2>Choose equipment to complete survey for:</h2>
        </div>
        
       
            <div class="well" style="width:748px">
              <asp:Panel ID="pnlButtons" runat="server"></asp:Panel>
               
            </div>
        
     
</asp:Content>
