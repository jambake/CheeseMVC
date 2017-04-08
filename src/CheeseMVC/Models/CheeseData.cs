using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> Cheeses = new List<Cheese>();

        public static void Add(Cheese newCheese)
        {
            Cheeses.Add(newCheese);
        }

        public static List<Cheese> GetAll()
        {
            return Cheeses;
        }

        public static bool Remove(int id)
        {
            return Cheeses.Remove(GetById(id));
        }

        public static Cheese GetById(int id)
        {
            return Cheeses.Single(x => x.ID == id);
        }

        public static IList<Cheese> GetSortByRating()
        {
            Cheeses.Sort(new CheeseComparer());
            return Cheeses;
        }
    }
}
