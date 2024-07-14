namespace Technology.Middleware
{
    public class RequestLimit
    {
        private static SemaphoreSlim semaphore;
        private readonly RequestDelegate next;
        private readonly HashSet<string> users = new();
        public static int MaxCount { get; set; }
        public RequestLimit(RequestDelegate next)
        {
            semaphore = new SemaphoreSlim(MaxCount);
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var ip = context.Connection.RemoteIpAddress!.ToString();

            if (!semaphore.Wait(0))
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Too many requests");
                return;
            }

            try
            {
                lock (users) users.Add(ip);
                await next(context);
            }
            finally
            {
                semaphore.Release();
                lock (users) users.Remove(ip);
            }
        }
    }
}
