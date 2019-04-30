using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMicroservice
{
    public class Cheese
    {
        public int AmountOfHoles { get; set; }
        public string Name { get; set; }
        public CheeseType CheeseType { get; set; }

        public static Cheese CreateGoatCheese(int amountOfHoles, string name)
        {
            return new Cheese(amountOfHoles,name,CheeseType.Goat);
        }
        public static Cheese CreateCowCheese(int amountOfHoles, string name)
        {
            return new Cheese(amountOfHoles, name, CheeseType.Cow);
        }
        private Cheese(int amountOfHoles, string name, CheeseType type)
        {
            AmountOfHoles = amountOfHoles;
            Name = name;
            CheeseType = type;
        }
    }
}
