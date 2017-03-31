using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic.Interface
{
    public interface IZooManager
    {
        IList<IFood> ImportPrices(string filePath);
        IList<IAnimal> ImportAnimals(string filePath);
        IEnumerable<IAnimal> ImportZoo(string filePath);
        double CalculateDailyFeed(IList<IFood> foods, IList<IAnimal> species, IEnumerable<IAnimal> zoo);
    }
}
