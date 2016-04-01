<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delete.aspx.cs" Inherits="delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;text-align:center;
        }
    </style>
</head>
<body style="font-family: Arial, Helvetica, sans-serif">
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td style="font-size: x-large; font-weight: bold; color: #FFFFFF; background-color: #000000">Delete Page</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main.aspx">Return to MainData Page</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Are you sure you want to delete this record?</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Username:&nbsp;<%=uName %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Password:&nbsp;<%=pWord %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmdYes" runat="server" Text="Yes" OnClick="cmdYes_Click" />
&nbsp;&nbsp;
                    <asp:Button ID="cmdNo" runat="server" Text="No" OnClick="cmdNo_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
