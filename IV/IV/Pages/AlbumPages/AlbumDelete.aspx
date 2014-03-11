<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDelete.aspx.cs" Inherits="IV.Pages.AlbumPages.AlbumDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="AlbumFormView" runat="server" ItemType="IV.Model.AlbumArtist" DataKeyNames="AlbumID"
                  SelectMethod="AlbumFormView_GetItem">
        <ItemTemplate>
            <p>Do you realy want to delete the album '<%# Item.Name %>' by '<%# Item.ArtistName %>'?<br />
                <strong>Warning! This will also delete all songs on this album.</strong>
            </p>
            <asp:LinkButton runat="server" OnClick="Delete">Yes</asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>No</asp:HyperLink>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
