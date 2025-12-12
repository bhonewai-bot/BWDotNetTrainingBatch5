using BWDotNetTrainingBatch5.Domain.Features;
using BWDotNetTrainingBatch5.MvcApp.Models;
using DotNetTrainingBatch5.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BWDotNetTrainingBatch5.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogAjaxController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ActionName("Index")]
        public IActionResult BlogList()
        {
            var lts = _blogService.GetBlogs();
            return View("BlogList", lts);
        }
        
        [ActionName("List")]
        public IActionResult BlogListAjax()
        {
            var lts = _blogService.GetBlogs();
            return Json(lts);
        }

        [ActionName("Create")]
        public IActionResult BlogCreateAjax()
        {
            return View("BlogCreate");
        }

        [ActionName("Save")]
        [HttpPost]
        public IActionResult BlogSave(BlogRequestModel request)
        {
            MessageModel model;
            try
            {
                _blogService.CreateBlog(new TblBlog()
                {
                    BlogTitle = request.Title,
                    BlogAuthor = request.Author,
                    BlogContent = request.Content,
                    DeleteFlag = false
                });
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog created successfully";

                model = new MessageModel(true, "Blog created successfully");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
                
                model = new MessageModel(false, ex.ToString());
            }

            return Json(model);
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.GetBlog(id);
            BlogRequestModel request = new BlogRequestModel()
            {
                Id = id,
                Title = blog.BlogTitle,
                Author = blog.BlogAuthor,
                Content = blog.BlogContent,
            };

            return View("BlogEdit", request);
        }

        [ActionName("Update")]
        [HttpPost]
        public IActionResult BlogUpdate(int id, BlogRequestModel request)
        {
            MessageModel model;
            try
            {
                _blogService.UpdateBlog(id, new TblBlog()
                {
                    BlogTitle = request.Title,
                    BlogAuthor = request.Author,
                    BlogContent = request.Content,
                });
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog updated successfully";
                
                model = new MessageModel(true, "Blog updated successfully");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
                
                model = new MessageModel(false, ex.ToString());
            }
            
            return Json(model);
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult BlogDelete(BlogRequestModel request)
        {
            MessageModel model;
            try
            {
                _blogService.DeleteBlog(request.Id);
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog deleted successfully";
                
                model = new MessageModel(true, "Blog deleted successfully");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
                
                model = new MessageModel(false, ex.ToString());
            }
            
            return Json(model);
        }
        
        public class MessageModel
        {
            public MessageModel()
            {
                
            }

            public MessageModel(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }
            
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }
    }
}