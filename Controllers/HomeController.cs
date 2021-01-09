using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RobotWars.Position;
using System.Text.RegularExpressions;

namespace RobotWars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       public IActionResult Index()
       {
            return View();
       }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.RobotWars model)
        {
            if (ModelState.IsValid)
            {
                Position.Position position = new Position.Position();
                model.PenaltyCount = 0;

                try
                {
                    //set initial position
                    position.X = (int)Char.GetNumericValue(model.InitialPosition[0]);
                    position.Y = (int)Char.GetNumericValue(model.InitialPosition[2]);
                    position.Direction = (Directions)Enum.Parse(typeof(Directions), model.InitialPosition[4].ToString().ToUpper());

                    //set variables for the max x and y values for processing the change of location
                    List<int> maxXYPoints = new List<int>() {4, 4};
              
                    //process the new position
                    position.StartMoving(maxXYPoints, model.MovementInstructions.ToUpper());
                    model.FinalPosition = position.X + ", " + position.Y + ", " + position.Direction.ToString();
                    model.PenaltyCount = position.penalty;

                    return Location(model);
                }
                catch
                {
                    return View("Error");
                }
            }

            return View("Index", model);
        }

        
        public IActionResult Location(Models.RobotWars model)
        {
          return View("Location", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
