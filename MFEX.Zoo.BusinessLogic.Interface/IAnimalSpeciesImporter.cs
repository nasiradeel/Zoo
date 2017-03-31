using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic.Interface
{
    public interface IAnimalSpeciesImporter
    {
        IList<IAnimal> ImportAnimals(string path);
    }
}
