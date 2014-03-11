<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.AlbumSongsControl" ViewStateMode="Disabled" %>

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
            <td><%# Item.Name %></td>
            <td><%#: Item.LengthMinutes %></td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <table></table>
        <span>No songs</span>
    </EmptyDataTemplate>
</asp:ListView>