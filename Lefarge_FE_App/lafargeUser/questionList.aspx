<%@ Page Title="" Language="C#" MasterPageFile="~/Lefarge.Master" AutoEventWireup="true" CodeBehind="questionList.aspx.cs" Inherits="Lefarge_FE_App.questionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Questions</h1>

    <asp:Button PostBackUrl="~/admin/question.aspx" ID="btnNewQuestion" Text="Add a new Question" runat="server" />
    <asp:GridView ID="grdQuestions" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" DataKeyNames="Question_ID" OnRowDeleting="grdQuestions_RowDeleting"  >

         <Columns>  
             <asp:BoundField DataField="Question_ID" HeaderText="ID" Visible="true" />
              <asp:BoundField DataField="Question1" HeaderText="Question" />
              <asp:BoundField DataField="Headings_Under" HeaderText="Headings Under"/>
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="../admin/question.aspx" 
                 Text="Edit" DataNavigateUrlFields="Question_ID"
                 DataNavigateUrlFormatString="../admin/question.aspx?Question_ID={0}" />

            <asp:CommandField DeleteText="Delete"  ShowDeleteButton="true" HeaderText="Delete" />

             </Columns>
    </asp:GridView>
</asp:Content>
