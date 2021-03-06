﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IV.Pages.Shared {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            SuccessLabel.Text = this.GetTempData("SuccessMessage") as String;
            SuccessPanel.Visible = !String.IsNullOrWhiteSpace(SuccessLabel.Text);
        }
    }
}