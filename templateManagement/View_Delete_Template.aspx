<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Delete_Template.aspx.cs" Inherits="Unommer.View_Delete_Template" MasterPageFile="Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function Disable() {
            $("#MsgBox").toggle();
            $("#MsgBox").css("display", "none");
        }

        window.setInterval(function () {
            Disable();
        }, 3000);

    </script>
    <div class="container">
        <div class="alert alert-success alert-dismissible" runat="server" id="MsgBox" style="display: none;">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <%--<strong>Success!</strong> This alert box could indicate a successful or positive action.--%>
            <asp:Label runat="server" ID="lblMsg" Font-Bold="true"></asp:Label>
        </div>
        <div class="main-box">
            <h2>View Template
            </h2>
            <div class="col-sm-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label ID="lblselecttemplate" runat="server" Text="Select Template" CssClass="control-label col-sm-2"></asp:Label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlselecttemp" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlselecttemp_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="table-wrap table-responsive">
                        <asp:GridView ID="grdviewtemplate" runat="server" AutoGenerateColumns="false" CssClass="table tablestyle table-bordered">
                            <HeaderStyle CssClass="gridheader" />
                            <Columns>
                                <asp:BoundField DataField="DoW" HeaderText="Day of the week" />
                                <asp:BoundField DataField="st1" HeaderText="Morning Start Time" />
                                <asp:BoundField DataField="et1" HeaderText="Morning End Time" />
                                <asp:BoundField DataField="st2" HeaderText="Afternoon Start Time" />
                                <asp:BoundField DataField="et2" HeaderText="Afternoon End Time" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </div>
        <asp:Panel ID="pnlbutton" runat="server" Visible="false">
            <div class="btn-wrap">
                <div class="form-group" align="center">
                    <asp:Button runat="server" ID="btndeletetemplate" OnClick="btndeletetemplate_Click" class="btn btn-default btn-color" Text="" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
