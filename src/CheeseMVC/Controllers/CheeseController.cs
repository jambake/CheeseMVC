using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private readonly CheeseDBContext context;

        public CheeseController(CheeseDBContext dbContext)
        {
            context = dbContext;
        }

        // static = available to any code within class, doesn't belong to one instance of the class
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.cheeses = CheeseData.GetAll();
            // ViewBag is basically a Dictionary
            //AllCheesesViewModel allCheeseViewModel = new AllCheesesViewModel();
            List<Cheese> cheeses = context.Cheeses.ToList();

            return View(cheeses);
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

                //CheeseData.Add(newCheese);
                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/");
            }

            return View(addCheeseViewModel);

        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = context.Cheeses.ToList();

            return View();
        }
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult RemoveCheese(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                //CheeseData.Remove(id);
                Cheese theCheese = context.Cheeses
                    .Single(c => c.ID == cheeseId);

                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }


        public IActionResult Detail(int id)
        {
            Cheese cheese = CheeseData.GetById(id);
            return View(cheese);
        }
    }
}
