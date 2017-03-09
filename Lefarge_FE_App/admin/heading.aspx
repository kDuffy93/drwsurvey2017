<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="heading.aspx.cs" Inherits="Lefarge_FE_App.heading" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Heading</h1>
    
    <h5>Add a heading to a category</h5>
    <h6>Both Required</h6>
    <div class="form-group">
        <label for="txtHeading" class="col-sm-3">Heading:</label>
        <asp:TextBox ID="txtHeading" runat="server" required="true" MaxLength="30" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This heading needs a name" ControlToValidate="txtHeading" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
    </div>
    
     <div class="form-group">
        
<label for="lbCategory" class="col-sm-3">Which categories does this heading fit into?</label>
               <asp:Panel ID="rbPanel" runat="server">
                   <asp:CheckBoxList runat="server" id="chklstCategories" data-role="controlgroup" data-type="horizontal"></asp:CheckBoxList>
               </asp:Panel>
    </div>
    
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" CssClass="btn btn-primary"
             />
    </div>
</asp:Content>
