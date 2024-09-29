<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Unommer.Admin_Login" MasterPageFile="Admin_Master.Master" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>SCHOOL DETAIL UPDATE</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="form-group">
                            <asp:Label ID="lblademail" runat="server" Text="Admin Email" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TxtAdminEmail" runat="server" CssClass="form-control" AutoPostBack="TRUE" Enabled="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="table-wrap table-responsive">
                            <asp:GridView ID="GrdSchool" runat="server" Visible="False" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="false" EmptyDataText="No School found">
                                <Columns>
                                    <asp:BoundField HeaderText="School Name" DataField="name" />
                                    <asp:BoundField HeaderText="Address" DataField="address" />
                                    <asp:BoundField HeaderText="School Contact No" DataField="contact_no" />
                                    <asp:BoundField HeaderText="School Mobile No" DataField="mobile_no" />
                                    <asp:BoundField HeaderText="Administrator Name" DataField="administrator_name" />
                                </Columns>

                            </asp:GridView>
                            
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblnewaddress" runat="server" Text="Address" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TxtSchoolAddr" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblnewtelephonenumber" runat="server" Text="Telephone Number" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TxtSchoolTele" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblnewmobilenumber" runat="server" Text="Mobile Number" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TxtSchoolMobile" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="btnschoolsub" runat="server" OnClick="btnschoolsub_Click" Text="Submit" class="btn btn-default btn-color"/>
                <asp:Button id="reset1" runat="server" Text="Reset" CssClass="btn btn-default btn-color" OnClick="reset1_Click"/>
            </div>
        </div>

    </div>
</asp:Content>


