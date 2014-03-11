<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="IV.Pages.ArtistDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="ArtistFormView" runat="server" ItemType="IV.Model.Artist" DataKeyNames="ArtistID"
        SelectMethod="ArtistFormView_GetItem" UpdateMethod="ArtistFormView_UpdateItem" RenderOuterTable="False">
        <ItemTemplate>
            <div id="artist">
                <div id="image" style='background-image: url(<%#: "../Content/Images/Artists/" + Item.ArtistID + ".jpg" %>)'></div>
                <h1><%# Item.Name %></h1>
                <span id="year"><%#: Item.Formed.ToString("yyyy") %></span>

                <p><%# Item.Description %></p>

                <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                    SelectMethod="AlbumListView_GetData">
                    <ItemTemplate>
                        <div class="album">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_150.jpg" %>' />
                            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                                <h2><%# Item.Name %></h2>
                            </asp:HyperLink>
                            <span><%#: Item.Released.Year %></span>
                        </div>
                        <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />
                    </ItemTemplate>
                </asp:ListView>
            
                <div id="controls">
                    <asp:LinkButton runat="server" CommandName="Edit">Edit</asp:LinkButton>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDelete", new {id = Item.ArtistID}) %>'>Delete</asp:HyperLink>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_250x250.jpg" %>' />

            Name <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Name %>'></asp:TextBox>
            Formed <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Text='<%# Bind("Formed", "{0:yyyy-MM-dd}")%>'></asp:TextBox>
            Description <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Text='<%# BindItem.Description %>'></asp:TextBox>
            Picture <asp:FileUpload ID="PicUpload" runat="server" />
            
            <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumNew", new {artistId = Item.ArtistID}) %>'>Add Album</asp:HyperLink>
            <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                SelectMethod="AlbumListView_GetData">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                        <span><%# Item.Name %></span>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:ListView>
            
            <div id="controls">
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Save</asp:LinkButton>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>Cancel</asp:HyperLink>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
