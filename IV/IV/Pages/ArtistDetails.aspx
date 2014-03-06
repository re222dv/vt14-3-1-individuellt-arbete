<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="IV.Pages.ArtistDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="ArtistFormView" runat="server" ItemType="IV.Model.Artist" DataKeyNames="ArtistID"
        SelectMethod="ArtistFormView_GetItem">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_250x250.jpg" %>' />
            <h1><%#: Item.Name %></h1>
            <%#: Item.Formed.ToString("yyyy") %>

            <%#: Item.Description %>

            <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                SelectMethod="AlbumListView_GetData">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                        <h2><%#: Item.Name %></h2>
                    </asp:HyperLink>
                    <span><%#: Item.Released.Year %></span>
                    <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />
                </ItemTemplate>
            </asp:ListView>
            
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDelete", new {id = Item.ArtistID}) %>'>Delete</asp:HyperLink>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
