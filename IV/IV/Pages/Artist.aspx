<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Artist.aspx.cs" Inherits="IV.Pages.Artist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" />
        <h1>Metallica</h1>

        <div>
            <asp:Image ID="Image2" runat="server" />
            <h2>Kill ‘em All</h2>
            <table>
                <tr>
                    <td>1</td>
                    <td>Hit the Lights</td>
                    <td>4:16</td>
                </tr>
            </table>
        </div>

        <div>
            <asp:Image ID="Image3" runat="server" />
            <h2>Metallica</h2>
            <table>
                <tr>
                    <td>2</td>
                    <td>Sad But True</td>
                    <td>5:24</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>Wherever I May Roam</td>
                    <td>6:44</td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
