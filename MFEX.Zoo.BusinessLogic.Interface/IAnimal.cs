using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic.Interface
{
    public interface IAnimal
    {
        string Category { get; set; }
        string Name { get; set; }
        double Weight { get; set; }
        double Rate { get; set; }
        double meatPercentageRate { get; set; }
        double Feed(IList<IFood> food);
    }
}
