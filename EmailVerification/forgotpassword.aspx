<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="Unommer.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password
    </title>
    <link href="CSS/bootstrap-responsive.css" rel="stylesheet" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/font-awesome.min.css" rel="stylesheet" />
    <link href="CSS/jquery-ui.css" rel="stylesheet" />
    <link href="CSS/sap_access.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" />
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
    <form runat="server">
        <div class="container">
            <div class="main-box">
                <h2>User Registration</h2>
                <div class="centerdiv_02">
                    <div class="col-sm-12">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label ID="lblemail" Text="Enter your email" CssClass="control-label col-sm-2" runat="server"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="btn-wrap">
                <div class="form-group" align="center">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Change Password" class="btn btn-default btn-color"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
