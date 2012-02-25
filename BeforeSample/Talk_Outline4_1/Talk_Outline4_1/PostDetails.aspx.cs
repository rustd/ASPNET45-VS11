using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Talk_Outline4_1.Model;

namespace Talk_Outline4_1
{
    public partial class PostDetails : System.Web.UI.Page
    {
        ObjectDataSourceModel odsmodel;
        Post post;
        protected void Page_Load(object sender, EventArgs e)
        {
            odsmodel = new ObjectDataSourceModel();
            try
            {
                if (Page.RouteData.Values["PostID"].ToString() != null)
                {
                    int postid;
                    int.TryParse(Page.RouteData.Values["PostID"].ToString(), out postid);
                    post = odsmodel.GetSinglePost(postid);
                    postName.Text = post.Title;
                    postdetails.Text = post.PostText;
                    this.Page.Title = "My .Ramblings - " + post.Title;
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            catch
            {
                Response.Redirect("~/");
            }
        }
        protected void insertcomment_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.RedirectToRoute("Post", new { PostID = post.ID });
        }
    }

}