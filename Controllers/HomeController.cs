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
    /// <summary>
    /// Home Controller class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Home controller constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns>View</returns>
       public IActionResult Index()
       {
            return View();
       }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View - Index or Error</returns>
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
                catch (Exception ex)
                {
                    _logger.LogError("There has been an error " + ex);
                    return View("Error");
                }
            }

            return View("Index", model);
        }

        /// <summary>
        /// Location
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View - Location</returns>
        public IActionResult Location(Models.RobotWars model)
        {
          return View("Location", model);
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Privacy()
        {
            //TODO Requires completion

            return View();
        }
    }
}
