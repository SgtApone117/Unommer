<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Un_default.aspx.cs" Inherits="Unommer.WebForm1" %>

<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls" TagPrefix="BDP" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8" />
    <title>Unommer</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />

    <script src="sum_js/jquery.min.js"></script>
    <script src="sum_js/skel.min.js"></script>
    <script src="sum_js/js/skel-layers.min.js"></script>
    <script src="sum_js/js/init.js"></script>
    <script src="sum_js/js/jquery.scrollex.min.js"></script>
    <script src="sum_js/js/util.js"></script>
    <script src="sum_js/js/main.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
    <script src="sum_js/js/jquery.timepicker.js"></script>
    <script src="sum_js/js/jquery.timepicker.min.js"></script>   
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <script>
        $(document).ready(function () {
            $(function () {

                //$("#dateofdemo").datepicker();      
                $('input[id$=dateofdemo]').datepicker({
                    dateFormat: 'd MM, yy'
                });

            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('input.timepicker').timepicker({
                timeFormat: 'h:mm p',
                // year, month, day and seconds are not important
                minTime: new Date(0, 0, 0, 11, 0, 0),
                maxTime: new Date(0, 0, 0, 16, 0, 0),
                // time entries start being generated at 6AM but the plugin 
                // shows only those within the [minTime, maxTime] interval
                startHour: 6,
                dynamic: false,
                // the value of the first item in the dropdown, when the input
                // field is empty. This overrides the startHour and startMinute 
                // options
                startTime: new Date(0, 0, 0, 11, 00, 0),
                // items in the dropdown are separated by at interval minutes
                interval: 30,
                scrollbar: true
            });
        });
    </script>
    <script type="text/javascript">
        function successalert() {
            swal({
                icon: "success",
                title: 'Thank You!',
                text: 'We will Contact you Shortly',
                type: 'success'
            });
        }
    </script>

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css" />
    <link href="sum_css/jquery.timepicker.css" rel="stylesheet" />
    <link href="sum_css/jquery.timepicker.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="sum_css/skel.css" />
    <link rel="stylesheet" href="sum_css/style.css" />
    <link rel="stylesheet" href="sum_css/style-xlarge.css" />

</head>
<body class="landing">
    <form runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--HEADER--%>
        <header id="header">
            <h1><a href="http://www.unikul.com/">UNIKUL Solutions Pvt Ltd</a></h1>
            <nav id="nav">
                <ul>
                    <li><a href="#three" class="button special">For Demo</a></li>
                    <li><a href="WebForm2.aspx" class="button special">Sign Up</a></li>
                    <li><a href="login.aspx" class="button special">Sign in</a></li>
                </ul>
            </nav>
        </header>

        <%--BANNER--%>
        <section id="banner">
            <h2>Unommer</h2>
            <p>Parent-Teacher Collaboration Application.</p>
            <ul class="actions">
                <li>
                    <a href="WebForm2.aspx" class="button big">Sign Up</a>
                </li>
            </ul>
        </section>

        <%--ONE--%>
        <section id="one" class="wrapper style1 special">
            <div class="container">
                <header class="major">
                    <h2>Features Of Unommer</h2>
                    <p>Below are the various features of Unommer</p>
                </header>
                <div class="row 150%">

                    <div class="4u 12u$(medium)">
                        <section class="box">
                            <i class="icon big rounded color1 material-icons">chat</i>
                            <h3>Enables Chat Communication</h3>
                            <p>Parent and Teacher can join via chat where they can talk and share documents, making a very interactive sessions thus helping both parents and teacher to collaborate.</p>
                        </section>
                    </div>

                    <div class="4u 12u$(medium)">
                        <section class="box">
                            <i class="icon big rounded color6 fa-file-text"></i>
                            <h3>Debriefing Of Collaboration   </h3>
                            <p>After a collaboration session, one of the participants (Teacher or Parent) can de-brief the session with points discussed, actions to be taken. They can also share/upload any specific documents study aids/student performance reports etc.</p>
                        </section>
                    </div>

                    <div class="4u 12u$(medium)">
                        <section class="box">
                            <i class="icon big rounded color9 fa-calendar"></i>
                            <h3>Intelligent Rostering of Schedule</h3>
                            <p>It begins with an intelligent rostering of teachers to be available to collaborate with parents, Schedule teacher time intelligently to maximize availability to parents</p>
                        </section>
                    </div>
                </div>
            </div>
        </section>

        <%--SECOND--%>
        <section id="two" class="wrapper style2 special">
            <div class="container">
                <header class="major">
                    <h2>Users</h2>
                    <p>The major users who will be using this application</p>
                </header>
                <section class="profiles">
                    <div class="row">
                        <section class="3u 6u(medium) 12u$(xsmall) profile">
                            <img src="sum_Images/School1.png" alt="" />
                            <h4>School Registration</h4>
                            <!-- <p>Keeping the record off all the school activities.</p> -->
                        </section>
                        <section class="3u 6u$(medium) 12u$(xsmall) profile">
                            <img src="sum_Images/adminschool1.png" alt="" />
                            <h4>System Administrator</h4>
                            <!-- <p>One Administrator for each school will be assigned.</p> -->
                        </section>
                        <section class="3u 6u(medium) 12u$(xsmall) profile">
                            <img src="sum_Images/parent23.png" alt="" />
                            <h4>Parent Registration</h4>
                            <!-- <p>Parents can collaborate with the teachers.</p> -->
                        </section>
                        <section class="3u$ 6u$(medium) 12u$(xsmall) profile">
                            <img src="sum_Images/teacher1.png" alt="" />
                            <h4>Teacher Registration</h4>
                            <!-- <p>Teachers can setup collaboration with parents and share details.</p> -->
                        </section>
                    </div>
                </section>
            </div>
        </section>

        <%--THREE--%>
        <section id="three" class="wrapper style3 special">
            <div class="container">
                <header class="major">
                    <h2>For Demo </h2>
                </header>
            </div>
            <div class="container 50%">
                <form action="#" method="post">
                    <div class="row uniform">
                        <div class="6u 12u$(small)">
                            <asp:TextBox ID="name" placeholder="Name" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="black" Display="Dynamic" runat="server" ValidationExpression="[a-zA-Z ]*$" ControlToValidate="name" CssClass="Validators" ErrorMessage="Please Enter Valid Name Format"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="black" Display="Dynamic" runat="server" ControlToValidate="name" ErrorMessage="Please Enter This Field" CssClass="Validators"></asp:RequiredFieldValidator>
                            <%--<input name="name" id="name" value="" placeholder="Name" type="text" />--%>
                        </div>
                        <div class="6u$ 12u$(small)">
                            <asp:TextBox ID="email" placeholder="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="black" Display="Dynamic" runat="server" ControlToValidate="email" ErrorMessage="Please Enter This Field" CssClass="Validators"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" ForeColor="black" Display="Dynamic" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="Validators" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                            <%--<input name="email" id="email" value="" placeholder="Email" type="email" />--%>
                        </div>
                        <div class="6u 12u$(small)">
                            <asp:TextBox ID="nameofschool" placeholder="Name Of School" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="black" Display="Dynamic" runat="server" ControlToValidate="nameofschool" ErrorMessage ="Please Enter This Field" CssClass="Validators"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="black" Display="Dynamic" runat="server" ValidationExpression="[a-zA-Z ]*$" ControlToValidate="nameofschool" CssClass="Validators" ErrorMessage="Please Enter Valid School Name Format"></asp:RegularExpressionValidator>
                            <%--<input name="Name Of School" id="nameofschool" value="" placeholder="Name Of School" type="text" />--%>
                        </div>
                        <div class="6u$ 12u$(small)">
                            <asp:TextBox ID="phonenumber" placeholder="Phone Number" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="black" Display="Dynamic" runat="server" ControlToValidate="phonenumber" ErrorMessage="Please Enter This Field" CssClass="Validators"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="phonenumber" ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers only" runat="server"/>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="black" Display="Dynamic" runat="server" ControlToValidate="phonenumber" CssClass="Validators" ErrorMessage="Please enter valid Mobile number!" ValidationExpression="^([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                            <%--<input name="Phone Number" id="phonenumber" value="" placeholder="Phone Number" type="text" />--%>
                        </div>
                        <div class="6u 12u$(small)">
                            <asp:TextBox ID="dateofdemo" runat="server" ReadOnly="true" placeholder="Enter Date Of Demo" CssClass="Validators"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="black" Display="Dynamic" ControlToValidate="dateofdemo" runat="server" CssClass="Validators" ErrorMessage="Please Enter This Field"></asp:RequiredFieldValidator>
                            <%--<input name="Date and Time Of Demo" ID="datetimeofdemo" value="" type="datetime-local" />--%>
                        </div>
                        <div class="6u$ 12u$(small)">
                            <asp:TextBox ID="timeofdemo" runat="server" ReadOnly="true" CssClass="timepicker" placeholder="Enter Time Of Demo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="black" ControlToValidate="timeofdemo" runat="server" Display="Dynamic" CssClass="Validators" ErrorMessage="Please Enter This Field"></asp:RequiredFieldValidator>
                            <%--<input name="Date and Time Of Demo" ID="datetimeofdemo" value="" type="datetime-local" />--%>
                        </div>
                        <div class="12u$">
                            <%--<ul class="actions">--%>
                            <%-- <li>--%>
                            <asp:Button ID="Btnsubmit" runat="server" OnClick="Btnsubmit_Click" Text="Request for free Demo" CssClass="special big" />
                            <%--<input value="Request for free trial" class="special big" type="submit" />--%>
                            <%--</li>--%>
                            <%--</ul>--%>
                        </div>
                    </div>
                </form>
            </div>
        </section>

        <%--FOOTER--%>
        <footer id="footer">
            <div class="container">
                <ul class="icons">
                    <li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
                    <li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
                    <li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
                    <li><a href="#" class="icon fa-envelope-o"><span class="label">Email</span></a></li>
                </ul>
            </div>
            <div class="copyright">
                &copy; Unikul Solutions Pvt Ltd. All rights reserved.
            </div>
        </footer>
    </form>
</body>
</html>


