<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bookahall.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="control">
        <span class="label"><asp:Label ID="Label5" runat="server" Text="Time"></asp:Label></span>
         <asp:DropDownList ID="DropDownList1" runat="server">
             <asp:ListItem>Morning</asp:ListItem>
             <asp:ListItem>Evening</asp:ListItem>
             <asp:ListItem>Night</asp:ListItem>
         </asp:DropDownList>  
    </div>
     <div class="control">
        <span class="label"><asp:Label ID="Label1" runat="server" Text="Date"></asp:Label></span>  
         <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
         
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date is required" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></div>
    <div class="control">
        <span class="label"><asp:Label ID="Label2" runat="server" Text="Function Type"></asp:Label></span>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Birthday</asp:ListItem>
            <asp:ListItem>Meeting</asp:ListItem>
            <asp:ListItem>Wedding</asp:ListItem>
            <asp:ListItem>Reception</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList> 
    </div>
  
    <div class="control">
        <span class="label"><asp:Label ID="Label3" runat="server" Text="Meal Package"></asp:Label></span>
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem>Short-eats</asp:ListItem>
            <asp:ListItem>Light Meals</asp:ListItem>
            <asp:ListItem>Heavy Meals</asp:ListItem>
            <asp:ListItem>Exotic Traditional</asp:ListItem>
        </asp:DropDownList> 
    </div>
   
    <div class="control">
        <span class="label"><asp:Label ID="Label4" runat="server" Text="No. of Attendees"></asp:Label></span>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
    </div>
    <div class="validate">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="No. of Attendees required" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></div>
    <div class="validate">
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Attendees should be between 50 and 100" ControlToValidate="TextBox1" ForeColor="Red" MaximumValue="999" MinimumValue="50"></asp:RangeValidator></div>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#00CC00"></asp:Label>
    <div class="control">
      
          <asp:Button ID="Button1" runat="server" Text="Check Availability" OnClick="Button1_Click" />
    </div>
</asp:Content>

