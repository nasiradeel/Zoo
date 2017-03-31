using MFEX.Zoo.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.Web.Http.Description;
using MFEX.Zoo.BusinessLogic;

namespace MFEX.Zoo.WebClient.Controllers
{
    public class ZooController : ApiController
    {
        private string rootPath = HostingEnvironment.MapPath("~/Files");  
        private readonly IZooManager zooManager;
        /// <summary>
        /// Zoo Controller
        /// <param name="ZooManager">Zoo manager for calculating the daily feed amount.</param>
        /// </summary>
        public ZooController(
            IZooManager zooManager
        )
        {
            this.zooManager = zooManager;
        }
        // GET: api/Zoo/CalculateDailyFeedAmount
        /// <summary>
        /// Calculate the money neded to spend feeding the animals in a day.
        /// </summary>
        [HttpGet]
        [HttpOptions]
        [ResponseType(typeof(IDailyFeed))]
        public IHttpActionResult CalculateDailyFeedAmount()
        {
            var foods = zooManager.ImportPrices($@"{rootPath}\prices.txt");
            var animals = zooManager.ImportAnimals($@"{rootPath}\animals.csv");
            var zoo = zooManager.ImportZoo($@"{rootPath}\zoo.xml");

            var dailyFeed = zooManager.CalculateDailyFeed(foods, animals, zoo);

            return this.Ok(new DailyFeed { Sum = dailyFeed});

        }

        
    }
}
