using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Talk_Outline4_1.Model;


namespace Talk_Outline4_1.Model
{
    public class ObjectDataSourceModel
    {
        public ObjectDataSourceModel()
        {
        }

        public IEnumerable<Post> GetPosts()
        {
            DatabaseEntities model = new DatabaseEntities();
            return model.Posts.AsEnumerable<Post>();

        }

        public void InsertPost(Post newpost)
        {
            DatabaseEntities model = new DatabaseEntities();
            if (newpost.Title == "" || newpost.Title == null)
            {
                throw new ApplicationException("please enter a post title");
            }
            else
            {
                newpost.PublishedDate = DateTime.Now;
                model.Posts.AddObject(newpost);
                model.SaveChanges();
            }
        }

        public Post GetSinglePost(int postID)
        {
            DatabaseEntities model = new DatabaseEntities();
            return model.Posts.Where(p => p.ID == postID).Single();
        }

        public IEnumerable<Comment> GetComments(int PostID)
        {
            DatabaseEntities model = new DatabaseEntities();
            return model.Comments.Where(c => c.PostID == PostID).AsEnumerable<Comment>();

        }

        public void InsertComment(int PostID, string CommentText, string author)
        {
            DatabaseEntities model = new DatabaseEntities();

            Comment newcomment = new Comment()
            {
                CommentText = CommentText,
                PublishedDate = DateTime.Now,
                PostID = PostID,
                Author = author
            };
            model.Comments.AddObject(newcomment);
            model.SaveChanges();

        }
    }
}