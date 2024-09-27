<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_Cancel_Collab.aspx.cs" Inherits="Unommer.Teacher_Cancel_Collab" MasterPageFile="Teacher_Master.master" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Cancel Collaboration</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <asp:Panel ID="pnlreason" runat="server">
                            Reason for cancellation :-<br />
                            <asp:RadioButtonList ID="rdlchoice" runat="server">
                                <asp:ListItem Value="teacher" Text="Teacher's Choice"></asp:ListItem>
                                <asp:ListItem Value="parent" Text="Parent's Choice"></asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>
                        <br />
                        <br />
                        <%-- <div class="table-wrap table-responsive">--%>
                        <asp:GridView ID="grdcollabreqshow" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Request_id" OnRowCommand="grdcollabreqshow_RowCommand" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" EmptyDataText="No Collaborations Left" OnRowCreated="grdcollabreqshow_RowCreated">
                            <HeaderStyle CssClass="gridheader" />
                            <RowStyle Wrap="false" />
                            <Columns>

                                <asp:TemplateField>
                                    <ItemStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnreq" runat="server" Value='<%# Eval("Request_id") %>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CommandArgument="" CssClass="CollabButton" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select" ShowHeader="true">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbox" runat="server" AutoPostBack="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                        <HeaderTemplate>
                                            Parent's Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblteacher_name" runat="server" Text='<%# Eval("u_name")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                <%--<asp:BoundField DataField="Request_id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"  />--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Date Of Request
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%--<header>te</header>--%>
                                        <asp:Label ID="lblreq" runat="server" Text='<%# Eval("Date_of_Request").ToString().Substring(0,10) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Start Time
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblstart" runat="server" Text='<%# Eval("Start_Time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        End Time
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblend" runat="server" Text='<%# Eval("End_Time") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:BoundField DataField="Date_of_Request" HeaderText="Date" />--%>
                                <%--     <asp:BoundField DataField="Start_Time" HeaderText="Start_Time" />
                   <asp:BoundField DataField="End_Time" HeaderText="End_Time" />--%>
                                <asp:BoundField DataField="Collaboration_Type" HeaderText="Collaboration type" />
                                <%--<asp:BoundField DataField="u_name" HeaderText="Requested to" />--%>
                            </Columns>
                        </asp:GridView>
                        <%--         </div>--%>
                        <%--  <asp:Label ID="lblerror" Text="No More Collaborations Available" runat="server" Visible="false"></asp:Label>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

