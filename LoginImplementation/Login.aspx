<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Unommer.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UNOMMER</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge;chrome=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="CSS/login.css" rel="stylesheet" />
    <link href="CSS/jquery-ui.css" rel="stylesheet" />
    <link href="CSS/font-awesome.min.css" rel="stylesheet" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/bootstrap-responsive.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true   // 100% fit in a container
            });
        });

    </script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script type="text/javascript">
        function successalert(message) {
            swal({
                icon: "success",
                title: '',
                text: message,
                type: 'success'
            });
        }
    </script>
    <script type="text/javascript">
        function failurealert(message) {
            swal({
                icon: "error",
                title: '',
                text: message,
                type: 'success'
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-bg" style="font-family: Calibri;">
            <div class="head">
                <%--<div class="logo">
                    <div class="logo-top">                
                    </div>
                    <div class="logo-bottom">
                        <p>UNOMMER</p>
                    </div>
                </div>--%>
                <div class="login">
                    <div class="sap_tabs">
                        <div style="display: block; width: 100%; margin: 39px 122px;" id="horizontalTab">
                            <ul class="resp-tabs-list">
                                <li role="tab" aria-controls="tab_item-0" class="resp-tab-item resp-tab-active"><span>Login</span></li>
                            </ul>
                            <div class="resp-tabs-container">
                                <h2 role="tab" class="resp-accordion resp-tab-active" aria-controls="tab_item-0"><span class="resp-arrow"></span>Login</h2>
                                <div aria-labelledby="tab_item-0" class="tab-1 resp-tab-content resp-tab-content-active" style="display: block">
                                    <div class="clsloginerror">
                                        <asp:Label ID="lblMessage" Visible="false" runat="server" Text="Invalid User Id or Password."></asp:Label>
                                    </div>
                                    <div class="login-top">
                                        <div>

                                            <asp:TextBox ID="TxtLoginUsername" runat="server" placeholder="User Id" ValidationGroup="Login" CssClass="email" ClientIDMode="Static" OnTextChanged="TxtLoginUsername_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <p>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtLoginUsername" ValidationGroup="Login" ErrorMessage="User Id required" CssClass="reqfiled"></asp:RequiredFieldValidator>--%>
                                            </p>
                                            <asp:TextBox ID="TxtLoginPass" runat="server" TextMode="Password" placeholder="Password" ValidationGroup="Login" CssClass="password"></asp:TextBox>
                                            <p>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Login" ControlToValidate="TxtLoginPass" ErrorMessage="Password required" CssClass="reqfiled"></asp:RequiredFieldValidator>--%>
                                            </p>
                                            <asp:DropDownList ID="ddlSchool" runat="server" CssClass="form-control">
                                               <%-- <asp:ListItem Text="Select School" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Delhi Public School" Value="Delhi Public School"></asp:ListItem>
                                                <asp:ListItem Text="Default" Value="Default"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <p>
                                                <%--<asp:RequiredFieldValidator ID="ddlSchoolReq" runat="server" ValidationGroup="Login" ControlToValidate="ddlSchool" ErrorMessage="School Required" CssClass="reqfiled"></asp:RequiredFieldValidator>--%>
                                            </p>
                                        </div>
                                        <div class="login-bottom login-bottom1">
                                            <div class="remember-forgot">
                                                <a href="forgotpassword.aspx" id="lnkForgot" class="forgot">Forgot Password</a>
                                            </div>
                                            <div align="center">
                                                <asp:Button ID="btnSubmit" Text="Sign In" ValidationGroup="Login" runat="server" CssClass="hpsrbutton" OnClick="btnLoginSubmit_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h2 role="tab" class="resp-accordion" aria-controls="tab_item-1"><span class="resp-arrow"></span>/Sign up</h2>
                                <div aria-labelledby="tab_item-1" class="tab-1 resp-tab-content">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </form>
</body>
</html>


<%--<asp:TextBox ID="TxtLoginUsername" runat="server" Height="29px" Width="259px"></asp:TextBox>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtLoginUsername" ErrorMessage="Enter your email address" ForeColor="#FF0066"></asp:RequiredFieldValidator>





            <asp:TextBox ID="TxtLoginPass" runat="server" Height="29px" Width="259px" type="password"></asp:TextBox>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtLoginPass" ErrorMessage="Password is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>



            <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnLoginSubmit_Click" />--%>