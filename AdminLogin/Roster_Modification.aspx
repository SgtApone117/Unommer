<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roster_Modification.aspx.cs" Inherits="Unommer.Roster_Modification" MasterPageFile="Teacher_Master.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="main-box">
            <h2>Update Roster</h2>
            <%--Roster Details of <asp:Label runat="server" ID="lblteacheremail"></asp:Label>
        <br />
        <br />--%>
            <div class="col-sm-12">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label ID="lblyear" runat="server" Text="Select Year" CssClass="month3"></asp:Label>
                        <asp:DropDownList ID="ddlyearteacher" CssClass="month2" runat="server" OnSelectedIndexChanged="ddlyearteacher_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblmonthteacher" runat="server" Text="Select Month" CssClass="month"></asp:Label>
                        <asp:DropDownList ID="ddlmonthteacher" runat="server" CssClass="month1" OnSelectedIndexChanged="ddlmonthteacher_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlleeg" runat="server" Visible="false">
                <img src="Images/legend-Without_border.png" class="legendcss1" />
            </asp:Panel>
            <div class="col-sm-12">
                <div class="form-group">
                    <div class="form-horizontal">
                        <div class="table-wrap table-responsive">
                            <asp:GridView runat="server" ID="grdshowroster" Visible="true" AutoGenerateColumns="false" ShowHeader="False" CellPadding="1" OnRowDataBound="grdshowroster_RowDataBound" OnRowCommand="grdshowroster_RowCommand" ShowFooter="true" OnSelectedIndexChanged="grdshowroster_SelectedIndexChanged" DataKeyNames="Date" OnRowCreated="grdshowroster_RowCreated" CssClass="table tablestyle table-bordered" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" EmptyDataText="No Roster Available">
                                <RowStyle Wrap="false" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnAdd" CommandName="Confirm" runat="server" Text="Update Roster" CssClass="CollabButton" />
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



</asp:Content>

