using ImageMagick;

namespace ExampleProject.Handlers
{
	public class ImageHandler
	{
		public RequestDelegate Handler(string filePath)
		{
			return async c =>
			{
				FileInfo fileInfo = new FileInfo($"{filePath}\\{c.Request.RouteValues["fileName"].ToString()}");
				using MagickImage magick = new MagickImage(fileInfo);
				int width = magick.Width;int height = magick.Height;
				if (!string.IsNullOrEmpty(c.Request.Query["w"]))
				{
					width = int.Parse(c.Request.Query["w"]);
				}
				if (!string.IsNullOrEmpty(c.Request.Query["h"]))
				{
					height = int.Parse(c.Request.Query["h"]);
				}
				magick.Resize(width, height);
				var buffer = magick.ToByteArray();
				c.Response.Clear();
				c.Response.ContentType = string.Concat("image/", fileInfo.Extension.Replace(".", ""));

				await c.Response.Body.WriteAsync(buffer,0,buffer.Length);
				await c.Response.WriteAsync(filePath);
			};
		}
	}
}
