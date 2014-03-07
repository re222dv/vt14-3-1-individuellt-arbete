using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Albums : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public IEnumerable<AlbumArtist> ListView_GetData() {
            var albums = Service.GetAlbums();

            foreach (var album in albums) {
                try {
                    Art.PrepareAlbumArt(album.AlbumID, 80);
                } catch {
                    //TODO
                }
            }

            return albums;
        }
    }
}