<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="equipmentList.aspx.cs" Inherits="Lefarge_FE_App.equipmentList" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Equipment List</h1>

     <asp:Button ID="btnNewEquipment" Text="Add a new Equipment" PostBackUrl="~/admin/equipment.aspx" runat="server" />

    <asp:GridView ID="grdEquipment" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="False" OnRowDeleting="grdEquipment_OnRowDeleting"
        DataKeyNames="Equipment_ID" OnDataBound="grdEquipment_OnDataBound">
        <Columns>        
            <asp:BoundField DataField="Unit_Number" HeaderText="Unit_Number"/>
            <asp:BoundField DataField="Name" HeaderText="Name"/>
            <asp:BoundField DataField="Description1" HeaderText="Description"/>
            <asp:BoundField DataField="Num_Of_Belts" HeaderText="Number Of Belts"/>
            <asp:BoundField DataField="Belt_Type" HeaderText="Belt Type"/>
            <asp:BoundField DataField="Category_ID" HeaderText="Category"/>
            <asp:BoundField   DataField="Plant_ID"  HeaderText="Plant"/>
            <asp:HyperLinkField HeaderText="Edit"  NavigateUrl="../admin/equipment.aspx"
                 Text="Edit" DataNavigateUrlFields="Equipment_ID"
                 DataNavigateUrlFormatString="../admin/equipment.aspx?Equipment_ID={0}" />
            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>

