using MFEX.Zoo.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MFEX.Zoo.BusinessLogic
{
    public class ZooAnimalsImporter : IZooAnimalsImporter
    {
        private List<IAnimal> animals;
        CultureInfo culture = new CultureInfo("en-US");

        public IEnumerable<IAnimal> ImportZooAnimals(string path)
        {
            // read animals from csv file
            try
            {
                animals = new List<IAnimal>();
                var xDoc = XDocument.Load(path);
                //Get the names of all nodes
                var allNodeNames = xDoc.Descendants().Select(o => o.Name.LocalName).ToList();
                foreach (var item in allNodeNames)
                {
                    var animal = xDoc.Descendants(item).Select(o => new Animal
                    {
                        Name = o.Attribute("name")?.Value,
                        Weight = Convert.ToDouble(o.Attribute("kg")?.Value, culture),
                        Category = item
                    }).ToList();
                    if (animal.Any(o => !string.IsNullOrEmpty(o.Name)))
                        animals.AddRange(animal);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return animals;
        }
    }
}
