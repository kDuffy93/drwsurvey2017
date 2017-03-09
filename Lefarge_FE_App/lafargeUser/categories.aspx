<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="Lefarge_FE_App.categories" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categories</h1>

    <asp:Button ID="btnNewCategory" PostBackUrl="~/admin/category.aspx" Text="Add a new Category" runat="server" />

    <asp:GridView ID="grdCategories" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdCategories_RowDeleting"
        DataKeyNames="Category_ID">
        <Columns>        
            <asp:BoundField DataField="Category_ID" HeaderText="ID" />
            <asp:BoundField DataField="Category1" HeaderText="Category" />
            
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="../admin/category.aspx" 
                 Text="Edit" DataNavigateUrlFields="Category_ID"
                 DataNavigateUrlFormatString="../admin/category.aspx?Category_ID={0}" />

            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />

        </Columns>

    </asp:GridView>

</asp:Content>
