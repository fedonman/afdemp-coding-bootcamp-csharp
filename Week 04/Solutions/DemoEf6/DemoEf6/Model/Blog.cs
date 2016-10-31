using System.Collections.Generic;

namespace DemoEf6.Model
{
    public class Blog
    {
        //Primary Key
        public int Id { get; set; }
        public string Title { get; set; }

        //Navigation Property
        public virtual ICollection<Post> Posts { get; set; }
    }
}