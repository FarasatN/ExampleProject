using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Models.ModelMetadataTypes
{
	public class ProductMetadata
	{
		[Required(ErrorMessage = "Please, fill in the gap!")]
		[StringLength(100, ErrorMessage = "Please,enter less than 100 characters!")]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "Please, fill in the gap!")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Please, fill in the gap!")]
		[EmailAddress(ErrorMessage = "Please, enter a correct email address!")]
		public string Email { get; set; }
	}
}
