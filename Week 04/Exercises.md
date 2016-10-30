# Week 04 - ORMS / Entity Framework


## Exercise Ef6
1. Create a new console app in VS Studio  
2. Install EntityFramework nuget package
3. Create a folder called model and add 2 classes (Blog, Post) inside it from the lectures
4. Create the Dbcontext
5. Enable migrations, create your first migration and update the database
6. Check the database that is created
7. Change the model and add User class and change Posts class according to this example

```csharp
public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        //Navigation Property
        public virtual ICollection<Post> Posts { get; set; }
    }

public class Post
    {
        //Primary Key
        public int Id { get; set; }
        [MaxLength(400)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        
        public int BlogId { get; set; }
        public int UserId { get; set; }

        //Navigation Property
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
        //Navigation Property
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
```

8. Add a migration and update the database
9. Seed the database
10. Go to Program.cs and create some methods like the lecture to check out this things
    1. Pull data from the Database
    2. Insert in the database a new object
    3. Find Data And Update It
    4. Find Data And Delete it
    5. Pull data in a simple Join (and check it in Sql Server Profiler)
    6. Do a sum and a count test
11. If your are ready try to do a model for your project database

