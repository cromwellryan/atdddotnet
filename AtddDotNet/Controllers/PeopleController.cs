using System.Collections.Generic;
using System.Web.Mvc;

namespace AtddDotNet.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IList<string> people = new List<string>();

        [HttpPost]
        public ActionResult Index(string name)
        {
            people.Add(name);

            return Json(new
            {
                Message = name ?? "" + " added",
                Name = name
            });
        }
    }
}