<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Landing_Page.aspx.cs" Inherits="Unommer.Admin_Landing_Page" MasterPageFile="Admin_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Admin Home</h2>
            <center>
            <h1>
                Teacher Collaboration Summary
            </h1>
                </center>
            <div class="col-sm-3">
                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search for teacher" CssClass="CollabButton" />

            <div class="table-wrap table-responsive">
                <asp:GridView runat="server" ID="grdteachermonth" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CssClass="table tablestyle table-bordered" OnPageIndexChanging="grdteachermonth_PageIndexChanging" EmptyDataText="No Record Found">
                    <HeaderStyle CssClass="gridheader" />
                    <Columns>
                        <asp:BoundField DataField="teacher_name" HeaderText="Teacher Name" />
                        <asp:BoundField DataField="january" HeaderText="January" />
                        <asp:BoundField DataField="february" HeaderText="February" />
                        <asp:BoundField DataField="march" HeaderText="March" />
                        <asp:BoundField DataField="april" HeaderText="April" />
                        <asp:BoundField DataField="may" HeaderText="May" />
                        <asp:BoundField DataField="june" HeaderText="June" />
                        <asp:BoundField DataField="july" HeaderText="July" />
                        <asp:BoundField DataField="august" HeaderText="August" />
                        <asp:BoundField DataField="september" HeaderText="September" />
                        <asp:BoundField DataField="october" HeaderText="October" />
                        <asp:BoundField DataField="november" HeaderText="November" />
                        <asp:BoundField DataField="december" HeaderText="December" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
