using AutoMapper;
using ExampleProject.Models;
using ExampleProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
	public class PersonelController : Controller
	{
		private readonly IMapper mapper;

		public PersonelController(IMapper mapper)
        {
			this.mapper = mapper;
		}
        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(PersonelCreateVM personelCreateVM)
		{

			Personel personel = mapper.Map<Personel>(personelCreateVM);
			PersonelCreateVM personel2 = mapper.Map<PersonelCreateVM>(personel);

			//Personel p = new Personel()
			//{
			//	Adi = personelCreateVM.Adi,
			//	Soyadi = personelCreateVM.Soyadi,
			//};

			return View();
		}

		public IActionResult Listele()
		{
			List<PersonelListeVM> personeller = new List<Personel>
			{
				new Personel{Adi="A",Soyadi="B"},
				new Personel{Adi="A2",Soyadi="B2"},
				new Personel{Adi="A3",Soyadi="B3"},
				new Personel{Adi="A4",Soyadi="B4"},
				new Personel{Adi="A5",Soyadi="B5"},
			}.Select(p=>new PersonelListeVM
			{
				Adi = p.Adi,
				Soyadi = p.Soyadi,
				Pozisyon = p.Pozisyon,
			}).ToList();

			return View(personeller);
		}
	}
}
