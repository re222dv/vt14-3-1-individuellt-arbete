using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.Shared {
    public partial class AlbumSongsControl : System.Web.UI.UserControl {

        public String AlbumID {
            get;
            set;
        }

        public String ArtistID {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (ArtistID == null) {
                //var artistHeader = SongListView.FindControl("ArtistHeader");
                //artistHeader.Visible = true;
            }
        }

        public IEnumerable<SongArtist> SongListView_GetData() {
            try {
                return Service.GetSongsByAlbumId(int.Parse(AlbumID));
            } catch {
                Page.ModelState.AddModelError(String.Empty, "An error occured when getting the songs from the database");
                return null;
            }
        }

        protected void SongListView_ItemDataBound(object sender, ListViewItemEventArgs e) {
            if (ArtistID == null) {
                var artistData = e.Item.FindControl("ArtistData");
                artistData.Visible = true;
            }
        }
    }
}