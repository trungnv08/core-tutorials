using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreTutorials.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string Username { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }


    }
}
