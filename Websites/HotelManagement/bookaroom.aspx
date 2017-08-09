<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bookaroom.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="control">
        <span class="label"><asp:Label ID="Label3" runat="server" Text="Room Type"></asp:Label></span>
        <asp:dropdownlist runat="server" ID="type">
            <asp:ListItem>Luxury</asp:ListItem>
            <asp:ListItem>Semi-Luxury</asp:ListItem>
            <asp:ListItem>Ordinary</asp:ListItem>
        </asp:dropdownlist>
    </div>
  
    <div class="control">
        <span class="label"><asp:Label ID="Label2" runat="server" Text="Check In Date"></asp:Label></span>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>

    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Select a Check In Date" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label4" runat="server" Text="Check Out Date"></asp:Label></span>
        <asp:TextBox ID="checkout" runat="server" TextMode="Date"></asp:TextBox>
        
    </div>
    <div class="validate">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select a Check Out Date" ForeColor="Red" ControlToValidate="checkout"></asp:RequiredFieldValidator>
    </div>
    <div class="control">
        <span class="label"><asp:Label ID="Label5" runat="server" Text="No. of guests"></asp:Label></span>
         <asp:TextBox ID="guests" runat="server" TextMode="Number"></asp:TextBox>

    </div>
    <div class="validate">
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="guests" ErrorMessage="No. of guests should be more than  0 and less than 6" ForeColor="Red" MaximumValue="6" MinimumValue="1"></asp:RangeValidator>
        
    </div>
    <div class="validate"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="guests" ErrorMessage="Specify the no. of guests" ForeColor="Red"></asp:RequiredFieldValidator></div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#00CC00"></asp:Label>
    <div class="control">
        
        <asp:Button ID="Button1" runat="server" Text="Check Availability" OnClick="Button1_Click" />

    </div>
</asp:Content>

