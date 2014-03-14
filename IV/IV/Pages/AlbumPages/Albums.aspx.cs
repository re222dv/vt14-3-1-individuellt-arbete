using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IV.Model;

namespace IV.Pages {
    public partial class Albums : Page {
        protected void Page_Load(object sender, EventArgs e) {}

        public IEnumerable<AlbumArtist> ListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount) {
            try {
                return Service.GetAlbumsPageWise(maximumRows, startRowIndex, out totalRowCount);
            } catch {
                ModelState.AddModelError(String.Empty, "An error occured when getting the albums from the database");
                totalRowCount = 0;
                return null;
            }
        }
    }
}