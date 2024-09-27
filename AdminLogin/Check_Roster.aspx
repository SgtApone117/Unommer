<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Check_Roster.aspx.cs" Inherits="Unommer.Check_Roster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 267px;
            text-align: right;
        }

        .auto-style2 {
            width: 267px;
            text-align: right;
            height: 35px;
        }

        .auto-style3 {
            height: 35px;
        }

        .rowstyle{
            padding:1px 1px 1px 1px;
        }
        .auto-style4 {
            width: 148px;
        }
        .auto-style5 {
            height: 35px;
            width: 148px;
        }
        .auto-style6 {
            text-align: right;
            width: 84px;
        }
        .auto-style7 {
            width: 84px;
        }
        .auto-style8 {
            height: 35px;
            width: 84px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 98%; height: 212px;">
            <tr>
                <td class="auto-style1">Teacher_Email</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxtTeachMail" runat="server" OnTextChanged="TxtTeachMail_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <%--<tr>
                <td class="auto-style1">First Name</td>
                <td>
                    <asp:TextBox ID="TxtTeachFName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Last Name</td>
                <td>
                    <asp:TextBox ID="TxtTeachLName" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>--%>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LblShowMonth" runat="server" Text="Month:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="LblMonth" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Lblshowyear" runat="server" Text="Year:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblYear" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblShowStartDate" runat="server" Text="Start Date:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="LblStartT" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="LblShowEndDate" runat="server" Text="End Date:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="LblEndT" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LblShowUnitDur" runat="server" Text="Unit Duration:" Visible="False"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="LblUnitD" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            </table>
        <center>
        <asp:GridView ID="MainRoster" RowStyle-Font-Size="Small" runat="server" AutoGenerateColumns="False"
            ShowHeader ="False" CellPadding="7" OnRowDataBound="OnRowDataBound" CssClass="rowstyle" >            
            <Columns>                
                <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:dd/MM/yyyy}" ShowHeader="true"/>
                <asp:BoundField DataField="Day"/>
                <asp:BoundField DataField="U1"/>
                <asp:BoundField DataField="U2"/>
                <asp:BoundField DataField="U3"/>
                <asp:BoundField DataField="U4"/>
                <asp:BoundField DataField="U5"/>
                <asp:BoundField DataField="U6"/>
                <asp:BoundField DataField="U7"/>
                <asp:BoundField DataField="U8"/>            
                <asp:BoundField DataField="U9"/>
                <asp:BoundField DataField="U10"/>
                <asp:BoundField DataField="U11"/>
                <asp:BoundField DataField="U12"/>
                <asp:BoundField DataField="U13"/>
                <asp:BoundField DataField="U14"/>
                <asp:BoundField DataField="U15"/>
                <asp:BoundField DataField="U16"/>            
                <asp:BoundField DataField="U17"/>
                <asp:BoundField DataField="U18"/>
                <asp:BoundField DataField="U19"/>
                <asp:BoundField DataField="U20"/>
                <asp:BoundField DataField="U21"/>
                <asp:BoundField DataField="U22"/>
                <asp:BoundField DataField="U23"/>
                <asp:BoundField DataField="U24"/>            
                <asp:BoundField DataField="U25"/>
                <asp:BoundField DataField="U26"/>
                <asp:BoundField DataField="U27"/>
                <asp:BoundField DataField="U28"/>
                <asp:BoundField DataField="U29"/>
                <asp:BoundField DataField="U30"/>
                <asp:BoundField DataField="U31"/>
                <asp:BoundField DataField="U32"/>
                <asp:BoundField DataField="U33"/>
                <asp:BoundField DataField="U34"/>
                <asp:BoundField DataField="U35"/>
                <asp:BoundField DataField="U36"/>
            </Columns>          
        </asp:GridView>
            </center>
    </form>
</body>
</html>
