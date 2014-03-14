using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Search : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        private IEnumerable<Artist> artists = new List<Artist>();
        private IEnumerable<AlbumArtist> albums = new List<AlbumArtist>();

        public void Search_Click(object sender, EventArgs e) {
            try {
                artists = Service.SearchArtists(SearchBox.Text);
                albums = Service.SearchAlbums(SearchBox.Text);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the albums from the database");
                artists = new List<Artist>();
                albums = new List<AlbumArtist>();
            }
        }

        public IEnumerable<Artist> ArtistListView_GetData() {
            return artists;
        }

        public IEnumerable<AlbumArtist> AlbumListView_GetData() {
            return albums;
        }
    }
}