using MongoDB.Bson.Serialization.Attributes;
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
        //   [Key]
        //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("categoryId")]
        public string CategoryId { get; set; }
        [JsonIgnore]
        [BsonIgnore]
        public virtual Category Category { get; set; }
    }
}
