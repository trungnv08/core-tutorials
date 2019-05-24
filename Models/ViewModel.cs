using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTutorials.Models
{
    public class ViewModel // this class using for views from tranfer object of controller
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
        public SessionModel SessionModel { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Users User { get; set; }
    }
}
