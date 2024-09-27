<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parent_Landing_Page.aspx.cs" Inherits="Unommer.Parent_Landing_Page" MasterPageFile="Parent_Master.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Parent Home</h2>
            <div class="table-wrap table-responsive">
                <asp:GridView ID="grdshowrosterday" runat="server" AutoGenerateColumns="false" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" EmptyDataText="No Collaborations Today">
                    <HeaderStyle CssClass="gridheader" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Date of Request
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date_of_Request").ToString().Substring(0,10) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Collaboration Type
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcollab" runat="server" Text='<%#Eval("Collaboration_Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Class
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblclass" runat="server" Text='<%#Eval("Class") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Section
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblsec" runat="server" Text='<%#Eval("Section") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Start Time
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblsttime" runat="server" Text='<%#Eval("Start_Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                End Time
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblendtime" runat="server" Text='<%#Eval("End_Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--                <asp:TemplateField>
                    <HeaderTemplate>
                                Debrief Details
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldebstat" runat="server" Text='<%#Eval("debrief_details") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                Topic of Collaboration
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcollab" runat="server" Text='<%#Eval("topic_of_collab") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <%--<asp:Label ID="lblcollabshow" Text="" Visible="false" runat="server"></asp:Label>--%>
</asp:Content>
