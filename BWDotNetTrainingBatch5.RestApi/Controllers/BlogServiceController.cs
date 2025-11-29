using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BWDotNetTrainingBatch5.Domain.Features;
using DotNetTrainingBatch5.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BWDotNetTrainingBatch5.RestApi.Controllers
{
    // Presentation Layer
    [Route("api/[controller]")]
    [ApiController]
    public class BlogServiceController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogServiceController(IBlogService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lts = _service.GetBlogs();
            return Ok(lts);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _service.GetBlog(id);
            if (item is null)
            {
                return NotFound(new { message = "Blog not found" });
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            var model = _service.CreateBlog(blog);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            var item = _service.UpdateBlog(id, blog);
            if (item is null)
            {
                return NotFound(new { message = "Blog not found" });
            }
            
            return Ok(item);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, TblBlog blog)
        {
            var item = _service.PatchBlog(id, blog);
            if (item is null)
            {
                return NotFound(new { message = "Blog not found" });
            }

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = _service.DeleteBlog(id);
            if (item is null)
            {
                return NotFound(new { message = "Blog not found" });
            }
            
            return Ok();
        }
    }
}
