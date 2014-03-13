using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.Shared {
    public partial class EditAlbumSongsControl : UserControl {

        public String AlbumID {
            get;
            set;
        }

        public String ArtistID {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e) {}

        public IEnumerable<SongArtist> SongListView_GetData() {
            if (AlbumID == null) {
                return null;
            }

            
            if (ArtistID == null) {
                var artistHeader = SongListView.FindControl("ArtistHeader");

                artistHeader.Visible = true;
            }
            
            try {
                return Service.GetSongsByAlbumId(int.Parse(AlbumID));
            } catch {
                Page.ModelState.AddModelError(String.Empty, "An error occured when getting the songs from the database");
                return null;
            }
        }

        public void SongListView_InsertItem() {
            var item = new Song();

            if (TryUpdateModel(item)) {
                try {
                    item.AlbumID = int.Parse(AlbumID);

                    if (ArtistID != null) {
                        item.ArtistID = int.Parse(ArtistID);
                    }

                    Service.SaveSong(item);
                    
                    Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                    Context.ApplicationInstance.CompleteRequest();
                } catch {
                    Page.ModelState.AddModelError(String.Empty, "Error while adding the album to the database");
                }
            }
        }

        public void SongListView_DeleteItem(int SongID) {
            try {
                Service.DeleteSong(SongID);
            } catch {
                Page.ModelState.AddModelError(String.Empty, "An error occured when deleting the song in the database");
            }
        }

        public void SongListView_UpdateItem(int SongID) {
            Song item;
            try {
                item = Service.GetSongById(SongID);
            } catch {
                Page.ModelState.AddModelError(String.Empty, "An error occured while getting the song from the database.");
                return;
            }

            if (item == null) {
                Page.ModelState.AddModelError(String.Empty, String.Format("Song with id {0} was not found", SongID));
                return;
            }

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveSong(item);
                    
                    Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                    Context.ApplicationInstance.CompleteRequest();
                } catch {
                    Page.ModelState.AddModelError(String.Empty, "Error while saving the Song to the database");
                }
            }
        }

        protected void SongListView_ItemDataBound(object sender, ListViewItemEventArgs e) {
            if (ArtistID == null) {
                var artistData = e.Item.FindControl("ArtistData");
                artistData.Visible = true;
            }
        }


        public IEnumerable<Artist> DropDown_GetData() {
            try {
                return Service.GetArtists();
            } catch {
                Page.ModelState.AddModelError(String.Empty, "An error occured when getting the artists from the database");
                return null;
            }
        }

        protected void SongListView_ItemCreated(object sender, ListViewItemEventArgs e) {
            if ((e.Item != null) && (e.Item.ItemType == ListViewItemType.InsertItem)) {
                if (ArtistID == null) {
                    var artistInsert = e.Item.FindControl("ArtistInsert");

                    artistInsert.Visible = true;
                }
            }
        }
    }
}