using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //PullDataFromTheDatabase();
            //InsertDataToTheDatabase();
            //FindDataAndUpdate();
            //FindDataAndDelete();
            ASimpleJoin();
            //CounAllPosts();
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
                Title = "My test Ef Blog",
                Posts = new List<Post>()
                {
                    new Post() { Title = "Test Post One" },
                    new Post() { Title = "Test Post Two" },
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
                var blog = db.Blogs.Where(b => b.Title == "My Ef Blog").FirstOrDefault();
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

        public static void ASimpleJoin()
        {
            //don't forget using System.Data.Entity;
            var lstBlogs = new List<Blog>();
            using (var db = new BlogContext()) {
                lstBlogs = db.Blogs.Include(b => b.Posts).ToList();
            }

            foreach (var b in lstBlogs) {
                Console.WriteLine($"This blog {b.Title} has this posts : ");
                foreach (var p in b.Posts) {
                    Console.WriteLine($"This is a post title : {p.Title}");
                }
            }
        }


        public static void CounAllPosts()
        {
            using (var db = new BlogContext()) {
                var totalPost = db.Posts.Count();
                Console.WriteLine($"Total posts {totalPost}");
            }

            using (var db = new BlogContext()) {
                var sumTotalLikesInPosts = db.Posts.Sum(x=>x.Likes);
                Console.WriteLine($"Total posts likes {sumTotalLikesInPosts}");
            }

            //...
        }
    }
}
