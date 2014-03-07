using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.Shared {
    public partial class EditAlbumSongsControl : System.Web.UI.UserControl {

        public String AlbumID {
            get;
            set;
        }

        public String ArtistID {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        public IEnumerable<Song> SongListView_GetData() {
            return Service.GetSongsByAlbumId(int.Parse(AlbumID));
        }

        public void SongListView_InsertItem() {
            var item = new Song();

            if (TryUpdateModel(item)) {
                try {
                    item.AlbumID = int.Parse(AlbumID);
                    item.ArtistID = int.Parse(ArtistID);
                    Service.SaveSong(item);
                    
                    Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                    Context.ApplicationInstance.CompleteRequest();
                } catch {
                    //ModelState.AddModelError(String.Empty, "Error adding the album to the database");
                }
            }
        }

        public void SongListView_DeleteItem(int SongID) {
            try {
                Service.DeleteSong(SongID);
            } catch {
                //TODO
            }
        }

        public void SongListView_UpdateItem(int SongID) {
            Song item = Service.GetSongById(SongID);
            if (item == null) {
                //ModelState.AddModelError("", String.Format("Album with id {0} was not found", AlbumId));
                return;
            }

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveSong(item);
                    
                    Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                    Context.ApplicationInstance.CompleteRequest();
                } catch {
                    //ModelState.AddModelError(String.Empty, "Error adding the album to the database");
                }
            }
        }
    }
}