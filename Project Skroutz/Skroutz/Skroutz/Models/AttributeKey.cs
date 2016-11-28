using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Skroutz.Models
{
    public enum AttributeDataType
    {
        Integer,
        String,
        Boolean
    }
    public class AttributeKey
    {
        public int Id { get; set; }
        [Display(Name="Attribute")]
        public string Name { get; set; }
        [Display(Name="Measurement Unit")]
        public string MeasurementUnit { get; set; }
        [Display(Name="Data Type")]
        public AttributeDataType DataType { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}