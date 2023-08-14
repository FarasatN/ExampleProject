using System.Collections;
using ExampleProject.Models;
using ExampleProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
	//Controllerin isi sadece gelen sorgulari yonlendirmekdir, is gormemelidir, bunlari servisler falan etmelidir

	//[NonController] - request almayacaq
	//[Route("/[action]")]
	//[Route("/[action]")]
	public class ProductController : Controller
    {
		//Product product = new Product();

		//public ViewResult GetProducts()
		//{
		//    //ViewResult
		//    //ViewResult result = View(); //- bos olanda eyni adda view qaytarir
		//    ViewResult result = View("something");
		//    return result;
		//}

		////PartialViewResult - viewstart.cshtml i nezere almir
		//public PartialViewResult GetProducts()
		//{
		//    PartialViewResult result = PartialView();
		//    return result;
		//}


		//JsonResult - json formatinda qaytarir,api kimi
		//public JsonResult GetProducts()
		//{
		//    JsonResult result = Json(new Product
		//    {
		//        Id = 5,
		//        ProductName = "Book",
		//        Quantity = 1,
		//    });

		//    return Json(result);
		//}

		//Empty Result - bos qaytarir
		//public EmptyResult GetProducts()
		//{
		//    return new EmptyResult();
		//}
		//public void GetProducts()
		//{
		//}

		//ContentResult - text/plain return edir
		//public ContentResult GetProducts()
		//{
		//    ContentResult result = Content("dfgdfgdgdgfdfg");
		//    return result;
		//}

		//ViewComponentResult

		//IActionResult,ActionResult bunlarin base dir

		//-------------------------------------------------
		//NonAction ve NonController
		//[NonAction]// - bu atributla isarelen metodlar request qebul etmirler
		//public void X()
		//{
		//}

		//EGER BUNU IST. EDIRSENSE, BOYUK EHTIMAL YALNIS ARCHITEC. QURMUSAN
		//basqa bir servisde, classda isi yaradib cagirmaq lazimdir

		//NonController ile colden request qebul etmeyin qarsisini alirsan



		//View e Tuple gondermek
		//     public IActionResult GetProducts() {
		//Product product = new Product()
		//{
		//	Id = 1,
		//	ProductName = "A Product",
		//	Quantity = 15,
		//};

		//User user = new User()
		//{
		//	Id = 1,
		//	Name = "Farasat",
		//	LastName = "Novruzov",
		//};

		//         //UserProduct userProduct = new UserProduct()
		//         //{
		//         //    User = user,
		//         //    Product = product
		//         //};

		//         var userProduct = (product, user);

		//         return View(userProduct); 
		//     }       



		//Query string - tehlukesizlik gerektirmeyen datalarin url uzerinde kecirmek
		// /user?name=max

		//query string ile - her cur get, post ve s. ist. edile bilir
		//public IActionResult GetData(string a,string b) 
		//public IActionResult GetData(QueryData data) 
		//public IActionResult GetData(string a,string b)
		//{
		//          //HttpContext.Request.Headers,Body - butun gelen deyerleri goturmek olur
		//          return View();
		//      }

		//Route uzerinden thelukesiz deyer almaq
		// /user/max
		//public IActionResult GetProducts(string id, string a,string b) 
		//{
		//	Console.WriteLine(Request.RouteValues["id"]);

		//	return View();
		//}

		//Header uzerinde deyer almaq(header de ancaq latinca character olmalidir!)
		//[HttpPost]
		//public IActionResult GetProducts()
		//{
		//	var headers = Request.Headers;
		//	return View();
		//}

		//public IActionResult GetProducts(AjaxData data)
		//{
		//	Console.WriteLine(data);
		//	return View();
		//}

		//Validation - girilen deyerin teyin olunan sertlere uygun olub olmamasidir
		//Client Side Validation - ilk olaraq bu cox yuku azaldir serveri cox yormur
		//Server Side Validation - her ehtimal ucun serverde de mutleq validat. olmalidir
		//hacker clienti kecse ve serverde restrict. olmasa, rahat datalari elde edecek
		//cliente guvenmek olmaz - demeli, her ikisi olmalidir

		//[Route("get/{id?}")]
		public IActionResult GetProducts()
		{

			return View();
		}

		[HttpPost]
		public IActionResult GetProducts(Product model)
		{
			Console.WriteLine(model);

			//if (!string.IsNullOrEmpty(model.ProductName) && model.ProductName.Length <= 100 && model.Email.Length<= 8)
			//{
			//}

			//seliqeli kod ucun validationu modele birbasa yamaq olar amma mvc e uygun deyil,viewmodele yazilmalidir
			//cunki, solidir 1.ci srp prinsipi pozulur modelde
			//bunun yerine - MetaDataType ve FluentValidation ist. olunur
			//ModelState - mvc de modelin data annotasiyalarini check edir ve geriye return edir

			//Fluent Validation hazir kitabxanadir
			if(!ModelState.IsValid)
			{
				//Loglama
				//informing cilent
				//ViewBag.ErrorMessage = ModelState.Values.FirstOrDefault(x => x.ValidationState ==
				//Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;


				return View(model);
			}
			//burda da validation olubsa, gerekli isler gorulur




			return View();
		}


	}

	public class AjaxData
	{
		public string a { get; set; }
		public string b { get; set; }

	}
}
