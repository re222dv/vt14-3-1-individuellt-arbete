using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.AlbumPages {
    public partial class NewAlbum : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void InsertAlbum([RouteData] int artistId) {
            var item = new Album();

            item.ArtistID = artistId;

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveAlbum(item);

                    try {
                        var picUpload = FormView.FindControl("PicUpload") as FileUpload;
                        Art.SaveAlbumArt(picUpload.FileContent, item.AlbumID);

                        Response.RedirectToRoute("AlbumDetails", new {
                            id = item.AlbumID
                        });
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