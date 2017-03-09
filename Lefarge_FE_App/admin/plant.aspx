<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="plant.aspx.cs" Inherits="Lefarge_FE_App.addPlant" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Plant Details</h1>

    <h5>Plant Name and City are Required</h5>
     <h5>All other fields are optional</h5>

    <div class="form-group">
        <label for="txtPlantName" class="col-sm-3">Plant Name:</label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plant name is required" CssClass="alert alert-danger" ControlToValidate="txtPlantName" Display="Static"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtPlantName" runat="server" required="true" MaxLength="20" />
    </div>
    <div class="form-group">
        <label for="txtAddress" class="col-sm-3">Address:</label>
        <asp:TextBox ID="txtAddress" runat="server"  MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtPhoneNum" class="col-sm-3">Phone Number</label>
        <asp:TextBox ID="txtPhoneNum" runat="server"  MaxLength="15" />
        </div>
    <div class="form-group">
        <label for="txtPostalCode" class="col-sm-3">Polstal Code:</label>
        <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="7" />
    </div>
     <div class="form-group">
        <label for="txtCity" class="col-sm-3">City:</label>
        <asp:TextBox ID="txtCity" runat="server" required="true" MaxLength="7" />
    </div>

    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>
