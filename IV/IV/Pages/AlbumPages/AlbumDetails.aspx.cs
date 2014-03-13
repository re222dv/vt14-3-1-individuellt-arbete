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

        private int? artistId;

        protected void Page_Load(object sender, EventArgs e) {}

        public AlbumArtist AlbumFormView_GetItem([RouteData]int id) {
            try {
                var album = Service.GetAlbumById(id);

                artistId = album.ArtistID;

                return album;
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the album from the database");
                return null;
            }
        }

        public void AlbumFormView_UpdateItem(int AlbumId) {
            AlbumArtist item;
            try {
                item = Service.GetAlbumById(AlbumId);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the album from the database");
                return;
            }
            if (item == null) {
                ModelState.AddModelError(String.Empty, String.Format("Album with id {0} was not found", AlbumId));
                return;
            }

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveAlbum(item);

                    try {
                        var picUpload = AlbumFormView.FindControl("PicUpload") as FileUpload;
                        if (picUpload.HasFile) {
                            Service.SaveAlbumArt(picUpload.FileContent, item.AlbumID);
                        }

                        this.SetTempData("SuccessMessage", "The album was saved.");
                        Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                        Context.ApplicationInstance.CompleteRequest();
                    } catch {
                        ModelState.AddModelError(String.Empty, "Error while saving the album picture");
                    }
                } catch {
                    ModelState.AddModelError(String.Empty, "Error while saving the album to the database");
                }
            }
        }

        protected void AlbumFormView_DataBound(object sender, EventArgs e) {
            if (artistId == null) {
                var artistName = AlbumFormView.FindControl("ArtistName");
                artistName.Visible = false;
            }
        }
    }
}