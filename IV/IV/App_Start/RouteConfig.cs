using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IV.App_Start {
    public class RouteConfig {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("Albums", "albums/", "~/Pages/Albums.aspx");
            routes.MapPageRoute("AlbumDetails", "albums/{id}", "~/Pages/AlbumDetails.aspx");
            routes.MapPageRoute("AlbumDelete", "albums/{id}/delete", "~/Pages/AlbumPages/AlbumDelete.aspx");
            routes.MapPageRoute("Artists", "artists/", "~/Pages/Artists.aspx");
            routes.MapPageRoute("ArtistDetails", "artists/{id}", "~/Pages/ArtistDetails.aspx");
            routes.MapPageRoute("ArtistNew", "artists/{id}/new", "~/Pages/ArtistPages/NewArtist.aspx");
            routes.MapPageRoute("ArtistDelete", "artists/{id}/delete", "~/Pages/ArtistPages/ArtistDelete.aspx");
        }
    }
}