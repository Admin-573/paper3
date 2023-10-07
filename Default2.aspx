<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <h3>User Registration</h3>
        <table>
            <tr>
                <td>User ID</td>
                <td>
                    <asp:TextBox ID="uid" runat="server" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="uname" runat="server" required></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:center">
                    <asp:Button ID="btn_signup" runat="server" Text="SignUP" />
                </td>
            </tr>
        </table>

        <h3>User Login</h3>
        <table>
            <tr>
                <td>User ID</td>
                <td>
                    <asp:TextBox ID="lid" runat="server" disabled></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="lname" runat="server" disabled></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align:center">
                    <asp:Button ID="btn_login" runat="server" Text="Login" />
                </td>
            </tr>
        </table>

    <h3>User Can Purchase Stocks From Here</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="sid" HeaderText="Stock ID" />
            <asp:BoundField DataField="sname" HeaderText="Stock Name" />
            <asp:HyperLinkField DataNavigateUrlFields="sid" 
                DataNavigateUrlFormatString="purchase.aspx?sid={0}" HeaderText="Buy" 
                NavigateUrl="sid" Text="purchase" />
        </Columns>
    </asp:GridView>
    </center>
</asp:Content>

