<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatfromapp.aspx.cs" Inherits="Unommer.chatfromapp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
<%--    <asp:scriptmanager runat="server"></asp:scriptmanager>--%>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
