<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portal_Admin_Change_Password.aspx.cs" Inherits="Unommer.Portal_Admin_Change_Password" MasterPageFile="~/Portal_Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="lblnewpass" runat="server" CssClass="control-label col-sm-2" Text="Enter New Password"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Password" runat="server" CssClass="form-group" ID="txtnewpass"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblconfirmpass" runat="server" CssClass="control-label col-sm-2" Text="Confirm Password"></asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Password" runat="server" CssClass="form-group" Text="" ID="txtconfirmpass"></asp:TextBox>
            </div>
        </div>
        <asp:CompareValidator ID="CompareValidator1" runat="server"
            ControlToCompare="txtnewpass" ControlToValidate="txtconfirmpass"
            ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button Text="Confirm" runat="server" ID="btnconfirm" OnClick="btnconfirm_Click" />
            </div>
        </div>
    </div>
</asp:Content>
