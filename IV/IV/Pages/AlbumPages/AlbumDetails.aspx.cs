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

        protected void Page_Load(object sender, EventArgs e) {
        }

        public AlbumArtist AlbumFormView_GetItem([RouteData]int id) {
            try {
                Art.PrepareAlbumArt(id, 250);
            } catch {
                //TODO
            }
            return Service.GetAlbumById(id);
        }

        public void AlbumFormView_UpdateItem(int AlbumId) {
            AlbumArtist item = Service.GetAlbumById(AlbumId);
            if (item == null) {
                ModelState.AddModelError("", String.Format("Album with id {0} was not found", AlbumId));
                return;
            }

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveAlbum(item);

                    try {
                        var picUpload = AlbumFormView.FindControl("PicUpload") as FileUpload;
                        if (picUpload.HasFile) {
                            Art.SaveAlbumArt(picUpload.FileContent, item.AlbumID);
                        }

                        Response.RedirectToRoute("AlbumDetails", new {id = item.AlbumID});
                        Context.ApplicationInstance.CompleteRequest();
                    } catch {
                        ModelState.AddModelError(String.Empty, "Error saving the album picture");
                    }
                } catch {
                    ModelState.AddModelError(String.Empty, "Error adding the album to the database");
                }
            }
        }
    }
}