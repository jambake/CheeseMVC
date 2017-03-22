using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // static = available to any code within class, doesn't belong to one instance of the class
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.cheeses = CheeseData.GetAll();
            // ViewBag is basically a Dictionary
            AllCheesesViewModel allCheeseViewModel = new AllCheesesViewModel();

            return View(allCheeseViewModel);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Models.Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                CheeseData.Add(newCheese);

                return Redirect("/");
            }

            return View(addCheeseViewModel);

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
