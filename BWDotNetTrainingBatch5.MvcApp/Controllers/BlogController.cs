using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BWDotNetTrainingBatch5.Domain.Features;
using BWDotNetTrainingBatch5.MvcApp.Models;
using DotNetTrainingBatch5.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BWDotNetTrainingBatch5.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var lts = _blogService.GetBlogs();
            return View(lts);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogRequestModel request)
        {
            try
            {
                _blogService.CreateBlog(new TblBlog()
                {
                    BlogTitle = request.Title,
                    BlogAuthor = request.Author,
                    BlogContent = request.Content,
                    DeleteFlag = false
                });

                /*ViewBag.IsSuccess = true;
                ViewBag.Message = "Blog created successfully";*/
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog created successfully";
            }
            catch (Exception ex)
            { 
                /*ViewBag.IsSuccess = false;
                ViewBag.Message = ex.ToString();*/

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }
            
            return RedirectToAction("Index");
            // return View("Index");
            
            /*var lts = _blogService.GetBlogs();
            return View("Index", lts);*/
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            try
            {
                _blogService.DeleteBlog(id);
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }
            
            return RedirectToAction("Index");
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
        
        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogRequestModel request)
        {
            try
            {
                _blogService.UpdateBlog(id, new TblBlog()
                {
                    BlogTitle = request.Title,
                    BlogAuthor = request.Author,
                    BlogContent = request.Content,
                    DeleteFlag = false
                });

                /*ViewBag.IsSuccess = true;
                ViewBag.Message = "Blog created successfully";*/
                
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog updated successfully";
            }
            catch (Exception ex)
            { 
                /*ViewBag.IsSuccess = false;
                ViewBag.Message = ex.ToString();*/

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }
            
            return RedirectToAction("Index");
            // return View("Index");
            
            /*var lts = _blogService.GetBlogs();
            return View("Index", lts);*/
        }
    }
}