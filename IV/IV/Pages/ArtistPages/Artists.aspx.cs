using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Artists : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        public IEnumerable<Artist> ListView_GetData() {
            try {
                return Service.GetArtists();
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the artists from the database");
                return null;
            }
        }
    }
}