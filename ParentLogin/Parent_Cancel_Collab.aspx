<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parent_Cancel_Collab.aspx.cs" Inherits="Unommer.Parent_Cancel_Collab" MasterPageFile="Parent_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Parent Cancel Collaboration Page</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <asp:Panel ID="pnlreason" runat="server" CssClass="reason" Visible="false">
                            Reason for cancellation:-<br />
                            <asp:RadioButtonList ID="rdlcancel" runat="server" OnSelectedIndexChanged="rdlcancel_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Parent's Availability" Value="parent"></asp:ListItem>
                                <asp:ListItem Text="Teacher's Availability" Value="teacher"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please specify a reason for cancelling" ControlToValidate="rdlcancel" BorderColor="Red" Font-Underline="False" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                            </asp:Panel>
                        <asp:Panel ID="pnltextarea" runat="server" Visible="false">
                            <div class="form-group">
                            <asp:Label ID="lbltextarea" runat="server" Text="State the reason for cancelling" CssClass="control-label col-sm-2"></asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txttextarea" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                </div>
                        </asp:Panel>
                       <%-- <div class="table-wrap table-responsive">--%>
                            <asp:GridView ID="Grdcollabdata" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowCommand="Grdcollabdata_RowCommand" OnRowCreated="Grdcollabdata_RowCreated" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" EmptyDataText="No Collaborations Available">
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle Wrap="false" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="hidden" />
                                        <HeaderStyle CssClass="hidden" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnreqid" runat="server" Value='<%# Eval("Request_id")%>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btncancel" runat="server" CommandArgument="" Text="Cancel" CssClass="CollabButton" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkgrdparent" runat="server" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Teacher's Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblteacher_name" runat="server" Text='<%# Eval("u_name")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Date of the Request
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date_of_request").ToString().Substring(0,10) %>'></asp:Label>
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
                                            Mode of interaction
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblmode" runat="server" Text='<%# Eval("Collaboration_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    

                                </Columns>
                            </asp:GridView>
                           <%-- </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <%--Following are <asp:Label ID="lblparentmail" runat="server"></asp:Label> collaboration requests<br />
            <br/>--%>
        <%--   <asp:Label ID="lblshowifno" runat="server" Text="No Collaborations Available" Visible="false"></asp:Label>--%>
    </div>
</asp:Content>
