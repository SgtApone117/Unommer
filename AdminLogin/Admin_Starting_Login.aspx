<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Starting_Login.aspx.cs" Inherits="Unommer.Admin_Starting_Login" MasterPageFile="Admin_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Change Password</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="New password" CssClass="control-label col-sm-5"></asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txt_npassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <div class="form-inline">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_npassword" ErrorMessage="Please enter New password" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Confirm Password" CssClass="control-label col-sm-5"></asp:Label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txt_ccpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <div class="form-inline">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_ccpassword" ErrorMessage="Please enter Confirm  password" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_npassword" ControlToValidate="txt_ccpassword" ErrorMessage="Password Mismatch" ForeColor="#FF0066"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" Text="Update" CssClass="btn btn-default btn-color" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lbl_msg" Font-Bold="True" BackColor="#FFFF66" ForeColor="#FF3300" runat="server" Text=""></asp:Label>
        </div>

    </div>
    <div>
        <br />
        <%--<asp:Label ID="Label2" runat="server" Text="New password" Width="120px" 
            Font-Bold="True" ForeColor="#996633" style="margin-bottom: 0px"></asp:Label>--%>
        <%--<asp:TextBox ID="txt_npassword" runat="server" TextMode="Password"></asp:TextBox>--%>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txt_npassword" ErrorMessage="Please enter New password"></asp:RequiredFieldValidator>--%>
        <br />

        <%--<asp:Label ID="Label3" runat="server" Text="Confirm password" Width="120px" 
            Font-Bold="True" ForeColor="#996633"></asp:Label>--%>

        <%--<asp:TextBox ID="txt_ccpassword" runat="server" TextMode="Password"></asp:TextBox> --%>

        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txt_ccpassword" 
            ErrorMessage="Please enter Confirm  password"></asp:RequiredFieldValidator>--%>

        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txt_npassword" ControlToValidate="txt_ccpassword" 
            ErrorMessage="Password Mismatch"></asp:CompareValidator>  --%>
    </div>
    <%--<asp:Button ID="btn_update" runat="server" Font-Bold="True" BackColor="#CCFF99" onclick="btn_update_Click" Text="Update" />--%>
    <%--<asp:Label ID="lbl_msg" Font-Bold="True" BackColor="#FFFF66" ForeColor="#FF3300" runat="server" Text=""></asp:Label><br />--%>
    <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Un_default.aspx">Login</asp:HyperLink>--%>
</asp:Content>
