using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BWDotNetTrainingBatch5.RestApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BWDotNetTrainingBatch5.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString;

        public BlogsAdoDotNetController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnection")!;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogViewModel> lts = new List<BlogViewModel>();
            
            SqlConnection connection = new SqlConnection(_connectionString);
            
            connection.Open();

            string query = @"
            SELECT 
                BlogId,
                BlogTitle,
                BlogAuthor,
                BlogContent,
                DeleteFlag
            FROM Tbl_Blog
            WHERE DeleteFlag = 0";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = new BlogViewModel()
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                };
                
                lts.Add(item);
            }
            
            connection.Close();
            return Ok(lts);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = new BlogViewModel();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT
                BlogId,
                BlogTitle,
                BlogAuthor,
                BlogContent,
                DeleteFlag
            FROM Tbl_Blog
            WHERE BlogId = @BlogId";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                item = new BlogViewModel()
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                };
            }
            
            connection.Close();
            return Ok(item);
        }
        
        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel blog)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            
            connection.Open();

            string query = @"
            INSERT INTO Tbl_Blog (
                BlogTitle,
                BlogAuthor,
                BlogContent,
                DeleteFlag
            ) VALUES (
                @BlogTitle,
                @BlogAuthor,
                @BlogContent,
                @DeleteFlag
            )";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            cmd.Parameters.AddWithValue("@DeleteFlag", blog.DeleteFlag);

            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            return Ok(result > 0 ? "Creating successful" : "Creating failed");
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogViewModel blog)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            UPDATE Tbl_Blog SET
                BlogTitle = @BlogTitle,
                BlogAuthor = @BlogAuthor,
                BlogContent = @BlogContent,
                DeleteFlag = @DeleteFlag
            WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            cmd.Parameters.AddWithValue("@DeleteFlag", blog.DeleteFlag);
            
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            return Ok(result > 0 ? "Updating successful" : "Updating failed");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogViewModel blog)
        {
            string conditions = "";
            if (!string.IsNullOrEmpty(blog.Title))
            {
                conditions += "BlogTitle = @BlogTitle,";
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                conditions += "BlogAuthor = @BlogAuthor,";
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                conditions += "BlogContent = @BlogContent,";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters");
            }
            
            conditions = conditions.Substring(0, conditions.Length - 1);
            
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"
            UPDATE Tbl_Blog SET
                {conditions}
            WHERE BlogId = @BlogId";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId", id);
            if (!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.Content);   
            }
            
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            
            
            return Ok(result > 0 ? "Updating successful" : "Updating failed");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";
            
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            return Ok(result > 0 ? "Deleting successful" : "Deleting failed");
        }
    }
}
