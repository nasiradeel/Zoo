using MFEX.Zoo.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic
{
    public class PriceImporter : IPriceImporter
    {
        private IFood food;
        private List<IFood> foods;
        
        public IList<IFood> ImportPrices(string path)
        {
            // read price text file
            try
            {
                // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = File.ReadAllLines(path);

                foods = new List<IFood>();
                // Read the file contents by using a foreach loop.
                foreach (string line in lines)
                {
                    string[] foodItem = line.Split('=');
                    if (foodItem.Length > 0)
                    {
                        food = new Food();
                        if (foodItem[0].ToUpper() == "MEAT")
                            food.FoodType = FoodType.Meat;
                        else if (foodItem[0].ToUpper() == "FRUIT")
                        {
                            food.FoodType = FoodType.Fruit;
                        }
                        else
                            food.FoodType = FoodType.Both;
                    }

                    if (foodItem.Length > 1)
                        food.Price = Convert.ToDouble(foodItem[1]);

                    foods.Add(food);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return foods;
        }
    }
}
