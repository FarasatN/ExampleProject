using ExampleProject.Middlewares;

namespace ExampleProject.Extensions
{
	static public class Extension
	{
		public static  IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<HelloMiddleware>();
		}
	}
}
