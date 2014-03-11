using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.ArtistPages {
    public partial class NewArtist : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        public void InsertArtist() {
            var item = new Artist();

            if (TryUpdateModel(item)) {
                try {
                    Service.SaveArtist(item);

                    try {
                        var picUpload = FormView.FindControl("PicUpload") as FileUpload;
                        Service.SaveArtistArt(picUpload.FileContent, item.ArtistID);

                        this.SetTempData("SuccessMessage", "The artist was created.");
                        Response.RedirectToRoute("ArtistDetails", new {id = item.ArtistID});
                        Context.ApplicationInstance.CompleteRequest();
                    } catch {
                        ModelState.AddModelError(String.Empty, "Error while saving the artist picture");
                    }
                } catch {
                    ModelState.AddModelError(String.Empty, "Error while adding the artist to the database");
                }
            }
        }
    }
}