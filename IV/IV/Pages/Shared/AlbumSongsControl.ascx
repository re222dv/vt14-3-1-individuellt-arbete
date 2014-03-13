<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumSongsControl.ascx.cs" Inherits="IV.Pages.Shared.AlbumSongsControl" ViewStateMode="Disabled" %>

<asp:ListView ID="SongListView" runat="server" ItemType="IV.Model.SongArtist" DataKeyNames="SongID"
    SelectMethod="SongListView_GetData" OnItemDataBound="SongListView_ItemDataBound">
    <LayoutTemplate>
        <table class="songs">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td><%#: Item.Number %></td>
            <td><%# Item.Name %></td>
            <asp:PlaceHolder ID="ArtistData" runat="server" Visible="false">
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>' CssClass="hover"><%#: Item.ArtistName %></asp:HyperLink>
                </td>
            </asp:PlaceHolder>
            <td><%#: Item.LengthMinutes %></td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <span class="empty">No songs<span>:(</span></span>
    </EmptyDataTemplate>
</asp:ListView>