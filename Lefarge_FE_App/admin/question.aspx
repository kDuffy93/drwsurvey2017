<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="Lefarge_FE_App.question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Question</h1>
    
    <h5>Add a Question to different headings</h5>
    <h6></h6>
    <div class="form-group">
        <label for="txtQuestion" class="col-sm-3">Question:</label>
        <asp:TextBox ID="txtQuestion" runat="server" required="true" MaxLength="250" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="A question is required"  CssClass="alert alert-danger" ControlToValidate="txtQuestion"></asp:RequiredFieldValidator>
    </div>
    
     <div class="form-group">
        
<label for="lbHeading" class="col-sm-3">Which Headings should this questions be under?</label>
               <asp:Panel ID="rbPanel" runat="server">
                   <asp:CheckBoxList runat="server" id="chklstHeadings" data-role="controlgroup" data-type="horizontal"></asp:CheckBoxList>
               </asp:Panel>
    </div>
    
    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click" CssClass="btn btn-primary"
             />
    </div>
</asp:Content>
