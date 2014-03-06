<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.AlbumControl" ViewStateMode="Disabled" %>

<asp:ListView ID="SongListView" runat="server" ItemType="IV.Model.Song" DataKeyNames="SongID"
    SelectMethod="SongListView_GetData">
    <LayoutTemplate>
        <table>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td><%#: Item.Number %></td>
            <td><%#: Item.Name %></td>
            <td><%#: Item.LengthMinutes %></td>
        </tr>
    </ItemTemplate>
    <InsertItemTemplate>
        <tr>
            <td>
                <asp:TextBox ID="NumberBox" runat="server" Text="<%#: BindItem.Number %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server" Text="<%#: BindItem.Name %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="LengthBox" runat="server" Text="<%#: BindItem.LengthS %>"></asp:TextBox>
            </td>
        </tr>
    </InsertItemTemplate>
</asp:ListView>