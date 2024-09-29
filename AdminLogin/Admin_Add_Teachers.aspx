<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add_Teachers.aspx.cs" Inherits="Unommer.Admin_Add_Teachers" MasterPageFile="Admin_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Add Teacher</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="lblname" runat="server" Text="Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtTeacherFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtTeacherEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblsubjects" runat="server" Text="Subjects" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ListBoxTeacherSubjects" CssClass="form-control" runat="server" ></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbldesig" runat="server" Text="Designation" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="DropDownListTeacherDesignation" CssClass="form-control" runat="server">
                                    <asp:ListItem>Select Designation</asp:ListItem>
                                    <asp:ListItem>Class Teacher</asp:ListItem>
                                    <asp:ListItem>Assistant</asp:ListItem>
                                    <asp:ListItem>Principle</asp:ListItem>
                                    <asp:ListItem>Lab Assistant</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblclass" runat="server" Text="Class" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlTeacherClass" runat="server" Width="143px">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblsection" runat="server" Text="Section" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlTeacherSection" runat="server" Width="143px">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblstatus" runat="server" Text="Status" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:CheckBoxList ID="CheckBoxListTeacherStatus" runat="server">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Inactive</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div   >
        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="BtnAddTeacher" runat="server" Text="Add" OnClick="BtnAddTeacher_Click" class="btn btn-default btn-color" />
                <input id="Reset1" type="reset" value="reset" class="btn btn-default btn-color" />
            </div>
        </div>
    </div>
</asp:Content>




<%--<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h3>Add Teacher</h3>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="lblname" runat="server" Text="Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtTeacherFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtTeacherEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblsubjects" runat="server" Text="Subjects" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:ListBox ID="ListBoxTeacherSubjects" CssClass="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbldesig" runat="server" Text="Designation" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="DropDownListTeacherDesignation" CssClass="form-control" runat="server">
                                    <asp:ListItem>Select Designation</asp:ListItem>
                                    <asp:ListItem>Class Teacher</asp:ListItem>
                                    <asp:ListItem>Assistant</asp:ListItem>
                                    <asp:ListItem>Principle</asp:ListItem>
                                    <asp:ListItem>Lab Assistant</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblclass" runat="server" Text="Class" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlTeacherClass" runat="server" Width="143px">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblsection" runat="server" Text="Section" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlTeacherSection" runat="server" Width="143px">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblstatus" runat="server" Text="Status" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:CheckBoxList ID="CheckBoxListTeacherStatus" runat="server">
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Inactive</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="BtnAddTeacher" runat="server" Text="Add" Width="56px" OnClick="BtnAddTeacher_Click" />
                <input id="Reset1" type="reset" value="reset" />
            </div>
        </div>
    </div>
</asp:Content>
--%>
