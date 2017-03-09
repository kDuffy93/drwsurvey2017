 <%@ Page Title="" Language="C#" MasterPageFile="~/report.Master" AutoEventWireup="true" CodeBehind="tempImages.aspx.cs" Inherits="Lefarge_FE_App.lafargeUser.tempImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:DataList runat="server"  RepeatColumns="2"  AlternatingItemStyle-HorizontalAlign="Center" CellPadding="5"   ItemStyle-Width="800px"  ID="DLTempImage" DataKeyField="ID"  OnItemDataBound="DLTempImage_ItemDataBound">
    <HeaderTemplate>
    <p>Images:</p>
        </HeaderTemplate>

    <ItemTemplate>
        <div style="padding-left:1em; border:5px double #29a329; height:700px;" >
        <div style="align-items:center;background-color:#66ff66;">
            <asp:Label ID="qID"  Visible="true" runat="server" >Question: <%#Eval("question_ID")%></asp:Label></br>
             <asp:Label  ID="hID" Visible="true" runat="server" >Heading: <%#Eval("heading_ID")%></asp:Label></br>

           

             <asp:label runat="server" style="color:black;">Equipment NO: <%#Eval("equipment_ID")%></asp:label></br>

      

            <p style="color:black;" >Date Submited: <%#Eval("DateSubmited")%></p>


            </div>

        <div  style="align-items:center;background-color:#ccffcc;">
        <asp:Image  OnDataBinding="imageContainer_DataBinding" runat="server" ID="imageContainer" Height="550" Width="550" ImageUrl='<%# "/admin/" + Eval("URL") %>'/>
            </div>
            </div>
        
    </ItemTemplate>
</asp:DataList>
</asp:Content>
