# Week 04
## Entity Framework / HTML & CSS / Bootstrap Framework / Razor


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


## Exercise `Personal Website - HTML`
Your ultimate task is to create a fully functional Personal Website (PW). The PW has three pages:
1. __Home__ page. The home page consists of:
  * Heading with your tagline
  * A photo of you and short description
  * List of academic experience
  * List of hobbies
2. __Blog__ page. The blog page includes a list of posts.
  * Each post has a title, date, category and content.
  * Content may include text, images, videos organized in one or more sections. Create at least 3-4 different variations. You can use real-world posts.
  * Blog page also has a search field for searching posts and a dropdown for selecting category.
3. __Contact__ page. The contact page has two sections:
  * A short call-to-action: why someone should contact you.
  * A form for contacting you. The form should have, at least, Name*, Email*, Message* fields.

All pages have
* a header (title of the page + navigation menu)
* a footer (copyright info)

Since current PW is a static website, you have to hardcode every information. Try to use semantically correct HTML!
