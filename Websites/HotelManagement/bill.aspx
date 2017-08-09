<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1><asp:Label ID="Label9" runat="server" Text="Hotel Monsoon- Invoice" style="text-align: center"></asp:Label></h1>
    <h2>
        <asp:Label ID="Label10" runat="server" Text="" style="text-align: center"></asp:Label></h2>
    <asp:Panel ID="Panel1" runat="server">
        <div>
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        </div>
        <div>
        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
        <div class="cart-item">
         <div class="room-type"><asp:Label ID="Label2" runat="server" Text='<%# Eval("roomtype")+" Room" %>'></asp:Label>
        
            </div>
            <div class="room-type"><asp:Label ID="Label6" runat="server" Text='<%# "Room Number: " + Eval("rno") %>'></asp:Label>
        
            </div>
            <div class="guests"><asp:Label ID="Label1" runat="server" Text='<%# "No. of guests " + Eval("noguests") %>'></asp:Label></div>
            <div class="check-con">
                <div class="check"><asp:Label ID="Label4" runat="server" Text='<%# "Check In: "+ Eval("checkin") %>'></asp:Label></div>
                <div class="check"><asp:Label ID="Label5" runat="server" Text='<%# "Check Out: "+ Eval("checkout") %>'></asp:Label></div>
            </div>
            <div class="cost"><asp:Label ID="Label3" runat="server" Text='<%# "Total Amount: " + Eval("cost") %>'></asp:Label></div>
            
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
        <ItemTemplate>
        <div class="cart-item">
         <div class="room-type"><asp:Label ID="Label2" runat="server" Text='<%# Eval("functiontype")+" Function" %>'></asp:Label>
        
            </div>
            <div class="room-type"><asp:Label ID="Label6" runat="server" Text='<%# "Hall Number: " + Eval("hallno") %>'></asp:Label>
        
            </div>
            <div class="guests"><asp:Label ID="Label1" runat="server" Text='<%# "No. of attendees " + Eval("no") %>'></asp:Label></div>
            <div class="check-con">
                <div class="check"><asp:Label ID="Label4" runat="server" Text='<%# "Time: "+ Eval("time") %>'></asp:Label></div>
                <div class="check"><asp:Label ID="Label5" runat="server" Text='<%# "Meal Type: "+ Eval("mealtype") %>'></asp:Label></div>
            </div>
            <div class="cost"><asp:Label ID="Label3" runat="server" Text='<%# "Date: " + Eval("day") %>'></asp:Label></div>
            <div class="cost"><asp:Label ID="Label7" runat="server" Text='<%# "Total Amount: " + Eval("totcost") %>'></asp:Label></div>
            
            
            </div>
        </ItemTemplate>
    </asp:Repeater>
   
</asp:Content>

