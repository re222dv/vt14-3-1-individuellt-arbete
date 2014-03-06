using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.AlbumPages {
    public partial class AlbumDelete : System.Web.UI.Page {
        private int albumId;

        protected void Page_Load(object sender, EventArgs e) {

        }

        public AlbumArtist AlbumFormView_GetItem([RouteData]int id) {
            albumId = id;
            return Service.GetAlbumById(id);
        }

        protected void Delete(object sender, EventArgs e) {
            Service.DeleteAlbum(albumId);

            Page.SetTempData("SuccessMessage", "The album was removed.");
            Response.RedirectToRoute("Albums");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}