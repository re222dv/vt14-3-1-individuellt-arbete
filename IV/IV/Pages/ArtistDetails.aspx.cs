using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class ArtistDetails : Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        public Artist ArtistFormView_GetItem([RouteData]int id) {
            Art.PrepareArtistArt(id, 250, 250);
            return Service.GetArtistById(id);
        }

        public IEnumerable<Album> AlbumListView_GetData([RouteData]int id) {
            return Service.GetAlbumsByArtistId(id);
        }
    }
}