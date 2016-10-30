using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEf6.Model;

namespace DemoEf6
{
    class Program
    {
        static void Main(string[] args)
        {
            PullDataFromTheDatabase();
            InsertDataToTheDatabase();
        }

        public static void PullDataFromTheDatabase()
        {
            var lstPosts = new List<Post>();
            using (var db = new BlogContext()) {
                lstPosts = db.Posts.ToList();
            }

            foreach (var p in lstPosts) {
                Console.WriteLine($"Post with id {p.Id} has the title {p.Title}.");
            }
        }
        
        public static void InsertDataToTheDatabase()
        {
            var blog = new Blog()
            {
                Title = "My Ef Blog",
                Posts = new List<Post>()
                {
                    new Post() { Title = "Post One" },
                    new Post() { Title = "Post Two" },
                }
            };
            using (var db = new BlogContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
        
        public static void FindDataAndUpdate()
        {
            using (var db = new BlogContext())
            {
                var blog = db.Blogs.Where(b => b.Title == "Post Two").FirstOrDefault();
                blog.Title = "My Awesome Ef Blog";
                db.SaveChanges();
            }
        }

        public static void FindDataAndDelete()
        {
            using (var db = new BlogContext()) {
                var post = db.Posts.FirstOrDefault(p => p.Title == "Post Two");
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }
    }
}
