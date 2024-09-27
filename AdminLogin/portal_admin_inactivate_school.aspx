<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="portal_admin_inactivate_school.aspx.cs" Inherits="Unommer.portal_admin_inactivate_school" MasterPageFile="~/Portal_Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Inactivate School</h2>
            <asp:GridView ID="grdactiveschool" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" CssClass="table tablestyle table-bordered" AutoGenerateSelectButton="true" OnSelectedIndexChanged="grdactiveschool_SelectedIndexChanged">
                <HeaderStyle CssClass="gridheader" />
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnschoolid" runat="server"  Value='<%# Eval("school_id") %>' />
                            <asp:HiddenField ID="hdnadminemail" runat="server" Value='<%# Eval("administrator_mail") %>' />
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
                </Columns>

            </asp:GridView>
            
        </div>
    </div>
</asp:Content>
