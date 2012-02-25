using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Talk_Outline4_1.Account {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            this.Page.Title = "My .Ramblings - Login";           
        }
        protected void loggedIn(object sender, EventArgs e) {
            Response.Redirect("~/");
        }
    }
}