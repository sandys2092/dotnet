<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 92px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">Title</td>
                    <td>
                        <asp:TextBox ID="txtTtile" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">Content</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server"></asp:TextBox></td>
                    
                </tr>
                
            </table>
        </div>
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
    </form>
</body>
</html>
