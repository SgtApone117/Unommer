<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="portal_admin_add_school.aspx.cs" Inherits="Unommer.portal_admin_add_school" MasterPageFile="~/Portal_Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Add School</h2>
            <div class="table-wrap table-responsive">
                <asp:GridView ID="grdshowschool" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" CssClass="table tablestyle table-bordered" AutoGenerateSelectButton="true" OnSelectedIndexChanged="grdshowschool_SelectedIndexChanged">
                   <HeaderStyle CssClass="gridheader" />
                     <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="hidden" />
                            <ItemStyle CssClass="hidden" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnschoolid" runat="server" Value='<%# Eval("school_id") %>'/>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:Button ID="btnaddschool" runat="server" Text="Create School"
                            </FooterTemplate>--%>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="School Name">
                             <ItemTemplate>
                                
                                 <asp:Label ID="lblschoolname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                       <%-- <asp:BoundField HeaderText="Name of School" DataField="name" />--%>
                        <asp:BoundField HeaderText="Address" DataField="address" />
                        <asp:BoundField HeaderText="City" DataField="city" />
                        <asp:BoundField HeaderText="Contact No" DataField="contact_no" />
                        <asp:BoundField HeaderText="Mobile No" DataField="mobile_no" />
                        <asp:BoundField HeaderText="School Board" DataField="school_board" />
                        <asp:BoundField HeaderText="Affiliation No" DataField="affiliation_no" />
                        <asp:BoundField HeaderText="Administrator Name" DataField="administrator_name" />
                        <asp:BoundField HeaderText="Administrator Mail" DataField="administrator_mail" />
                        <asp:BoundField HeaderText="Administrator Contact No" DataField="administrator_contactno" />
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
