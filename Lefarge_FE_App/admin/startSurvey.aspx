<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="startSurvey.aspx.cs" Inherits="Lefarge_FE_App.selectPlant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
     
           
       
            
  <div>
                <asp:Label runat="server" Text="Select which Plant you are at:" />
        <asp:DropDownList ID="ddlPlant" DataTextField="Plant_Name" DataValueField="Plant_ID" runat="server"/>
                    </div>
                
                <div>
                    
                      <asp:Label runat="server" Text="Select which Category of equipment your doing the survey on" />
        <asp:DropDownList ID="ddlCategory" DataTextField="Category1" DataValueField="Category_ID" runat="server"/>
                </div>
   <asp:Button runat="server" text="Submit" ID="btnSubmit" OnClick="btnSubmit_OnClick" CssClass="btn btn-primary"/>
                
          
            
            
             
    </div>

</asp:Content>
