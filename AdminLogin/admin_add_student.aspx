<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_add_student.aspx.cs" Inherits="Unommer.admin_add_student" MasterPageFile="Admin_Master.master"  %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div class="main-box">
            <h2>Add Student</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="lblfirstname" Text="First Name" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbllastname" runat="server" Text="Last Name" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblclass" Text="Class" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="DropDownStudentClass" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Class" ForeColor="Red" InitialValue="Select Class" ControlToValidate="DropDownStudentClass"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblsection" runat="server" Text="Section" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="DropDownStudentSection" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Section" ForeColor="Red" InitialValue="Select Section" ControlToValidate="DropDownStudentSection"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblrollno" runat="server" Text="Roll No" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentRollNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblfemail" runat="server" Text="Father Email" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentFatherEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblmemail" runat="server" Text=" Mother Email" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentMotherEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblgmail" runat="server" Text="Guardian Email" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TxtStudentGuardianEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblstatus" runat="server" Text="Status" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:CheckBoxList ID="StatusCheckBox" runat="server">
                                    <asp:ListItem Value="Active">Active</asp:ListItem>
                                    <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="btn-wrap">
            <div class="form-group" align="center">
                <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Add" class="btn btn-default btn-color" />
                <input id="Reset1" type="reset" value="Reset" class="btn btn-default btn-color" />
            </div>
        </div>

        <div class="table-wrap table-responsive">
            <asp:GridView ID="GrdStudentRecord" runat="server" AutoGenerateColumns="true" CssClass="table tablestyle table-bordered">
                <HeaderStyle CssClass="gridheader" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

