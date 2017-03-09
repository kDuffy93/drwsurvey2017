<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="Lefarge_FE_App.survey1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/lafargeStyle.css" rel="stylesheet" />
    <div id="pnlRefresh">
        
    </div>
    <div class="fixed-div" style="height:100px; width:250px;" > 
        
        <asp:Button  runat="server" data-icon="cameraButton"  text="Take Picture" ID="input2" Height="100px" CssClass="button" Width="249px"  />
        <asp:FileUpload runat="server" CssClass="hiddenUpload" ID="hidenPic"  accept="image/*" capture AllowMultiple="false"   />
       

    </div>
    <div class="well" style="width:768px; height:300px;">
        <div style="float:left">
        <div>
        <asp:Label runat="server">Selected Plant:</asp:Label>
        <asp:TextBox ID="txtPlant" runat="server" Enabled="false" Text="0"></asp:TextBox>
            </div>
        <div>
        <asp:Label runat="server">Selected Category</asp:Label>
        <asp:TextBox ID="txtCategory" runat="server" Enabled="false" Text="0"></asp:TextBox>
            </div>
         <div>
        <asp:Label runat="server">selected piece of equipment:</asp:Label>
        <asp:TextBox ID="txtEquipment" runat="server" Enabled="false" Text="0"></asp:TextBox>
            </div> 
            </div>
        <div style="float:right">
            <asp:Image ID="imgMain" runat="server"  Visible="false" Width="200" Height="200"/>
           
           <asp:FileUpload runat="server" ID="fuMain" Enabled="true" />
            <asp:Button runat="server" ID="btnUpload" text="Upload image"  OnClick="btnUpload_Click1" />
        </div>
      
        </div> 
     <asp:Button runat="server" Visible="false" text="Start a new survey" ID="btnNewSurvey" OnClick="btnNewSurvey_Click" CssClass="btn btn-primary"/>
    <div id="srvMain">
        <asp:Table id="tblSurvey"  CssClass="table table-striped"  CellPadding="5" CellSpacing="5"
        Gridlines="both" runat="server" border-right-width="1" EnableViewState="true">
            <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell width="175">Question</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="5">Yes/No</asp:TableHeaderCell>
                <asp:TableHeaderCell width="200">Describe Defeciency/defect</asp:TableHeaderCell>
                <asp:TableHeaderCell width="200">Corrective Action Plan</asp:TableHeaderCell>
                <asp:TableHeaderCell width="300">Upload Images</asp:TableHeaderCell>
            </asp:TableHeaderRow>
         </asp:Table>
    </div>
   
</asp:Content>
