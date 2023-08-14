namespace ExampleProject.Services
{
	public class ConsoleLog:ILog
	{
        public ConsoleLog(string x)
        {
            
        }
        public void Log()
		{
			Console.WriteLine("console logged..");
		}
	}
}
