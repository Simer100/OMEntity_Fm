<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="empview.aspx.cs" Inherits="OMEntityWeb.Employee.empview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Details</h2>

    <div>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                  <asp:Image ID="empImg" runat="server" style='max-width: 150px; max-height: 150px;' />
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblName" runat="server" Text="Simmer"></asp:Label></br>
                <i class="icon-mail">&nbsp;</i> Email : <asp:Label ID="lblemail" runat="server" Text="EmailSample@gmail.com"></asp:Label></br>
                <i class="icon-phone">&nbsp;</i> Mobile No. :<asp:Label ID="lblMobile" runat="server" Text="999999999"></asp:Label>
                </div>
            </div>
            <div class="order-1">&nbsp;</div>
            <div class="row">
                <div class="col-md-3">DateOfBirth -  <asp:Label ID="lblDOB" runat="server" Text="10-Jan-1991"></asp:Label></div>
                <div class="col-md-3">JoiningDate) -  <asp:Label ID="lblJoinDate" runat="server" Text="11-Apr-2018"></asp:Label></div>
                <div class="col-md-2">Gender -  <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label></div>
            </div>
            <div class="order-1">&nbsp;</div>
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
