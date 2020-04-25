using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string, string> Dishes = new Dictionary<string, string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            /*
            List<string> Dishes = new List<string>();
            dishes.Add("mafe");
            dishes.Add("beignet");
            dishes.Add("moringa tea");
            dishes.Add("doute");
            dishes.Add("cafe Touba");
            dishes.Add("onion sauce");
            */
           
            ViewBag.dishes = Dishes;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewDish(string name, string description="no description")
        {
            // add the new dish to the existing dishes
            Dishes.Add(name, description);

            return Redirect("/Cheese");
        }

        /* 
        example of how you can select a different view (aka layout) than the one corresponding to your action name
        Alternative layout must be in the shared views folder in order to access it 
        
        public IActionResult Index2()
        {
            return View("Error");
        }
        */

        public IActionResult Remove()
        {
            ViewBag.dishes = Dishes;

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveDish(string name)
        {
            // add the new dish to the existing dishes
            Dishes.Remove(name);

            return Redirect("/Cheese");
        }

    }

   
}
