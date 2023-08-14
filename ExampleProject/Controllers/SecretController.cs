using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SecretController : ControllerBase
	{
		readonly IConfiguration configuration;
        public SecretController(IConfiguration configuration)
        {
			this.configuration = configuration;
        }

		public void Index()
		{
			var email = configuration["MailInfo:EmailInfo:Email"];
			var password = configuration["MailInfo:EmailInfo:Password"];
			var connection = configuration.GetConnectionString("SQL");
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
			builder.UserID = configuration["SQL:UserName"];
			builder.Password = configuration["SQL:Password"];
			var x = builder.ConnectionString.ToString();
		}
    }
}
