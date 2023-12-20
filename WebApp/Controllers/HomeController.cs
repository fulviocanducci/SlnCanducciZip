using Canducci.ZipCode;
using Canducci.ZipCode.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
namespace WebApp.Controllers;
public class HomeController : Controller
{
   private readonly ILogger<HomeController> _logger;
   private readonly IRequestZipCode _requestZipCode;

   public HomeController(ILogger<HomeController> logger, IRequestZipCode requestZipCode)
   {
      _logger = logger;
      _requestZipCode = requestZipCode;
   }

   public IActionResult Index()
   {
      return View();
   }

   public IActionResult Privacy()
   {
      return View();
   }

   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   public IActionResult Error()
   {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
   }

   public IActionResult ZipCode()
   {
      ViewBag.ZipValue = string.Empty;
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> ZipCode(string value)
   {
      ZipResult? result = null;
      ViewBag.Message = "";
      if (ZipCodeValue.TryParse(value, out ZipCodeValue zipCodeValue))
      {
         result = await _requestZipCode.FindAsync(zipCodeValue);         
      }
      else
      {
         ViewBag.Message = "Valor inválido";
      }
      ViewBag.ZipValue = value;
      return View(result);
   }
}