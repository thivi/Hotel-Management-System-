<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="details">
        <h2><asp:label id="details" runat="server" text=""></asp:label></h2>
    </div>
    <div class="control">
        <asp:label runat="server" text="Credit Card No."></asp:label>
        <asp:textbox id="cardno" runat="server"></asp:textbox>
    </div>
    <div class="Validate">
        <asp:requiredfieldvalidator runat="server" errormessage="Field cannot be empty!" ForeColor="Red" ControlToValidate="cardno"></asp:requiredfieldvalidator>
    </div>
     <div class="control">
        <asp:label runat="server" text="PIN"></asp:label>
        <asp:textbox id="pin" runat="server" TextMode="Number"></asp:textbox>
    </div>
    <div class="Validate">
        <asp:requiredfieldvalidator runat="server" errormessage="Field cannot be empty!" ForeColor="Red" ControlToValidate="pin"></asp:requiredfieldvalidator>
    </div>
     <div class="control">
        <asp:label runat="server" text="Expiry Date"></asp:label>
        <asp:textbox id="date" runat="server" TextMode="Date"></asp:textbox>
    </div>
    <div class="Validate">
        <asp:requiredfieldvalidator runat="server" errormessage="Field cannot be empty!" ForeColor="Red" ControlToValidate="date"></asp:requiredfieldvalidator>
    </div>
     <div class="control">
        <asp:label runat="server" text="Name on Card"></asp:label>
        <asp:textbox id="name" runat="server"></asp:textbox>
    </div>
    <div class="Validate">
        <asp:requiredfieldvalidator runat="server" errormessage="Field cannot be empty!" ForeColor="Red" ControlToValidate="name"></asp:requiredfieldvalidator>
    </div>
    <div class="card-choice">
        <div class="card-type">
            <asp:radiobutton id="visa" runat="server" GroupName="card" Checked="True"></asp:radiobutton>
            <i class="fa fa-cc-visa fa-5x" aria-hidden="true"></i>
        </div>
        <div class="card-type">
            <asp:radiobutton id="master" runat="server" GroupName="card"></asp:radiobutton>
            <i class="fa fa-cc-mastercard fa-5x" aria-hidden="true"></i>
        </div>
    </div>
        <div class="control">
            <asp:button runat="server" text="Pay" OnClick="Unnamed11_Click" />
        </div>
</asp:Content>

