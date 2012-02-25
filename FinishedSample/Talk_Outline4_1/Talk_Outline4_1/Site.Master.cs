using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Talk_Outline4_1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XDocument rssFeed = XDocument.Load(@"C:\Users\pranavra\Documents\talks\vslive2011\twitter.txt");
            var posts = from item in rssFeed.Descendants("item")
                        select new
                        {
                            Title = item.Element("title").Value,
                            Url = item.Element("link").Value,
                        };
            MyTweetsListView.DataSource = posts;
            MyTweetsListView.DataBind();
        }
    }
}