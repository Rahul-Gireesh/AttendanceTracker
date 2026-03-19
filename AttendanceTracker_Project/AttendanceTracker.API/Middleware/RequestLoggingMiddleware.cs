using log4net;

namespace AttendanceTracker.API.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private static readonly ILog _log = LogManager.GetLogger(typeof(RequestLoggingMiddleware));

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				// 🔹 Request log
				_log.Info($"Request: {context.Request.Method} {context.Request.Path} | Query: {context.Request.QueryString}");
				// Continue pipeline
				await _next(context);

				// 🔹 Response log
				_log.Info($"Response: {context.Response.StatusCode}");
			}
			catch (Exception ex)
			{
				_log.Error("Unhandled Exception", ex);
				throw;
			}
		}
	}
}
