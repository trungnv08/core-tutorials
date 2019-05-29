using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTutorials.Models
{
    public class Users
    {
        //[Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UserId { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("first_name")]
        public string FirstName { get; set; }
        [BsonElement("last_name")]
        public string LastName { get; set; }
        [BsonElement("is_active")]
        public bool IsActive { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonIgnore]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

    }
}
