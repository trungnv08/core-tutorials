using FluentValidation;
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
        [BsonDefaultValue(true)]
        public bool IsActive { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonIgnore]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

    }
    public class UsersValidator : AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(user => user.Username).NotEmpty();
            RuleFor(user => user.Password).NotEmpty().MinimumLength(6);
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
        }
    }
}
