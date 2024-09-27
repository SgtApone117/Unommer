<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="portal_admin_restore_database.aspx.cs" Inherits="Unommer.portal_admin_restore_database" MasterPageFile="~/Portal_Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Restore Database</h2>
        
                <div class="col-sm-12">
                  <%--<div class="form-group">--%>
                        <div class="form-horizontal">
                            <div class="table-wrap table-responsive">
                                <asp:GridView ID="grdactiveschool" runat="server" AutoGenerateColumns="false" CssClass="table tablestyle table-bordered" EmptyDataText="No Record Available" OnRowCommand="grdshowactiveschools_RowCommand" ShowFooter="true" OnRowCreated="grdshowactiveschools_RowCreated">
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle Wrap="false" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle CssClass="hidden" />
                                            <ItemStyle CssClass="hidden" />
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnschoolname" runat="server" Value='<%# Eval("name") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnrestore" runat="server" Text="Restore Database" CommandArgument="" CommandName="RestoreDb" CssClass="CollabButton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="chkselect" runat="server"  OnCheckedChanged="chkselect_CheckedChanged" AutoPostBack="true"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField HeaderText="School Name" DataField="name" />
                                        <asp:BoundField HeaderText="Address" DataField="address" />
                                        <asp:BoundField HeaderText="City" DataField="city" />
                                        <asp:BoundField HeaderText="Contact No." DataField="contact_no" />
                                        <asp:BoundField HeaderText="Mobile No." DataField="mobile_no" />
                                        <asp:BoundField HeaderText="School Board" DataField="school_board" />
                                        <asp:BoundField HeaderText="Affiliation No" DataField="affiliation_no" />
                                        <asp:BoundField HeaderText="Administrator Name" DataField="administrator_name" />
                                         <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:FileUpload runat="server" ID="flpup" Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    <%--</div>--%>
                </div>
  
        </div>
    </div>


</asp:Content>
