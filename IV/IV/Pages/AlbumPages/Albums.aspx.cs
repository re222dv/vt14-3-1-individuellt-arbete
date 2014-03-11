using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Albums : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        public IEnumerable<AlbumArtist> ListView_GetData() {
            try {
                return Service.GetAlbums();
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the albums from the database");
                return null;
            }
        }
    }
}