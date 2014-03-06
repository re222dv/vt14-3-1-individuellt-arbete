using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages.ArtistPages {
    public partial class ArtistDelete : System.Web.UI.Page {
        private int artistId;

        protected void Page_Load(object sender, EventArgs e) {

        }

        public Artist ArtistFormView_GetItem([RouteData]int id) {
            artistId = id;
            return Service.GetArtistById(id);
        }

        protected void Delete(object sender, EventArgs e) {
            Service.DeleteArtist(artistId);

            Page.SetTempData("SuccessMessage", "The artist was removed.");
            Response.RedirectToRoute("Artists");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}