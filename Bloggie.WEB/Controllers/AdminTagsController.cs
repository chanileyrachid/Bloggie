using Microsoft.AspNetCore.Mvc;

namespace Bloggie.WEB.Controllers
{
    public class AdminTagsController : Controller
    {
        //to specify that this is a get method that gets the add view
        [HttpGet]
        public IActionResult Add()
        {
            //shortcut to create a view is to right click on view and select razor view-empty
            return View();
        }

        //We need an HTTP post method to post the data received from the user
        [HttpPost]
        //We need to specify the html the data is coming from with an actionName
        [ActionName("Add")]
        public IActionResult SubmitTag()
        {
            //we need to get datas from the tag form
            var name = Request.Form["name"];
            var displayName = Request.Form["displayName"];
            return View("Add");
        }
    }
}
