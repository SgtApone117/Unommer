<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherDebrief.aspx.cs" Inherits="Unommer.TeacherDebrief" MasterPageFile="Teacher_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Teacher Debrief Page</h2>
            <div class="table-wrap table-responsive">
                <asp:GridView ID="grdshowdebrief" runat="server" AutoGenerateColumns="false" OnRowCommand="grdshowdebrief_RowCommand" DataKeyNames="Request_id" ShowFooter="true" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ShowHeaderWhenEmpty="false" EmptyDataText="No Meeting Left To Debiref" OnRowCreated="grdshowdebrief_RowCreated">
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle Wrap="false" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="hidden" />
                            <ItemStyle CssClass="hidden" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnreq" runat="server" Value='<%# Eval("Request_id") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="btncancel" runat="server" CommandArgument="" Text="Confirm" CssClass="CollabButton" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Select
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkboxdebrief" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxdebrief_CheckedChanged" />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Parent's Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblparentmail" Text='<%# Eval("u_name")%>'> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Date of collaboration
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblparentname" Text='<%# Eval("Date_Of_Request") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Student First Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblstudfname" Text='<%# Eval("Student_fname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Student Last Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblstudlname" runat="server" Text='<%# Eval("Student_lname")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Class
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblclass" runat="server" Text='<%# Eval("Class1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Section
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblsection" runat="server" Text='<%# Eval("Section1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Subject
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblsubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Start Time
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblstarttime" runat="server" Text='<%# Eval("Start_Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                End Time
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblendtime" runat="server" Text='<%# Eval("End_Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Collaboration Type
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcollabtype" runat="server" Text='<%# Eval("Collaboration_Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblsubject" runat="server" Text="Details of Debriefing"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtsubdeb" runat="server" AutoPostBack="true" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Attachment
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:FileUpload runat="server" ID="flup" Enabled="false" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
