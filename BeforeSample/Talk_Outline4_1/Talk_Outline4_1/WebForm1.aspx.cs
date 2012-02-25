using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Talk_Outline4_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "My .Ramblings - Home";
            if (!User.Identity.IsAuthenticated)
            {
                InsertPostPanel.Visible = false;
            }
            else
            {
                InsertPostPanel.Visible = true;
            }
        }

        protected void InsertPostForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                if (e.Exception.InnerException.GetType() == typeof(ApplicationException))
                {
                    e.ExceptionHandled = true;
                    e.KeepInInsertMode = true;
                    errormessage.Text = e.Exception.InnerException.Message;
                }
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}