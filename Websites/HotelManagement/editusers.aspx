<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editusers.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="registerusers" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="control">
        <span class="label"><asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label></span>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field cannot be empty!" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    </div>
     <div class="validate">
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="First Name can contain only alphabets!" ControlToValidate="TextBox1" ForeColor="Red" ValidationExpression="[a-zA-Z]*"></asp:RegularExpressionValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label></span>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field cannot be empty!" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
    </div>
    <div class="validate">
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Last Name can contain only alphabets!" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="[a-zA-Z]*"></asp:RegularExpressionValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label3" runat="server" Text="Contact No."></asp:Label></span>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This field cannot be empty!" ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
    </div>
    <div class="validate">
         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Contact No. format incorrect! (XXX-XXXXXXX)" ControlToValidate="TextBox3" ForeColor="Red" ValidationExpression="[\d][\d][\d]-[\d]{7}"></asp:RegularExpressionValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label4" runat="server" Text="NIC No."></asp:Label></span>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This field cannot be empty!" ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
    </div>
    <div class="validate">
         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="NIC format incorrect!" ControlToValidate="TextBox4" ForeColor="Red" ValidationExpression="[\d]{9}[Vv]"></asp:RegularExpressionValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label5" runat="server" Text="Date of Birth"></asp:Label></span>
        <asp:TextBox ID="TextBox8" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label6" runat="server" Text="User Name"></asp:Label></span>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="This field cannot be empty!" ForeColor="Red" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
    </div>
 
    <div class="control">
        <span class="label"><asp:Label ID="Label7" runat="server" Text="Password"></asp:Label></span>
        <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div class="validate">
    </div>
  
    <div class="control">
        <span class="label"><asp:Label ID="Label8" runat="server" Text="Confirm Password"></asp:Label></span>
        <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div class="validate">
    </div>
  
    <div class="validate">
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords do not match!" ControlToCompare="TextBox6" ControlToValidate="TextBox7" ForeColor="Red"></asp:CompareValidator>
    </div>
    <asp:Label ID="Label9" runat="server" Text="" ForeColor="Red"></asp:Label>
    
    <div class="control">
        <asp:Button ID="Button1" runat="server" Text="Edit" OnClick="Button1_Click" />
    </div>
    
    
</asp:Content>



