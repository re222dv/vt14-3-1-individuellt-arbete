using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Artists : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public IEnumerable<Artist> ListView_GetData() {
            var artists = Service.GetArtists();

            foreach (var artist in artists) {
                try {
                    Art.PrepareArtistArt(artist.ArtistID, 80, 80);
                } catch {
                    //TODO
                }
            }

            return artists;
        }
    }
}