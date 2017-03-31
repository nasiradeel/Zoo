using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEX.Zoo.BusinessLogic.Interface;

namespace MFEX.Zoo.BusinessLogic
{
    public class Animal : IAnimal
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Rate { get; set; }
        public double meatPercentageRate { get; set; }
        public double Feed(IList<IFood> foods)
        {
            double meatPrice = 0;
            double fruitPrice = 0;
            double dailyFeedAmount = 0;
            foreach (var food in foods)
            {
                if (food.FoodType == FoodType.Meat)
                    meatPrice = food.Price;
                else if (food.FoodType == FoodType.Fruit)
                    fruitPrice = food.Price;
            }

            if ((Category == "Lion" || Category == "Tiger")) 
            {
                dailyFeedAmount = Rate * Weight * meatPrice;
            }
            else if ((Category == "Giraffe" || Category == "Zebra"))
            {
                dailyFeedAmount = Rate * Weight * fruitPrice;
            }
            else if ((Category == "Wolf" || Category == "Piranha")) 
            {
                double meatPercentage = meatPercentageRate * 0.01 * Rate;
                double fruitPercentage = (100 - meatPercentageRate) * 0.01 * Rate;
                dailyFeedAmount = (meatPercentage * Weight * meatPrice) + (fruitPercentage * Weight * fruitPrice);
            }

            return dailyFeedAmount;
        }
    }
}
