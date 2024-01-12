namespace WikY.Middlewares
{
	public class Redirect404Middleware
	{
		private readonly RequestDelegate _next;
		private ILogger<Redirect404Middleware> _logger;
		public Redirect404Middleware(RequestDelegate next) {  _next = next; }
		public async Task InvokeAsync(HttpContext context, ILogger<Redirect404Middleware> logger)
		{
			_logger = logger;

			await _next(context);

			if (context.Response.StatusCode == 404)

				//context.Response.Redirect("/Home/NotFoundCustom?urlRequest=" +
				//	context.Request.Host.Value + context.Request.Path, false);

				//context.Response.Redirect("./myError404.html", false);

				_logger.LogCritical(context.Request.Host.Value + context.Request.Path);

				context.Response.Redirect("/Error/Index", false);
		}
	}
}
