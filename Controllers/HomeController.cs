﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.atlanticTeams = _context.Teams
                .Where(t => t.LeagueId == 5)
                .ToList();
            ViewBag.playersBoston = _context.Players
                .Where(p => p.TeamId == 2)
                .ToList();
            ViewBag.playersCollegiate = _context.Teams
                .Where(t => t.LeagueId == 2)
                .SelectMany(p => p.CurrentPlayers)
                .ToList();
            ViewBag.playersLopez = _context.Teams
                .Where(t => t.LeagueId == 7)
                .SelectMany(p => p.CurrentPlayers)
                .Where(currentPlayers => currentPlayers.LastName.Contains("Lopez"))
                .ToList();
            ViewBag.allFootballPlayers = _context.Teams
                .Where(t => t.CurrLeague.Sport.Contains("Football"))
                .SelectMany(p => p.CurrentPlayers)
                .OrderBy(u => u.LastName)
                .ToList();
            ViewBag.sophiaTeams = _context.Teams
                .Include(t => t.CurrentPlayers)
                .Where(t => t.CurrentPlayers.Any(p => p.FirstName.Contains("Sophia")));
            ViewBag.leagueSophia = _context.Leagues
                .Include(l => l.Teams)
                .Where(t => t.Teams.Any(p => p.CurrentPlayers
                .Any(player => player.FirstName.Contains("Sophia"))));
            ViewBag.teamFlores = _context.Players
                .Include(l => l.CurrentTeam)
                .Where(player => player.LastName.Contains("Flores") && player.CurrentTeam.TeamName != "Roughriders");   
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}