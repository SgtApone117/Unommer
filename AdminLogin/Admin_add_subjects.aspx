<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_add_subjects.aspx.cs" EnableViewState="true" Inherits="Unommer.Admin_add_subjects" MasterPageFile="Admin_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Add Subjects to Teachers</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-group">
                        <div class="form-horizontal">
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlteacherlist" runat="server" OnSelectedIndexChanged="ddlteacherlist_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="table-wrap">
            <asp:GridView ID="grdshowteacherdetails" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowCommand="grdshowteacherdetails_RowCommand" CssClass="table tablestyle table-bordered" OnRowCreated="grdshowteacherdetails_RowCreated" OnRowDataBound="grdshowteacherdetails_RowDataBound" OnRowEditing="grdshowteacherdetails_RowEditing" OnRowCancelingEdit="grdshowteacherdetails_RowCancelingEdit" OnRowUpdating="grdshowteacherdetails_RowUpdating">
                <RowStyle Wrap="true" />
                <%--HeaderStyle-CssClass="header" RowStyle-CssClass="rows" --%>
                <HeaderStyle CssClass="gridheader" Wrap="true" />
                <Columns>
                    <%--<asp:BoundField DataField="serialno" HeaderText="Serial No" ReadOnly="true"/>--%>
                    <asp:TemplateField>
                        <ItemStyle CssClass="hidden" />
                        <HeaderStyle CssClass="hidden" />
                        <ItemTemplate>
                            <asp:HiddenField ID="lblteacherid" runat="server" Value='<%# Eval("teacher_id") %>'></asp:HiddenField>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HiddenField ID="lblteacherid" runat="server" Value='<%# Eval("teacher_id") %>'></asp:HiddenField>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnadd" runat="server" Text="Add Subjects" OnClick="btnadd_Click" CssClass="CollabButton" />
                            <asp:Button ID="btnViewmore" CommandArgument="<%# ((GridViewRow) Container).RowIndex %> " CommandName="More" runat="server" Text="Confirm Subject" CssClass="CollabButton" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject" HeaderStyle-Width="25%">
                        <%--     <HeaderTemplate>
                                <asp:Label ID="lblsubjhead" Text="Subject" runat="server"></asp:Label>
                            </HeaderTemplate>--%>
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlsubject" CssClass="form-control"></asp:DropDownList>
                            <%-- <asp:TextBox ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:TextBox>--%>
                            <asp:HiddenField ID="hdnsubject" runat="server" Value='<%# Eval("Subject") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtsubject" runat="server" Text='<%# Eval("Subject") %>' ReadOnly="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Class" HeaderStyle-Width="25%">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlclass" runat="server" CssClass="form-control"></asp:DropDownList>
                            <%--<asp:TextBox ID="lblclass" runat="server" Text='<%# Eval("Class") %>'></asp:TextBox>--%>
                            <asp:HiddenField ID="hdnclass" runat="server" Value='<%# Eval("Class") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtclass" runat="server" Text='<%# Eval("Class") %>' ReadOnly="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Section" HeaderStyle-Width="25%">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlsection" runat="server" CssClass="form-control"></asp:DropDownList>
                            <%--<asp:TextBox ID="lblsection" runat="server" Text='<%# Eval("Section") %>'></asp:TextBox>--%>
                            <asp:HiddenField ID="hdnsection" runat="server" Value='<%# Eval("Section") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtsection" runat="server" Text='<%# Eval("Section") %>' ReadOnly="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="25%">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control"></asp:DropDownList>
                            <%--<asp:TextBox ID="lblstatus" runat="server" Text='<%# Eval("Status") %>'></asp:TextBox>--%>
                            <asp:HiddenField runat="server" ID="hdnstatus" Value='<%# Eval("Status") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlstat" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField runat="server" ID="hdnstat" Value='<%# Eval("Status") %>'></asp:HiddenField>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ControlStyle-Font-Bold="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>



</asp:Content>
