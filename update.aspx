<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="update.aspx.vb" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <h1>Update Stocks</h1>
    <table>
        <tr>
            <td>Stock ID</td>
            <td>
                <asp:TextBox ID="sid" runat="server" disabled></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Update Stock Name</td>
            <td>
                <asp:TextBox ID="sname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:center">
                <asp:Button ID="btn_upd" runat="server" Text="Update Stock" />
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

