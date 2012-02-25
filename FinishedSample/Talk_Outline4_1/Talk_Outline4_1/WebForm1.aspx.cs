using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Talk_Outline4_1.Model;

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

        public void InsertPost(Post newpost)
        {
            DatabaseEntities model = new DatabaseEntities();
           if(TryUpdateModel<Post>(newpost))            
            {
                newpost.PublishedDate = DateTime.Now;
                model.Posts.AddObject(newpost);
                model.SaveChanges();
                Response.Redirect("~/");
            }
        }

        
    }
}