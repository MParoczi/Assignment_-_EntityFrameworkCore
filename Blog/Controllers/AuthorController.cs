using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Contexts;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BlogContext _context;

        public AuthorController(BlogContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            List<User> authors = await _context.Users.ToListAsync();

            return View(authors);
        }

        public async Task<IActionResult> Posts(string id)
        {
            IEnumerable<Post> query =
                from post in _context.Posts
                where post.UserId == id
                select post;
            
            dynamic myModel = new ExpandoObject();
            myModel.User = await _context.Users.FindAsync(id);
            myModel.Posts = query.ToList();

            return View(myModel);
            
        }
    }
}