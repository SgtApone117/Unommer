<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_collab_page.aspx.cs" Inherits="Unommer.main_collab_page" MasterPageFile="Parent_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
    <%-- <asp:Label ID="lblparemail" runat="server" Text="Parent Email :-"></asp:Label>--%>
    <%--<asp:Label ID="LblParentEmail" runat="server" Text="Label" Visible="false"></asp:Label>--%>
    <div class="container">
        <div class="main-box">
            <h2>Parent Collaboration</h2>
            <div class="centerdiv_02">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="table-wrap table-responsive">
                            <asp:GridView ID="GrdCollabStudDet" runat="server" AutoGenerateSelectButton="True" RowStyle-Wrap="true" AutoGenerateColumns="false" OnSelectedIndexChanged="GrdCollabStudDet_SelectedIndexChanged" DataKeyNames="Student_id" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                <Columns>
                                    <asp:BoundField HeaderText="First Name" DataField="Student_fname" />
                                    <asp:BoundField HeaderText="Last Name" DataField="Student_lname" />
                                    <asp:BoundField HeaderText="Class" DataField="Class" />
                                    <asp:BoundField HeaderText="Section" DataField="Section" />
                                    <asp:BoundField HeaderText="Roll No." DataField="Roll_no" />
                                    <asp:TemplateField>
                                        <HeaderStyle CssClass="hidden" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnstudentid" Value='<%# Eval("Student_id")%>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle CssClass="hidden" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="" DataField="Student_id" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="left-box">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Panel runat="server" ID="pnlStudentDetails" Visible="false">
                                <h2>Student Details</h2>
                                <div class="form-group">
                                    <asp:Label ID="lblstuparsubj" Text="Subject" runat="server" Visible="false" CssClass="control-label col-sm-2"></asp:Label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="DdlSubjectList" runat="server" OnSelectedIndexChanged="DdlSubjectList_SelectedIndexChanged" AutoPostBack="true" Visible="false" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="hidden">
                                    <asp:Label ID="lblparstuname" Text="Name" runat="server" CssClass="control-label col-sm-12"></asp:Label>
                                    <asp:TextBox runat="server" ID="TxtFtchdStudFNname" ReadOnly="true" CssClass="control-label col-sm-4" Style="text-align: center;" />
                                </div>
                                <div class="hidden">
                                    <asp:Label ID="lblparsturollno" Text="Roll no" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                    <asp:TextBox runat="server" ID="TxtFtchdRoll" ReadOnly="true" CssClass="control-label col-sm-1" Style="text-align: center;" />
                                    <asp:Label ID="lblparstuclass" Text="Class" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                    <asp:TextBox runat="server" ID="TxtFtchdStudClass" ReadOnly="true" CssClass="control-label col-sm-1" Style="text-align: center;" />
                                    <asp:Label ID="lblparstusection" Text="Section" runat="server" CssClass="control-label col-sm-2"></asp:Label>
                                    <asp:TextBox runat="server" ID="TxtFtchdStudSect" ReadOnly="true" CssClass="control-label col-sm-1" Style="text-align: center;" />
                                </div>
                                <div class="table-wrap table-responsive" style="width: 60%;">
                                    <asp:GridView runat="server" ID="GrdCollabTeacherSubject" AutoGenerateColumns="false" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows">
                                        <Columns>
                                            <asp:BoundField HeaderText="Teacher Name" DataField="teacher_name" ReadOnly="true" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>

            <div class="right-box">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="form-group">
                                <asp:Label ID="lblyear" runat="server" Text="Year" Visible="false" CssClass="control-label col-sm-2"></asp:Label>
                                <div class="col-sm-3">
                                    <asp:DropDownList runat="server" ID="ddlyear" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true" Visible="false" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblmonth" runat="server" Text="Month" Visible="false" CssClass="control-label col-sm-2"></asp:Label>
                                <div class="col-sm-3">
                                    <asp:DropDownList runat="server" ID="ddlmonth" Visible="false" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <asp:Panel ID="pnltypecollab" runat="server" Visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lblpartypeofcollab" Text="Type of Collaboration " runat="server" CssClass="control-label col-sm-4"></asp:Label>
                                    <div class="col-sm-12">
                                        <asp:RadioButtonList ID="RadioCollabType" runat="server" RepeatDirection="Vertical" CssClass="radio" AutoPostBack="true" OnSelectedIndexChanged="RadioCollabType_SelectedIndexChanged">
                                            <asp:ListItem Value="Chat" Text="Chat">  </asp:ListItem>
                                            <asp:ListItem Value="Meeting" Text="Meeting">  </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlmobile" runat="server" Visible="false">
                                <div class="form-group">
                                    <asp:Label ID="lblmobileno" Text="Enter Mobile no" runat="server" CssClass="control-label col-sm-4  "></asp:Label>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" ID="txtmobileno" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>

            <div class="fa-align-center">
                <div class="col-sm-12">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="table-wrap table-responsive">
                                <asp:GridView runat="server" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ID="grdshowroster" Visible="true" AutoGenerateColumns="false" ShowHeader="False" CellPadding="1" OnRowDataBound="grdshowroster_RowDataBound" OnRowCommand="grdshowroster_RowCommand" ShowFooter="true" OnSelectedIndexChanged="grdshowroster_SelectedIndexChanged" OnRowCreated="grdshowroster_RowCreated">

                                    <RowStyle Wrap="false" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnAdd" CommandName="Confirm" runat="server" Text="Confirm" CssClass="CollabButton" />
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblday" runat="server" Text='<%# Eval("Day")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk1" Enabled='<%# (Eval("U1").ToString() == "P" ? true : (Eval("U1").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U1").ToString() == "P" ? false: (Eval("U1").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk2" Enabled='<%# (Eval("U2").ToString() == "P" ? true : (Eval("U2").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U2").ToString() == "P" ? false: (Eval("U2").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk3" Enabled='<%# (Eval("U3").ToString() == "P" ? true : (Eval("U3").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U3").ToString() == "P" ? false:(Eval("U3").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk4" Enabled='<%# (Eval("U4").ToString() == "P" ? true : (Eval("U4").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U4").ToString() == "P" ? false:(Eval("U4").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk5" Enabled='<%# (Eval("U5").ToString() == "P" ? true : (Eval("U5").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U5").ToString() == "P" ? false:(Eval("U5").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk6" Enabled='<%# (Eval("U6").ToString() == "P" ? true : (Eval("U6").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U6").ToString() == "P" ? false:(Eval("U6").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk7" Enabled='<%# (Eval("U7").ToString() == "P" ? true : (Eval("U7").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U7").ToString() == "P" ? false:(Eval("U7").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk8" Enabled='<%# (Eval("U8").ToString() == "P" ? true : (Eval("U8").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U8").ToString() == "P" ? false:(Eval("U8").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk9" Enabled='<%# (Eval("U9").ToString() == "P" ? true : (Eval("U9").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U9").ToString() == "P" ? false:(Eval("U9").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk10" Enabled='<%# (Eval("U10").ToString() == "P" ? true : (Eval("U10").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U10").ToString() == "P" ? false:(Eval("U10").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk11" Enabled='<%# (Eval("U11").ToString() == "P" ? true : (Eval("U11").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U11").ToString() == "P" ? false:(Eval("U11").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk12" Enabled='<%# (Eval("U12").ToString() == "P" ? true : (Eval("U12").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U12").ToString() == "P" ? false:(Eval("U12").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk13" Enabled='<%# (Eval("U13").ToString() == "P" ? true : (Eval("U13").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U13").ToString() == "P" ? false:(Eval("U13").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk14" Enabled='<%# (Eval("U14").ToString() == "P" ? true : (Eval("U14").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U14").ToString() == "P" ? false:(Eval("U14").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk15" Enabled='<%# (Eval("U15").ToString() == "P" ? true : (Eval("U15").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U15").ToString() == "P" ? false:(Eval("U15").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk16" Enabled='<%# (Eval("U16").ToString() == "P" ? true : (Eval("U16").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U16").ToString() == "P" ? false:(Eval("U16").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk17" Enabled='<%# (Eval("U17").ToString() == "P" ? true : (Eval("U17").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U17").ToString() == "P" ? false:(Eval("U17").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk18" Enabled='<%# (Eval("U18").ToString() == "P" ? true : (Eval("U18").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U18").ToString() == "P" ? false:(Eval("U18").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk19" Enabled='<%# (Eval("U19").ToString() == "P" ? true : (Eval("U19").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U19").ToString() == "P" ? false:(Eval("U19").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk20" Enabled='<%# (Eval("U20").ToString() == "P" ? true : (Eval("U20").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U20").ToString() == "P" ? false:(Eval("U20").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk21" Enabled='<%# (Eval("U21").ToString() == "P" ? true : (Eval("U21").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U21").ToString() == "P" ? false:(Eval("U21").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk22" Enabled='<%# (Eval("U22").ToString() == "P" ? true : (Eval("U22").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U22").ToString() == "P" ? false:(Eval("U22").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk23" Enabled='<%# (Eval("U23").ToString() == "P" ? true : (Eval("U23").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U23").ToString() == "P" ? false:(Eval("U23").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk24" Enabled='<%# (Eval("U24").ToString() == "P" ? true : (Eval("U24").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U24").ToString() == "P" ? false:(Eval("U24").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk25" Enabled='<%# (Eval("U25").ToString() == "P" ? true : (Eval("U25").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U25").ToString() == "P" ? false:(Eval("U25").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk26" Enabled='<%# (Eval("U26").ToString() == "P" ? true : (Eval("U26").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U26").ToString() == "P" ? false:(Eval("U26").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk27" Enabled='<%# (Eval("U27").ToString() == "P" ? true : (Eval("U27").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U27").ToString() == "P" ? false:(Eval("U27").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk28" Enabled='<%# (Eval("U28").ToString() == "P" ? true : (Eval("U28").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U28").ToString() == "P" ? false:(Eval("U28").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk29" Enabled='<%# (Eval("U29").ToString() == "P" ? true : (Eval("U29").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U29").ToString() == "P" ? false:(Eval("U29").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk30" Enabled='<%# (Eval("U30").ToString() == "P" ? true : (Eval("U30").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U30").ToString() == "P" ? false:(Eval("U30").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk31" Enabled='<%# (Eval("U31").ToString() == "P" ? true : (Eval("U31").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U31").ToString() == "P" ? false:(Eval("U31").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk32" Enabled='<%# (Eval("U32").ToString() == "P" ? true : (Eval("U32").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U32").ToString() == "P" ? false:(Eval("U32").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk33" Enabled='<%# (Eval("U33").ToString() == "P" ? true : (Eval("U33").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U33").ToString() == "P" ? false:(Eval("U33").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk34" Enabled='<%# (Eval("U34").ToString() == "P" ? true : (Eval("U34").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U34").ToString() == "P" ? false:(Eval("U34").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk35" Enabled='<%# (Eval("U35").ToString() == "P" ? true : (Eval("U35").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U35").ToString() == "P" ? false:(Eval("U35").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk36" Enabled='<%# (Eval("U36").ToString() == "P" ? true : (Eval("U36").ToString()=="B"?true:false)) %>' Checked='<%# (Eval("U36").ToString() == "P" ? false:(Eval("U36").ToString()=="B"?true:false)) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="legend1">
            <div class="col-sm-12">
                <div class="form-group">
                    <asp:Panel ID="pnllgend" runat="server" Visible="false">
                        <img src="Images/legend-Without_border.png" />
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>


    <asp:Label ID="lblResult" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" ForeColor="Red"></asp:Label>


    <asp:HiddenField ID="HiddenField1" runat="server" />
    <%--<ajaxtoolkit:modalpopupextender id="mpePopUp" runat="server" popupcontrolid="PnlPopUp" backgroundcssclass="modalBackground" targetcontrolid="TxtPopTeachName"></ajaxtoolkit:modalpopupextender>--%>


    <%--<asp:Panel ID="PnlPopUp" runat="server" Visible="false">
            <table style="color: red;">
                <tr>
                    <td>Your collabration with teacher
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPopTeachName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>It is confirmed for 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCofirmDate" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>It will start at:- 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtStartDate" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>It will end at:- 
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEndDate" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnconfirm" runat="server" Text="Confirm" OnClick="grdshowroster_RowCommand" OnClientClick="Confirm()" />
                    </td>
                    <td>
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>--%>
</asp:Content>
