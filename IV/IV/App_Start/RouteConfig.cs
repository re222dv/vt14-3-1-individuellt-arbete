using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IV.App_Start {
    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("Albums", "albums/", "~/Pages/AlbumPages/Albums.aspx");
            routes.MapPageRoute("AlbumDetails", "albums/{id}", "~/Pages/AlbumPages/AlbumDetails.aspx");
            routes.MapPageRoute("AlbumDelete", "albums/{id}/delete", "~/Pages/AlbumPages/AlbumDelete.aspx");
            routes.MapPageRoute("Artists", "artists/", "~/Pages/ArtistPages/Artists.aspx");
            routes.MapPageRoute("ArtistNew", "artists/new", "~/Pages/ArtistPages/NewArtist.aspx");
            routes.MapPageRoute("ArtistDetails", "artists/{id}", "~/Pages/ArtistPages/ArtistDetails.aspx");
            routes.MapPageRoute("ArtistDelete", "artists/{id}/delete", "~/Pages/ArtistPages/ArtistDelete.aspx");
            routes.MapPageRoute("AlbumNew", "artists/{artistId}/newalbum", "~/Pages/AlbumPages/NewAlbum.aspx");

            routes.MapPageRoute("Error", "error", "~/Pages/Shared/Error.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/ArtistPages/Artists.aspx");
        }
    }
}