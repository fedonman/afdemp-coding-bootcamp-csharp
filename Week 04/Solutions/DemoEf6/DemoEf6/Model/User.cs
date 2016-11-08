using System.Collections.Generic;

namespace DemoEf6.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        //Navigation Property
        public virtual ICollection<Post> Posts { get; set; }
    }
}