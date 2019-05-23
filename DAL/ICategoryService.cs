using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreTutorials.Models;
namespace coreTutorials.DAL
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategory(Int64 CategoryId);
        Category AddCategory(Category category);
        Category RemoveCategory(Int64 CategoryId);
        Category UpdateCategory(Category category);
    }
}
