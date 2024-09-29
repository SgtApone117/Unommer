<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Rooster_Selection.aspx.cs" Inherits="Unommer.Admin_Rooster_Selection" MasterPageFile="Admin_Master.Master" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="main-box">
            <h2>Roster Creation</h2>
            <div class="left-box">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lblteachmail" Text="Teacher Email" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="TxtTeacherEmailRoster" runat="server" CssClass="form-control" OnSelectedIndexChanged="TxtTeacherEmailRoster_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Valid Email ID" ForeColor="Red" ControlToValidate="TxtTeacherEmailRoster"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="table-wrap table-responsive">
                            <div class="GridviewDiv">
                                <asp:GridView ID="Grdteachername" runat="server" Visible="False" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="false">
                                    <%--<FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />--%>
                                    <HeaderStyle BackColor="#A55129" CssClass="headerstyle" Font-Bold="True" ForeColor="White" />
                                   <%-- <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" /--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Teacher Name" DataField="teacher_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                        <div class="form-group" style="padding-top: 30px;">
                            <asp:Label ID="lblyear" runat="server" Text="Year" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:Label ID="LabelRosterYear" runat="server" Text="Label" CssClass="control-label col-sm-2"></asp:Label>
                            </div>
                        </div>
                   <%--     <br />
                        <br />
                        <br />--%>
                        <div class="form-group">
                            <asp:Label ID="lblstartyear" runat="server" Text="Start Date" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:Calendar ID="DatePicker1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="DatePicker1_SelectionChanged">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                                <asp:TextBox ID="TxtTakeDate1" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please pick a date" ForeColor="Red" ControlToValidate="TxtTakeDate1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="right-box">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lbltempname" runat="server" Text="Template Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="DropDownListTemplateSelctionRoster" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Template" ForeColor="Red" ControlToValidate="DropDownListTemplateSelctionRoster"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblmonth" runat="server" Text="Month" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlrostermonth" runat="server" OnSelectedIndexChanged="ddlrostermonth_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Month" ForeColor="Red" ControlToValidate="ddlrostermonth"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblenddate" runat="server" Text="End Date" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:Calendar ID="DatePicker2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="DatePicker2_SelectionChanged">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                                <asp:TextBox ID="TxtTakeDate2" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please pick a date" ForeColor="Red" ControlToValidate="TxtTakeDate2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="btn-wrap">
            <div class="form-group" align="center">
                <input id="Reset1" type="reset" value="Reset" class="btn btn-default btn-color" />
                <asp:Button ID="BtnConfirm" runat="server" Text="Create Roster" OnClick="BtnConfirm_Click" class="btn btn-default btn-color"  />
            </div>
        </div>
        <%--data-toggle="modal" data-target="#myModal"--%>
        <%--Modelpopup--%>
        <div class="row">
            <%--<button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                data-toggle="modal" data-target="#myModal">
                Launch demo modal
            </button>--%>
            <div class="modal fade" id="myModal">
                <asp:UpdatePanel runat="server" ID="updatepnl">
                    <ContentTemplate>
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <%--<div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                            </div>--%>
                                <div class="modal-body">
                                    <asp:Label runat="server" ID="lblResult" Text=""></asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
