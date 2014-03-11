using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class ArtistDetails : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        public Artist ArtistFormView_GetItem([RouteData]int id) {
            try {
                return Service.GetArtistById(id);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the artist from the database");
                return null;
            }
        }

        public IEnumerable<Album> AlbumListView_GetData([RouteData]int id) {
            try {
                return Service.GetAlbumsByArtistId(id);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the albums from the database");
                return null;
            }
        }

        public void ArtistFormView_UpdateItem(int ArtistID) {
            Artist item = Service.GetArtistById(ArtistID);
            if (item == null) {
                ModelState.AddModelError(String.Empty, String.Format("Artist with id {0} was not found", ArtistID));
                return;
            }

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveArtist(item);

                    try {
                        var picUpload = ArtistFormView.FindControl("PicUpload") as FileUpload;
                        if (picUpload.HasFile) {
                            Service.SaveArtistArt(picUpload.FileContent, item.ArtistID);
                        }

                        this.SetTempData("SuccessMessage", "The artist was saved.");
                        Response.RedirectToRoute("ArtistDetails", new {id = item.ArtistID});
                        Context.ApplicationInstance.CompleteRequest();
                    } catch {
                        ModelState.AddModelError(String.Empty, "Error while saving the artist picture");
                    }
                } catch {
                    ModelState.AddModelError(String.Empty, "Error while saving the artist in the database");
                }
            }
        }
    }
}