using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTutorials.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ProductId { get; set; }
        public String Name { get; set; }
        [ForeignKey("Categories")]
        public Int64 CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
