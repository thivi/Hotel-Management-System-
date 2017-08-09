<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="control">
        <span class="label"><asp:Label ID="Label4" runat="server" Text="User Name"></asp:Label></span>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter User Name" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator></div>
    <div class="control">
        <span class="label"><asp:Label ID="Label1" runat="server" Text="Password"></asp:Label></span>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="password"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator></div>
    <div class="control">
        <asp:button runat="server" text="LOGIN" OnClick="Unnamed1_Click" />
    </div>
    <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>
</asp:Content>

