<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="parentlogin.aspx.cs" Inherits="Unommer.parentlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
    <h2>
            You are now logged in as a parent
    </h2>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            </center>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upanelParent" Visible="true">
            <ContentTemplate>
                <center>
                    <h2>Parent Password Updation</h2>
                        </center>
                <table style="width: 75%; height: 182px; margin-left: 300px;">
                    <tr>
                        <td class="auto-style41">Email Address:</td>
                        <td class="auto-style39">
                            <asp:TextBox ID="TxtParEmail" runat="server" Height="29px" Width="259px"></asp:TextBox>
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    btnParenSubmitUpdate_Click
                        <tr>
                            <td class="auto-style41">Current Password:</td>
                            <td class="auto-style39">
                                <asp:TextBox ID="TxtParCurPas" runat="server" Height="29px" Width="259px" Type="password"></asp:TextBox>
                            </td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    <tr>
                        <td class="auto-style41">Update Password:</td>
                        <td class="auto-style39">
                            <asp:TextBox ID="TxtParPassUp" runat="server" Height="29px" Width="259px" Type="password"></asp:TextBox>
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style41">Confirm Update Password</td>
                        <td class="auto-style39">
                            <asp:TextBox ID="TxtParCPUp" runat="server" Height="29px" Width="259px" Type="password"></asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtParPassUp" ControlToValidate="TxtParCPUp" ErrorMessage="Update password and confirm update should be same" ForeColor="#FF0066"></asp:CompareValidator>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style41">&nbsp;</td>
                        <td class="auto-style39">
                            <asp:Button ID="btnParenSubmitUpdate" runat="server" OnClick="btnParenSubmitUpdate_Click" Text="Update" Width="70px" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers></Triggers>
        </asp:UpdatePanel>

    </form>
</body>
</html>
