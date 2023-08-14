using System.ComponentModel.DataAnnotations;
using ExampleProject.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Models
{
	[ModelMetadataType(typeof(ProductMetadata))]
    public class Product
    {

		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public string Email { get; set; }
    }
}
