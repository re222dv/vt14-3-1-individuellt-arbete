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
                            <asp:Image runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_150.jpg" %>' />
                            <asp:HyperLink runat="server" CssClass="hover" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                                <h2><%# Item.Name %></h2>
                            </asp:HyperLink>
                            <span><%#: Item.Released.Year %></span>
                        </div>
                        <uc:AlbumSongsControl runat="server" AlbumID="<%#: Item.AlbumID %>" />
                    </ItemTemplate>
                </asp:ListView>
            </div>
            
            <div id="controls">
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDelete", new {id = Item.ArtistID}) %>'>Delete</asp:HyperLink>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div id="artistEdit">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#: "~/Content/Images/Artists/" + Item.ArtistID + "_250x250.jpg" %>' />

                <div>
                    <span>Name</span> <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="20" Columns="20"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is requiered" ControlToValidate="Name" Display="None" />
                </div>
                <div>
                    <span>Formed</span> <asp:TextBox ID="Formed" runat="server" TextMode="Date" Text='<%# Bind("Formed", "{0:yyyy-MM-dd}")%>' MaxLength="10" Columns="10" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Formed is requiered" ControlToValidate="Formed" Display="None" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Formed is not a valid date" ControlToValidate="Formed" Display="None" ValidationExpression="^\d{4}-((0[1-9])|(1[0-2]))-(([0-2]\d)|(3[01]))$" />
                </div>
                <div>
                    <span>Picture</span> <asp:FileUpload ID="PicUpload" runat="server" />
                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Picture must be a jpeg" ControlToValidate="PicUpload" Display="None" ValidationExpression="^.+\.[jJ][pP][eE]?[gG]$" />
                </div>
                <div>
                    <span>Description</span>
                </div>
                <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Text='<%# BindItem.Description %>'></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Description is requiered" ControlToValidate="Description" Display="None" />
            
                <ul id="albumList">
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumNew", new {artistId = Item.ArtistID}) %>'>
                            Add Album
                        </asp:HyperLink>
                    </li>
                    <asp:ListView ID="AlbumListView" runat="server" ItemType="IV.Model.Album" DataKeyNames="AlbumID"
                        SelectMethod="AlbumListView_GetData">
                        <LayoutTemplate>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink runat="server" NavigateUrl='<%#: GetRouteUrl("AlbumDetails", new {id = Item.AlbumID}) %>'>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%#: "~/Content/Images/Albums/" + Item.AlbumID + "_150.jpg" %>' />
                                    <%# Item.Name %>
                                </asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </ul>
            </div>
            
            <div id="controls">
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Save</asp:LinkButton>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#: GetRouteUrl("ArtistDetails", new {id = Item.ArtistID}) %>'>Cancel</asp:HyperLink>
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
