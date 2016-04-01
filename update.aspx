<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;text-align:center;
        }
        .auto-style2 {
            height: 40px;
        }
    </style>
</head>
<body style="font-family: Arial, Helvetica, sans-serif">
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td style="font-size: x-large; font-weight: bold; color: #FFFFFF; background-color: #000000">Update Page</td>
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
                <td class="auto-style2">Username:
                    <asp:TextBox ID="txtUName" runat="server"></asp:TextBox>
                    <asp:Label ID="lblErrUName" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Password:
                    <asp:TextBox ID="txtPWord" runat="server"></asp:TextBox>
                    <asp:Label ID="lblErrPWord" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmdUpdate" runat="server" OnClick="cmdUpdate_Click" Text="Update" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
