using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MFEX.Zoo.BusinessLogic.Interface;
using System.Collections;

namespace MFEX.Zoo.BusinessLogic.Configuration
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Animal>().As<IAnimal>();
            builder.RegisterType<Food>().As<IFood>();
            builder.RegisterType<PriceImporter>().As<IPriceImporter>();
            builder.RegisterType<AnimalSpeciesImporter>().As<IAnimalSpeciesImporter>();
            builder.RegisterType<ZooAnimalsImporter>().As<IZooAnimalsImporter>();
            builder.RegisterType<List<IAnimal>>().As<IList<IAnimal>>();
            builder.RegisterType<DailyFeed>().As<IDailyFeed>();
            builder.RegisterType<ZooManager>().As<IZooManager>();

        }
    }
}
