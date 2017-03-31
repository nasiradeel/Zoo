using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEX.Zoo.BusinessLogic.Interface
{
    public interface IFood
    {
        FoodType FoodType { get; set; }
        //string FoodType { get; set; }
        double Price { get; set; }
    }
}
