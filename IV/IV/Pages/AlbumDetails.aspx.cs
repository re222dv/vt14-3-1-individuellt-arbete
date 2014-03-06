using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class AlbumDetails : Page {

        protected void Page_Load(object sender, EventArgs e) {
        }

        public AlbumArtist AlbumFormView_GetItem([RouteData]int id) {
            Art.PrepareAlbumArt(id, 250);
            return Service.GetAlbumById(id);
        }
    }
}