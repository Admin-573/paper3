<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <h1>Admin Login</h1>
    <table>
        <tr>
            <td>Admin ID</td>
            <td>
                <asp:TextBox ID="id" runat="server" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Admin Password</td>
            <td>
                <asp:TextBox ID="pass" runat="server" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:center">
                <asp:Button ID="btn_login" runat="server" Text="Login" />
            </td>
        </tr>
    </table>
    <table>
        <h1>Add Stocks</h1>
        <tr>
            <td>Stock ID</td>
            <td>
                <asp:TextBox ID="sid" runat="server" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Stock Name</td>
            <td>
                <asp:TextBox ID="sname" runat="server" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:center">
                <asp:Button ID="btn_add" runat="server" Text="Add Stock" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="sid" HeaderText="Stock ID" />
            <asp:BoundField DataField="sname" HeaderText="Stock Name" />
            <asp:HyperLinkField DataNavigateUrlFields="sid" 
                DataNavigateUrlFormatString="update.aspx?sid={0}" HeaderText="Update" 
                NavigateUrl="sid" Text="update" />
        </Columns>
        </asp:GridView>
    </center>
</asp:Content>

