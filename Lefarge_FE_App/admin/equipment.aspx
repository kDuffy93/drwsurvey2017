<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="equipment.aspx.cs" Inherits="Lefarge_FE_App.equipment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Equipment Details</h1>

    

    <div class="form-group">
        <label for="txtUnitNumber" class="col-sm-3">Unit Number</label>
        <asp:TextBox ID="txtUnitNumber" runat="server" required="true" MaxLength="20" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please input a unit number" ControlToValidate="txtUnitNumber" CssClass="alert alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtName" class="col-sm-3">Name:</label>
        <asp:TextBox ID="txtName" runat="server"  MaxLength="50"  required="true"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Give this piece of equipment a name" ControlToValidate="txtName" CssClass="alert alert-danger" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtDescription1" class="col-sm-3">Description</label>
        <asp:TextBox ID="txtDescription1" runat="server"  MaxLength="15" />
        </div>
    <div class="form-group">
        <label for="txtNumOfBelts" class="col-sm-3">Number of Belts:</label>
        <asp:TextBox ID="txtNumOfBelts" runat="server" required="true" MaxLength="7" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Number of belts is Required" ControlToValidate="txtNumOfBelts" CssClass="alert alert-danger"  Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Number of belts must be a numeric value between 1 and 999" MaximumValue="999" MinimumValue="1"  ControlToValidate="txtNumOfBelts" CssClass="btn btn-xs btn-danger" Display="Dynamic"></asp:RangeValidator>
    </div>
     <div class="form-group">
        <label for="txtBeltType" class="col-sm-3">Belt Type:</label>
        <asp:TextBox ID="txtBeltType" runat="server" required="true" MaxLength="7" />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Belt type is required" ControlToValidate="txtBeltType" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    </div>
   
    <div class="form-group">
        
           <asp:Label runat="server" Text="Select which Plant you are at:" />
        <asp:DropDownList ID="ddlPlant" DataTextField="Plant_Name" DataValueField="Plant_ID" runat="server"/>
    </div> 
    
    <div class="form-group">
        
        <asp:Label runat="server" Text="Select which Category of equipment your doing the survey on" />
        <asp:DropDownList ID="ddlCategory" DataTextField="Category1" DataValueField="Category_ID" runat="server"/>
    </div>

    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"/>
    </div>
</asp:Content>