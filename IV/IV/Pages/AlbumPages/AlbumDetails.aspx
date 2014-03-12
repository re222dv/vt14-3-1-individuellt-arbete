﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="IV.Pages.AlbumDetails" %>

<%@ Register Src="~/Pages/Shared/AlbumSongsControl.ascx" TagPrefix="uc" TagName="AlbumSongsControl" %>
<%@ Register Src="~/Pages/Shared/EditAlbumSongsControl.ascx" TagPrefix="uc" TagName="EditAlbumSongsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:FormView ID="AlbumFormView" runat="server" ItemType="IV.Model.AlbumArtist" DataKeyNames="AlbumID"
        SelectMethod="AlbumFormView_GetItem" UpdateMethod="AlbumFormView_UpdateItem" RenderOuterTable="False">
        <ItemTemplate>
            <div id="album">
                <asp:Image runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_270.jpg" %>' />
                <h1><%# Item.Name %></h1>
                <asp:HyperLink CssClass="hover" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>
                    <h2><%# Item.ArtistName %></h2>
                </asp:HyperLink>
                <span class="year"><%#: Item.Released.Year %></span>
            
                <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />
            </div>
            
            <div id="controls">
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDelete", new {id = Item.AlbumID}) %>'>Delete</asp:HyperLink>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div id="albumEdit">
                <asp:Image runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_150.jpg" %>' />
                <div id="input">
                    <div>
                        <span>Name</span><asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="35" Columns="35" />
                    </div>
                    <div>
                        <span>Released</span><asp:TextBox ID="Released" runat="server" TextMode="Date" Text='<%# Bind("Released", "{0:yyyy-MM-dd}")%>' MaxLength="10" Columns="10" />
                    </div>
                    <div>
                        <span>Picture</span><asp:FileUpload ID="PicUpload" runat="server" />
                    </div>
                </div>

                <div id="albumControls">
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Save</asp:LinkButton>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>Cancel</asp:HyperLink>
                </div>

                <uc:EditAlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" ArtistID="<%#: Item.ArtistID %>" />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
