using AutoMapper;
using ExampleProject.Models;
using ExampleProject.Models.ViewModels;

namespace ExampleProject.AutoMappers
{
	public class PersonelProfil: Profile
	{
        public PersonelProfil()
        {
            CreateMap<Personel, PersonelCreateVM>();    
            CreateMap<PersonelCreateVM,Personel>();
		}
    }
}
