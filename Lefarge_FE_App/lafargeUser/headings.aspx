<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="headings.aspx.cs" Inherits="Lefarge_FE_App.headings" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Heading</h1>

  <asp:Button PostBackUrl="~/admin/heading.aspx" ID="btnNewHeading" Text="Add a new Heading" runat="server" />

    <asp:GridView ID="grdHeadings" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdHeadings_RowDeleting"
        DataKeyNames="Heading_ID">
        <Columns>   
            <asp:BoundField DataField="Heading_ID" HeaderText="ID" Visible="true" />  
            <asp:BoundField DataField="Heading1" HeaderText="Heading" />
              <asp:BoundField DataField="Categories_Under" HeaderText="Categories Under"/>
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="../admin/heading.aspx" 
                 Text="Edit" DataNavigateUrlFields="Heading_ID"
                 DataNavigateUrlFormatString="../admin/heading.aspx?Heading_ID={0}" />

            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />

        </Columns>

    </asp:GridView>

</asp:Content>
