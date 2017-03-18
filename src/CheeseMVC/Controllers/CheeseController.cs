using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // static = available to any code within class, doesn't belong to one instance of the class
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        //public IActionResult NewCheese(string name, string description)
        {
            CheeseData.Add(newCheese);
                /*new Cheese {
                Name = name,
                Description = description
            });*/

            return Redirect("/");
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(int[] cheeseIds)
        {
            foreach (int id in cheeseIds)
            {
                CheeseData.Remove(id);
            }
            return Redirect("/");
        }


        public IActionResult Detail(int id)
        {
            Cheese cheese = CheeseData.GetById(id);
            return View(cheese);
        }
    }
}
