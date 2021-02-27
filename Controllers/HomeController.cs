using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {

            ViewBag.Womans = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
            ViewBag.Hockey = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootball = _context.Leagues
                .Where(l => ! l.Sport.Contains("Football"))
                .ToList();
            ViewBag.Conference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.Atlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.Dallas = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();
            ViewBag.Raptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.City = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();
            ViewBag.FirstLetterT = _context.Teams
                .Where(l => l.TeamName.Contains("T"))
                .ToList();
            ViewBag.AlphOrder = _context.Teams
                .OrderBy(t => t.TeamName)
                .ToList();
            ViewBag.AlphOrderRev = _context.Teams
                .OrderByDescending(t => t.TeamName)
                .ToList();
            ViewBag.Cooper = _context.Players
                .Where(t => t.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.Joshua = _context.Players
                .Where(t => t.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.NotJoshua = _context.Players
                .Where(t => t.LastName.Contains("Cooper") && t.FirstName != "Joshua")
                .ToList();
            ViewBag.AlexanderWyatt = _context.Players
                .Where(t => t.FirstName.Contains("Alexander") || t.FirstName.Contains("Wyatt"))
                .OrderBy(t => t.FirstName)
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}