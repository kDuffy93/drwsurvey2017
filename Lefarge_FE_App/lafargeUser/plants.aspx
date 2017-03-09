<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="plants.aspx.cs" Inherits="Lefarge_FE_App.listPlants" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Plants</h1>

     <asp:Button PostBackUrl="~/admin/plant.aspx" ID="btnNewPlant" Text="Add a new Plant" runat="server" />

    <asp:GridView ID="grdPlants" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdPlants_RowDeleting"
        DataKeyNames="Plant_ID">
        <Columns>        
            <asp:BoundField DataField="Plant_ID" HeaderText="ID" />
            <asp:BoundField DataField="Plant_Name" HeaderText="Plant Name" />
            <asp:BoundField DataField="Address" HeaderText="Address"/>
            <asp:BoundField DataField="Phone_Num" HeaderText="PhoneNum"/>
            <asp:BoundField DataField="Postal_Code" HeaderText="Postal Code"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="../admin/plant.aspx" 
                 Text="Edit" DataNavigateUrlFields="Plant_ID"
                 DataNavigateUrlFormatString="../admin/plant.aspx?Plant_ID={0}" />
            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
