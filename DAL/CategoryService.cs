//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using coreTutorials.Models;
//using System.Data;
//using System.Data.SqlClient;
//namespace coreTutorials.DAL
//{
//    public class CategoryService : ICategoryService
//    {
//        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-JAA51OK\\SQLEXPRESS;User ID=trungnv ;password=trungnv");


//        public Category AddCategory(Category category)
//        {
//            string sql = "INSERT INTO ";
//            if (category == null)
//            {
//                return null;
//            }
//            try
//            {
//                SqlCommand command = new SqlCommand();
//                //connection.Open();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//            return null;
//        }

//        public List<Category> GetCategories()
//        {
//            List<Category> Categories = new List<Category>();
//            string sql = "select * from Category; ";
//            try
//            {
//                SqlCommand command = new SqlCommand(sql, connection);
//                connection.Open();
//                SqlDataReader dataReader = command.ExecuteReader();
//                while (dataReader.Read())
//                {
//                    Category category = new Category();
//                    Int64 id = Int64.Parse(dataReader["CategoryId"].ToString());
//                    string name = dataReader["Name"].ToString();
//                    category.CategoryId = id;
//                    category.Name = name;
//                    Categories.Add(category);
//                }
//            }
//            catch (Exception)
//            {
//                return null;
//            }
//            return Categories;
//        }


//        public Category GetCategory(long CategoryId)
//        {
//            string sql = "SELECT * FROM CATEGORY WHERE CATEGORYID=@CategoryId";
//            SqlParameter parameter = new SqlParameter("@Category", SqlDbType.BigInt);
//            Category category = new Category();
//            try
//            {
//                SqlCommand command = new SqlCommand(sql, connection);
//                connection.Open();
//                command.Parameters.Add(parameter);
//                SqlDataReader dataReader = command.ExecuteReader();
//                while (dataReader.Read())
//                {
//                    Int64 id = Int64.Parse(dataReader["CategoryId"].ToString());
//                    string name = dataReader["Name"].ToString();
//                    category.CategoryId = id;
//                    category.Name = name;
//                }
//            }
//            catch (Exception)
//            {
//                return null;
//            }
//            //return Categories;
//            return category;
//        }

//        public Category RemoveCategory(long CategoryId)
//        {
//            throw new NotImplementedException();
//        }

//        public Category UpdateCategory(Category category)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
