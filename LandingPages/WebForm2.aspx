<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Unommer.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page
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
    <%-- <link href="CSS/registration.css" rel="stylesheet" />--%>
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
                                <div class="control-sm-10">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlUserType" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select User--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="School(For School Admins Only)" Value="School"></asp:ListItem>
                                        <asp:ListItem Text="Parent(Father/Mother/Guardian Of School Student )" Value="Parent"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="upanelSchool" Visible="false">
                <ContentTemplate>
                    <div class="container">
                        <div class="main-box">
                            <h2>School Registration</h2>
                            <div class="centerdiv_02">
                                <div class="col-sm-12">
                                    <div class="form-horizontal">

                                        <div class="form-group">
                                            <asp:Label Text="School Name" runat="server" CssClass="control-label col-sm-2" ID="lblname"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtSchoolName" runat="server" CssClass="form-control"></asp:TextBox>

                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchoolName" ErrorMessage="Name is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblcity" runat="server" Text="City" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>

                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCity" ErrorMessage="City is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblboard" runat="server" Text="Board" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlBoard" CssClass="form-control" runat="server" Width="259px">
                                                </asp:DropDownList>

                                                <div class="form-group">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlBoard" ErrorMessage="Board is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblaffiliationno" runat="server" Text="Affilation No." CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAffiliationNum" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAffiliationNum" ErrorMessage="Affiliation no. is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAffiliationNum" ErrorMessage="Affiliation no is not valid" ForeColor="#FF0066" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblTeleNum" runat="server" Text="Telephone No" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtTeleNum" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTeleNum" ErrorMessage="Phone No is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid Phone number" ForeColor="#FF0066" ControlToValidate="txtTeleNum" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblmobile" runat="server" Text="Mobile No" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtMobileNum" CssClass="form-control" runat="server" Width="259px" Height="29px"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMobileNum" ErrorMessage="Mobile No is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtMobileNum" ForeColor="#FF0066" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lbladminname" Text="Administrator Name" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAdminName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Administrator name is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lbladminemail" Text="Admin Email" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAdminEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminEmail" ErrorMessage="Email is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="emailvalidator" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtAdminEmail" ErrorMessage="Invalid Email Format" ForeColor="#FF0066"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lbladmincontact" Text="Administrator Contact No." runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAdminContactNum" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAdminContactNum" ErrorMessage="Mobile No is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator67" runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtAdminContactNum" ForeColor="#FF0066"  ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label Text="Address" runat="server" ID="lbladdress" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is mandatory" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<div class="form-group">
                                    <asp:Label ID="lblregdate" runat="server" Text="Registration No." CssClass="control-label col-sm-2"></asp:Label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtRegDate" CssClass="form-control" runat="server" Height="29px" Width="259px"></asp:TextBox>
                                    </div>
                                </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="btn-wrap">
                            <div class="form-group" align="center">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Register" class="btn btn-default btn-color" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers></Triggers>
            </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="upanelParent" Visible="false">
                <ContentTemplate>
                    <div class="container">
                        <div class="main-box">
                            <h2>Parent Registration</h2>
                            <div class="centerdiv_02">
                                <div class="col-sm-12">
                                    <div class="form-horizontal">

                                        <div class="form-group">
                                            <asp:Label Text="Name of Parent" ID="lblparentname" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="TxtParentName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtParentName" ErrorMessage="Enter Parents Name" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label Text="Email" ID="lblparent" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="TxtParEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                <div class="form-inline">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtParEmail" ErrorMessage="Enter email address" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtParEmail" ErrorMessage="Invalid Email Format" ForeColor="#FF0066"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <%--<div class="form-group">
                                        <asp:Label Text="Registration Date" ID="lblparregdate" runat="server" CssClass="control-label col-sm-10"></asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TxtParRegDate" CssClass="form-control" runat="server" Height="29px" Width="259px"></asp:TextBox>
                                        </div>
                                    </div>--%>

                                        <div class="form-group">
                                            <asp:Label Text="Parent Type" ID="lblpartype" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="droppartype" CssClass="form-control" runat="server" Width="259px">
                                                    <asp:ListItem Selected="True" Text="---Select type---" Value="Type" />
                                                    <asp:ListItem Text="Father" Value="Father" />
                                                    <asp:ListItem Text="Mother" Value="Mother" />
                                                    <asp:ListItem Text="Guardian" Value="Guardian" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label Text="Select School" ID="lblschool" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlschool" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlschool_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="table-wrap table-responsive">
                                            <div class="GridviewDiv">
                                                <asp:GridView ID="GrdStudent" runat="server" Visible="False" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                    <HeaderStyle BackColor="#A55129" CssClass="headerstyle" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="btn-wrap">
                            <div class="form-group" align="center">
                                <asp:Button ID="btnParenSubmit" runat="server" OnClick="btnParenSubmit_Click" Text="Register" CssClass="btn btn-default btn-color" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers></Triggers>
            </asp:UpdatePanel>

        </div>
        <%--<asp:UpdatePanel runat="server" ID="upanelTeacher" Visible="false">
                <ContentTemplate>
                    <h2>Teacher Registration</h2>
                    <table style="width: 75%; height: 259px; margin-left: 300px;">
                        <tr>
                            <td class="auto-style14" colspan="0">Name</td>
                            <td class="auto-style36">
                                <asp:TextBox ID="txtTeachName" runat="server" Height="29px" Width="259px"></asp:TextBox>
                            </td>
                            <td class="auto-style37">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTeachName" ErrorMessage="Enter your name" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14" colspan="0">Email Address</td>
                            <td class="auto-style31">
                                <asp:TextBox ID="TxtTeachEmail" runat="server" Height="29px" Width="259px"></asp:TextBox>
                            </td>
                            <td class="auto-style40">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtTeachEmail" ErrorMessage="Enter your email address" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                <td class="auto-style3">Enter the Subjects you are teaching :-</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Subject Name:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Select Subject" Value="Subject"  Selected="True"/>
                         <asp:ListItem Text="Physics" Value="Physics"/>
                        <asp:ListItem Text="Maths" Value="Maths" />
                        <asp:ListItem Text="Biology" Value="Biology" />
                        <asp:ListItem Text="Social Science" Value="Social Science" />
                        <asp:DropDownList ID="category" runat="server">
                      <asp:ListItem>Teacher</asp:ListItem>
                        <asp:ListItem>Parent</asp:ListItem>
                        <asp:ListItem>Principal</asp:ListItem>
                  </asp:DropDownList>
                    </asp:DropDownList>
                </td>
                <td class="auto-style7">Standard:-</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Text="Select Standard" Value="Standard" Selected="True"/>
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2"/>
                        <asp:ListItem Text="3" Value="3"/>
                        <asp:ListItem Text="4" Value="4"/>
                        <asp:ListItem Text="5" Value="5"/>
                        <asp:ListItem Text="6" Value="6"/>
                        <asp:ListItem Text="7" Value="7"/>
                        <asp:ListItem Text="8" Value="8"/>
                        <asp:ListItem Text="9" Value="9"/>
                        <asp:ListItem Text="10" Value="10"/>
                        <asp:ListItem Text="11" Value="11"/>
                        <asp:ListItem Text="12" Value="12"/>
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">Section:-</td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                      <asp:ListItem Text="Select Standard" Value="Standard" Selected="True"/>
                        <asp:ListItem Text="A" Value="A"/>
                        <asp:ListItem Text="B" Value="B"/>
                        <asp:ListItem Text="C" Value="C"/>
                        <asp:ListItem Text="D" Value="D"/>
                    </asp:DropDownList>
                </td>
            </tr>
                       <tr>
                            <td class="auto-style14" colspan="0" rowspan="0">Registration Date</td>
                            <td class="auto-style31">
                                <asp:TextBox ID="TxtTeachRegDate" runat="server" Height="29px" Width="259px"></asp:TextBox>
                            </td>
                            <td class="auto-style25"></td>
                        </tr>
                        <tr>
                            <td class="auto-style14" colspan="0">&nbsp;</td>
                            <td class="auto-style31">
                                <asp:Button ID="btnTeaSubmit" runat="server" OnClick="btnTeaSubmit_Click" Text="Register" Width="70px" />
                            </td>
                            <td class="auto-style25">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers></Triggers>
            </asp:UpdatePanel>--%>

        <div class="footer">
            <div class="container">
                <div class="footer-lft">© 2009 - 2018 Unikul Solutions Pvt Ltd. All rights reserved.</div>
                <div class="footer-rt">
                    <div class="social-icon">
                        <a href="#"><i class="fa fa-facebook-square" aria-hidden="true"></i></a>
                        <a href="#"><i class="fa fa-twitter-square" aria-hidden="true"></i></a>
                        <a href="#"><i class="fa fa-google-plus-square" aria-hidden="true"></i></a>
                        <a href="#"><i class="fa fa-skype" aria-hidden="true"></i></a>
                    </div>
                </div>
            </div>
        </div>

    </form>


    <%--<div class="container">
        <div class="main-box">
            <h2>Registration</h2>
            <div class="form-group">
                <div class="col-sm-10">
                    <asp:DropDownList runat="server" CssClass="dropbtn" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                        <asp:ListItem Text="--Select User--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="School" Value="School"></asp:ListItem>
                        <asp:ListItem Text="Parent" Value="Parent"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="navbar-header">
                <a href="#">
                    <h1 class="navbar-brand">UNNOMER</h1>
                </a>
            </div>
        </div>
    </div>--%>
</body>
</html>
