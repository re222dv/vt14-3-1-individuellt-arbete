using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.AlbumPages {
    public partial class AlbumDelete : Page {
        private int albumId;

        protected void Page_Load(object sender, EventArgs e) {}

        public AlbumArtist AlbumFormView_GetItem([RouteData]int id) {
            try {
                albumId = id;
                return Service.GetAlbumById(id);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the album from the database");
                return null;
            }
        }

        protected void Delete(object sender, EventArgs e) {
            try {
                Service.DeleteAlbum(albumId);

                this.SetTempData("SuccessMessage", "The album was removed.");
                Response.RedirectToRoute("Albums");
                Context.ApplicationInstance.CompleteRequest();
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when deleating the album from the database");
            }
        }
    }
}