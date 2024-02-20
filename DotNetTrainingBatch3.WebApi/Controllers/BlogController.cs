using DotNetTrainingBatch3.WebApi.EFCoreExamples;
using DotNetTrainingBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]

        public IActionResult GetBlogs()
        {
           List<BlogModel> lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpPost]

        public IActionResult CreateBlog()
        {
            return Ok("CreateBlog");
        }


        [HttpPut]

        public IActionResult UpdateBlog()
        {
            return Ok("UpdateBlog");
        }


        [HttpDelete]

        public IActionResult DeleteBlog()
        {
            return Ok("DeleteBlogs");
        }
    }
}
