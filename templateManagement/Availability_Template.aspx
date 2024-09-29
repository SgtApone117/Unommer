<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Availability_Template.aspx.cs" Inherits="Unommer.Availability_Template" MasterPageFile="Admin_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="main-box">
            <h2>Create Template</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lbltempname" Text="Template Name" runat="server" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TxtTempName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbltempstatus" Text="Template Status" runat="server" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <%--<asp:Label ID="lblstatus" Text="Active" runat="server" CssClass="control-label col-sm-2"></asp:Label>--%>
                                <asp:TextBox ID="lblstatus" Text="Active" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="table-wrap">
            <table class="table tablestyle">
                <thead>
                    <tr>
                        <th rowspan="2">
                            <asp:Label ID="lblday" runat="server" Text="Day of the Week"></asp:Label></th>
                        <th colspan="2">
                            <asp:Label ID="lblmorning" runat="server" Text="Morning"></asp:Label></th>
                        <th colspan="2">
                            <asp:Label ID="lblafternoon" runat="server" Text="Afternoon"></asp:Label></th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblstarttimemorning" runat="server" Text="Start Time"></asp:Label>

                        </th>
                        <th>
                            <asp:Label ID="lblendtimemorning" runat="server" Text="End Time"></asp:Label>

                        </th>
                        <th>
                            <asp:Label ID="lblstarttimeafternoon" runat="server" Text="Start Time"></asp:Label>

                        </th>
                        <th>
                            <asp:Label ID="lblendtimeafternoon" runat="server" Text="End Time"></asp:Label>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">
                            <asp:Label ID="lblmonday" runat="server" Text="Monday:"></asp:Label></th>
                        <td>
                            <asp:DropDownList ID="ddlmonmorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmonmorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                                <asp:ListItem Text="12:00" Value="12.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmonaftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16:00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmonaftend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">
                            <asp:Label ID="lbltuesday" runat="server" Text="Tuesday:"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="ddltuemorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddltuemorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />

                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddltueaftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddltueaftend" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">
                            <asp:Label ID="lblwednesday" runat="server" Text="Wednesday:"></asp:Label></th>
                        <td>

                            <asp:DropDownList ID="ddlwedmorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />


                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlwedmorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />

                            </asp:DropDownList>
                        </td>
                        <td>

                            <asp:DropDownList ID="ddlwedaftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlwedaftend" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="row">
                            <asp:Label ID="lblthursday" runat="server" Text="Thursday:"></asp:Label>
                        </th>

                        <td>
                            <asp:DropDownList ID="ddlthurmorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlthurmorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlthuraftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlthuraftend" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">
                            <asp:Label ID="lblfriday" runat="server" Text="Friday:"></asp:Label></th>
                        <td>
                            <asp:DropDownList ID="ddlfrimorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlfrimorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>

                            <asp:DropDownList ID="ddlfriaftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlfriaftend" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">
                            <asp:Label ID="lblsaturday" runat="server" Text="Saturday:"></asp:Label></th>
                        <td>
                            <asp:DropDownList ID="ddlsatmorstar" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlsatmorend" runat="server" CssClass="form-control">
                                <asp:ListItem Text="9:00" Value="9.00" />
                                <asp:ListItem Text="9:15" Value="9.15" />
                                <asp:ListItem Text="9:30" Value="9.30" />
                                <asp:ListItem Text="9:45" Value="9.45" />
                                <asp:ListItem Text="10:00" Value="10.00" />
                                <asp:ListItem Text="10:15" Value="10.15" />
                                <asp:ListItem Text="10:30" Value="10.30" />
                                <asp:ListItem Text="10:45" Value="10.45" />
                                <asp:ListItem Text="11:00" Value="11.00" />
                                <asp:ListItem Text="11:15" Value="11.15" />
                                <asp:ListItem Text="11:30" Value="11.30" />
                                <asp:ListItem Text="11:45" Value="11.45" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlsataftstar" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlsataftend" runat="server" CssClass="form-control">

                                <asp:ListItem Text="12:00" Value="12.00" />
                                <asp:ListItem Text="12:15" Value="12.15" />
                                <asp:ListItem Text="12:30" Value="12.30" />
                                <asp:ListItem Text="12:45" Value="12.45" />
                                <asp:ListItem Text="13:00" Value="13.00" />
                                <asp:ListItem Text="13:15" Value="13.15" />
                                <asp:ListItem Text="13:30" Value="13.30" />
                                <asp:ListItem Text="13:45" Value="13.45" />
                                <asp:ListItem Text="14:00" Value="14.00" />
                                <asp:ListItem Text="14:15" Value="14.15" />
                                <asp:ListItem Text="14:30" Value="14.30" />
                                <asp:ListItem Text="14:45" Value="14.45" />
                                <asp:ListItem Text="15:00" Value="15.00" />
                                <asp:ListItem Text="15:15" Value="15.15" />
                                <asp:ListItem Text="15:30" Value="15.30" />
                                <asp:ListItem Text="15:45" Value="15.45" />
                                <asp:ListItem Text="16:00" Value="16.00" />
                                <asp:ListItem Text="16:15" Value="16.15" />
                                <asp:ListItem Text="16:30" Value="16.30" />
                                <asp:ListItem Text="16:45" Value="16.45" />
                                <asp:ListItem Text="17:00" Value="17.00" />
                                <asp:ListItem Text="17:15" Value="17.15" />
                                <asp:ListItem Text="17:30" Value="17.30" />
                                <asp:ListItem Text="17:45" Value="17.45" />
                                <asp:ListItem Text="18:00" Value="18.00" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="BtnSubmitAvail" runat="server" Text="Create Template" OnClick="BtnSubmitAvail_Click" class="btn btn-default btn-color" />
            </div>
        </div>
    </div>
</asp:Content>
