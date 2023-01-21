using Microsoft.AspNetCore.Mvc;
using Posts.Logic;
using Posts.Models;

namespace Posts.Controllers
{
    public class PostController : Controller
    {
        PostManager postManager = new PostManager();
        public IActionResult Index()
        {
            var posts = postManager.GetPosts();
            return View(posts);
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PostModel postModel)
        {
            postManager.AddPost(postModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var post = postManager.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            postManager.RemovePost(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = postManager.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(PostModel post)
        {
            postManager.UpdatePost(post);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var post = postManager.GetPost(id);
            return View(post);
        }
    }
}
