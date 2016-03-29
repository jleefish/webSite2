<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main</title>
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
                <td style="background-color: #000000; font-size: x-large; font-weight: bold; color: #FFFFFF">Main Data Page</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Click here to <a href="insert.aspx">insert a row</a>  in the tUser table</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="username" EmptyDataText="tUsers table is empty" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" SortExpression="username" />
                            <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                            <asp:ButtonField ButtonType="Button" CommandName="updateRow" HeaderText="Update Row" ShowHeader="True" Text="update" />
                            <asp:ButtonField ButtonType="Button" CommandName="deleteRow" HeaderText="Delete Row" ShowHeader="True" Text="delete" />
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
