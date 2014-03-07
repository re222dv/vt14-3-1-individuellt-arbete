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

        protected void Page_Load(object sender, EventArgs e) {

        }

        public IEnumerable<Song> SongListView_GetData() {
            return Service.GetSongsByAlbumId(int.Parse(AlbumID));
        }
    }
}