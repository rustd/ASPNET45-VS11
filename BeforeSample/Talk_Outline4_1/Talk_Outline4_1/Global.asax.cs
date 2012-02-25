using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Talk_Outline4_1 {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            RouteTable.Routes.MapPageRoute("Post", "Post/{PostID}", "~/PostDetails.aspx");
            RouteTable.Routes.MapPageRoute("Contact", "Contact", "~/Contact.aspx");
            RouteTable.Routes.MapPageRoute("About", "About", "~/About.aspx");            
            RouteTable.Routes.MapPageRoute("Default", "", "~/WebForm1.aspx");
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}