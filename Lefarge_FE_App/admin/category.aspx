<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="Lefarge_FE_App.category" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categories</h1>
    
    <h5>Add a new Equipment Category</h5>

    <div class="form-group">
        <label for="txtCategory" class="col-sm-3">Category:</label>
        <asp:TextBox ID="txtCategory" runat="server" required="true" MaxLength="25" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Category is required" CssClass="alert alert-danger" ControlToValidate="txtCategory"></asp:RequiredFieldValidator>
    </div>
    
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_OnClick" CssClass="btn btn-primary"
             />
    </div>
</asp:Content>
