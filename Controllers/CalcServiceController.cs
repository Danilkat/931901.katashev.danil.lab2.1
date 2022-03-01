using System;
using Web2._1.Models;
using Microsoft.AspNetCore.Mvc;
namespace Web2._1.Controllers
{
    public class CalcServiceController : Controller
    {
        private readonly Random _random = new Random();
        private readonly int x;
        private readonly int y;
        private readonly string sum;
        private readonly string dif;
        private readonly string mult;
        private readonly string div;

        public CalcServiceController()
        {
            x = _random.Next() % 11;
            y = _random.Next() % 11;
            sum = $"{x} + {y} = {x + y}";
            dif = $"{x} - {y} = {x - y}";
            mult = $"{x} * {y} = {x * y}";
            if (y == 0) div = "Error with zero division.";
            else div = $"{x} /  {y} = {x / y}";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelCalc()
        {
            var model = new CalcModel(x, y, sum, dif, mult, div);
            return View(model);
        }

        public IActionResult ViewDataCalc()
        {
            ViewData["X"] = x;
            ViewData["Y"] = y;
            ViewData["Sum"] = sum;
            ViewData["Dif"] = dif;
            ViewData["Mult"] = mult;
            ViewData["Div"] = div;
            return View();
        }

        public IActionResult ViewBagCalc()
        {
            ViewBag.X = x;
            ViewBag.Y = y;
            ViewBag.Sum = sum;
            ViewBag.Dif = dif;
            ViewBag.Mult = mult;
            ViewBag.Div = div;
            return View();
        }

        public IActionResult ServiceInjectionCalc()
        {
            var model = new CalcModel(x, y, sum, dif, mult, div);
            return View(model);
        }
    }
}