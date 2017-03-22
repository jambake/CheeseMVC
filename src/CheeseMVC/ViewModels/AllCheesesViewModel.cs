using System.Collections.Generic;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class AllCheesesViewModel
    {
        public List<Cheese> Cheeses { get; set; }

        public AllCheesesViewModel()
        {
            Cheeses = CheeseData.GetAll();
        }
    }
}
