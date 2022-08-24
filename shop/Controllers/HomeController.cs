﻿using Microsoft.AspNetCore.Mvc;
using shop.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shop.Models.DataAccess;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbfinalContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, dbfinalContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbfinalContext = _context.Products.Include(p => p.Brand);
            return View(await dbfinalContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        } public IActionResult Signup()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}