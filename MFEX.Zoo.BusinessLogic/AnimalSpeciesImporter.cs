using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEX.Zoo.BusinessLogic.Interface;

namespace MFEX.Zoo.BusinessLogic
{
    public class AnimalSpeciesImporter : IAnimalSpeciesImporter
    {
        private IAnimal animal;
        private List<IAnimal> animals;
        CultureInfo culture = new CultureInfo("en-US");

        public IList<IAnimal> ImportAnimals(string path)
        {
            // read animals from csv file
            try
            {
                animals = new List<IAnimal>();
                using (var fs = File.OpenRead(path))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        var animalSpecie = values.Length > 0 ? values[0] : "";
                        var rate = values.Length > 0 ? values[1] : "";
                        var foodType = values.Length > 0 ? values[2] : "";
                        var ratepercentage = values.Length > 3 ? values[3] : "";

                        animal = new Animal();

                        if (foodType.ToUpper() == "MEAT")
                        {
                            animal.Category = animalSpecie;
                            animal.Rate = Convert.ToDouble(rate, culture);
                            animals.Add(animal);
                        }
                        else if (foodType.ToUpper() == "FRUIT")
                        {
                            animal.Category = animalSpecie;
                            animal.Rate = Convert.ToDouble(rate, culture);
                            animals.Add(animal);
                        }
                        else if (foodType.ToUpper() == "BOTH")
                        {
                            animal.Category = animalSpecie;
                            animal.Rate = Convert.ToDouble(rate, culture);
                            animal.meatPercentageRate = Convert.ToDouble(ratepercentage.Replace("%",""),culture);
                            animals.Add(animal);
                        }

                    }
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
