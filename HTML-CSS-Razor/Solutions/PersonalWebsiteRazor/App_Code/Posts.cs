namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int? CategoryId { get; set; }

        public DateTime? PostedOn { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
