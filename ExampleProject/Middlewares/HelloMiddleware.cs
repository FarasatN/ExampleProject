namespace ExampleProject.Middlewares
{
	public class HelloMiddleware
	{
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Custom operations
            Console.WriteLine("Salam Aleykum ");
            await _next.Invoke(httpContext);
			Console.WriteLine("Aleykum salam");

		}
	}
}
