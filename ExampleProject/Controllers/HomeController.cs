using System.Text.Json;
using ExampleProject.Models;
using ExampleProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ExampleProject.Controllers
{
	//[Route("home/index")]
    public class HomeController : Controller
    {
		IWebHostEnvironment _environment;
		IConfiguration _configuration;

        //readonly ILog _log;
        //public HomeController(ILog log)
        //      {
        //	_log = log;
        //}

        //readonly IConfiguration _configuration;
        //      public HomeController(IConfiguration configuration)
        //      {
        //          _configuration = configuration;
        //      }

		MailInfo _mailInfo;
        public HomeController(IOptions<MailInfo>  mailInfo, IWebHostEnvironment environment,IConfiguration configuration)
        {
			_mailInfo = mailInfo.Value;
			_environment = environment;
			_configuration = configuration;
        }

		public IActionResult Privacy()
		{
			//var v1 = _configuration["AllowedHosts"];
			//var v2 = _configuration["Person:Name"];
			//var v3 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
			//var v4 = _configuration["Person"];
			//var v5 = _configuration.GetSection("Person");
			//var v6 = _configuration.GetSection("Person:Surname");

			//var v7 = _configuration.GetSection("Person").Get(typeof(Person));

			//string host = _configuration["MailInfo:Host"];
			//string port = _configuration["MailInfo:Port"];

			//var mailInfo = _configuration.GetSection("MailInfo").Get(typeof(MailInfo));

			//_environment.IsDevelopment();
			//_environment.IsEnvironment("Development");

			//ilk once konf.i env icinde axtaracaq, tapmasa secret, o da yoxdursa appsettingse baxacaq
			//ardicilliq bu qaydada gedecek
			//envdeki deyerler memoryde saxlanir ve productionda faylda gorunmur, ozun ayrica vermelisen

			var a = _configuration["a"];

			if(_environment.IsDevelopment())
			{
				ViewBag.Env = "Development";
			}else if(_environment.IsStaging())
			{
				ViewBag.Env = "Staging";
			}
			else if (_environment.IsProduction())
			{
				ViewBag.Env = "Production";
			}

			return View();
		}


        public IActionResult Index([FromServices] ILog log)
        {
			//Data Passing methods
			//var products = new List<Product>
			//		 {
			//			 new Product { ProductName="A",Quantity = 1},
			//			 new Product { ProductName="B",Quantity = 1},
			//			 new Product { ProductName="C",Quantity = 1},
			//			 new Product { ProductName="D",Quantity = 1},
			//			 new Product { ProductName="E",Quantity = 1},
			//		 };


			//model based
			//return View(products);

			//ViewBag - dynamic bir deyiskenle edir bunu
			//ViewBag.products = products;

			//ViewData - boxing ederek gonderir
			//ViewData["products"] = products;

			//TempData - cookie ist. edir, bezen bir actiondan digerine yonlendirmek gerekecek ve bunu gondermeyin yegane yolu tempdata ile olur
			//TempData["products"] = JsonSerializer.Serialize(products);//complex datani serialize etmek lazimdir
			////return View();
			//return RedirectToAction("Index2","Home");

			//ConsoleLog log = new ConsoleLog();
			//TextLog log2 = new TextLog();
			//log.Log();
			//log2.Log();

			//_log.Log();
			log.Log();

			//return new EmptyResult();
			return View();
		}

		//public IActionResult Index2()
		//{
		//	var tempData = JsonSerializer.Deserialize<List<Product>>(TempData["products"].ToString());
		//	return View(tempData);
		//}

		
	}
}
