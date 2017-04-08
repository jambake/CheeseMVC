using System;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; } // Can also be named 'CheeseID' for entity framework to recognize as a 'Primary Key'
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Rating must be between 1 and 5.");
                }

                rating = value;
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.ID == (obj as Cheese).ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
