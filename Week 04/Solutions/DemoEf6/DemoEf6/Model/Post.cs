using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEf6.Model
{
    public class Post
    {
        //Primary Key
        public int Id { get; set; }
        public string Title { get; set; }

        //Foreing Key
        public int BlogId { get; set; }
        //Navigation Property
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
    }
}
