<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Modify_Delete_Teacher.aspx.cs" Inherits="Unommer.Admin_Modify_Delete_Teacher" MasterPageFile="Admin_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server" CssClass="gridview1" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
    <div class="container">
        <div class="main-box">
            <h2>View Teacher Data</h2>
            <div class="col-sm-3">
            <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            <asp:Button ID="btnsearch" runat="server" onclick="btnsearch_Click" Text="Search for teacher" CssClass="CollabButton"/>
            <div class="table-wrap table-responsive">
                <asp:GridView runat="server" ID="gvDetails" AllowPaging="true" PageSize="10" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="false" OnPageIndexChanging="gvDetails_PageIndexChanging"  EmptyDataText="No Teacher Available">
                    <HeaderStyle CssClass="gridheader" />
                    <Columns>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherName" runat="server" Text='<%# Eval("Teacher_fname")%>' />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherMail" runat="server" Text='<%# Eval("teacher_email")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Teacher_Designation")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Class">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherClass" runat="server" Text='<%# Eval("Class")%>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Section">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherSection" runat="server" Text='<%# Eval("class")%>'></asp:Label>
                            </ItemTemplate>
    
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Subject">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherSubject" runat="server" Text='<%# Eval("Teacher_Subjects")%>'></asp:Label>
                            </ItemTemplate>
     
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblTeacherStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                            </ItemTemplate>
          
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hdnsubjectid" Value='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblresult" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
