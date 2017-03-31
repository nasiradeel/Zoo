using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MFEX.Zoo.BusinessLogic;
using MFEX.Zoo.BusinessLogic.Interface;
using FluentAssertions;
using Moq;
using Xunit;
using System.Collections.Generic;


namespace MFEX.Zoo.BusinessLogic.Test
{
    [TestClass]
    public class ZooManagerTest
    {
        [Fact]
        [TestMethod]
        public void CalculateDailyFeedAmountTest()
        {
            // Arrange
            var priceImporter = new Mock<IPriceImporter>();
            var foods = new Mock<IList<IFood>>();
            var animals = new Mock<IList<IAnimal>>();
            var zoo = new Mock<IEnumerable<IAnimal>>();
            var animalspeciesImporter = new Mock<IAnimalSpeciesImporter>();
            var zooAnimalImporter = new Mock<ZooAnimalsImporter>();
            var dailyFeed = new Mock<DailyFeed>();

            IZooManager zooManager = new ZooManager(priceImporter.Object, foods.Object,
                animals.Object, animalspeciesImporter.Object, zooAnimalImporter.Object, dailyFeed.Object);

            var lstFood = new List<IFood>
            {
                new Food { FoodType = FoodType.Meat, Price = 12.56 },
                new Food { FoodType = FoodType.Fruit, Price = 5.60 },
            };

            var lstAnimals = new List<IAnimal>
            {
                new Animal { Category = "Lion", Rate = 0.01 },
                new Animal { Category = "Tiger", Rate = 0.09 },
            };

            var lstZoo = new List<IAnimal>
            {
                new Animal { Category = "Lion", Name= "Simba" , Weight = 160 },
                new Animal { Category = "Tiger", Name = "Dante" , Weight = 150 },
            };


            // Act
            double sum = zooManager.CalculateDailyFeed(lstFood, lstAnimals, lstZoo);

            // Assert
            Xunit.Assert.Equal(sum, 189.656);

        }
    }
}
