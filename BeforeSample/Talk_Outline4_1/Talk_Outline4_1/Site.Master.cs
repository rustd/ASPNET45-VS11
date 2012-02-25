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
            XDocument rssFeed = XDocument.Load("http://www.twitter.com/statuses/user_timeline/rustd.rss?count=5");
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