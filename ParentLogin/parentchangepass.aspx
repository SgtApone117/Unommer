<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parentchangepass.aspx.cs" Inherits="Unommer.parentchangepass" MasterPageFile="Parent_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Change Password</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lblnewpass" runat="server" CssClass="control-label col-sm-2" Text="Enter New Password"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ID="txtnewpass"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Password" ControlToValidate="txtnewpass" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblconfirmpass" runat="server" CssClass="control-label col-sm-2" Text="Confirm Password"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" Text="" ID="txtconfirmpass"></asp:TextBox>
                            </div>
                        </div>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToCompare="txtnewpass" ControlToValidate="txtconfirmpass"
                            ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="btn-wrap">
            <div class="form-group" align="center">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button Text="Change Password" runat="server" ID="btnconfirm" OnClick="btnconfirm_Click" class="btn btn-default btn-color" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
