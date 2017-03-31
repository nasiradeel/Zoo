using MFEX.Zoo.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic
{
    public class ZooManager : IZooManager
    {
        private readonly IAnimalSpeciesImporter animalSpecies;
        private readonly IZooAnimalsImporter zooAnimals;
        private readonly IPriceImporter price;
        private IDailyFeed dailyFeed;
        private IList<IFood> foods;
        private IList<IAnimal> animals;

        public ZooManager(IPriceImporter price, 
                          IList<IFood> foods,
                          IList<IAnimal> animals, 
                          IAnimalSpeciesImporter animalSpecies,
                          IZooAnimalsImporter zooAnimals,
                          IDailyFeed dailyFeed
                          ) 
        {
            this.price = price;
            this.animalSpecies = animalSpecies;
            this.zooAnimals = zooAnimals;
            this.foods = foods;
            this.animals = animals;
            this.dailyFeed = dailyFeed;
        }

        public double CalculateDailyFeed(IList<IFood> foods, IList<IAnimal> species, IEnumerable<IAnimal> zoo)
        {
            double sum = 0;
            foreach (var animal in zoo)
            {
                var specy = species.FirstOrDefault(s => s.Category == animal.Category);
                animal.Rate = specy.Rate;
                sum += animal.Feed(foods);
            }

            return sum;
        }

        public IList<IFood> ImportPrices(string filePath)
        {
            return price.ImportPrices(filePath);
        }

        public IList<IAnimal> ImportAnimals(string filePath)
        {
            return animalSpecies.ImportAnimals(filePath);
        }

        public IEnumerable<IAnimal> ImportZoo(string filePath)
        {
            return zooAnimals.ImportZooAnimals(filePath);
        }
    }
}
