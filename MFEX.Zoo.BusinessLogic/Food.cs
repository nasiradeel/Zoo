using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEX.Zoo.BusinessLogic.Interface;

namespace MFEX.Zoo.BusinessLogic
{
    public class Food : IFood
    {
        public FoodType FoodType { get; set; }
        public double Price { get; set; }
    }
}
