using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FlightReservationSystem.Middlewares
{
    public class PlaceholderMiddleware
    {
        private readonly RequestDelegate _next;

        public PlaceholderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // TODO: Middleware logic here

            await _next(context);
        }
    }
}
