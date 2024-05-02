using BLL.DTO;
using DLL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cesar_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RouteController(ApplicationDbContext context) { 
            _context = context;
        }
        //[Authorize]
        [HttpGet("GetGPURoutes")]
        public async Task<ActionResult<List<GPURouteDTO>>> GetGPURoutes()
        {
            // Retrieve the list of routes from the database
            var routes = await _context.Routes.Where(r => !string.IsNullOrEmpty(r.GPU)).Select(route => new GPURouteDTO(route.Adres, route.GPU)).ToListAsync();

            // Return the list of routes as an Ok response
            return Ok(routes);
        }
        //[Authorize]
        [HttpGet("GetCPURoutes")]
        public async Task<ActionResult<List<GPURouteDTO>>> GetCPURoutes()
        {
            // Retrieve the list of routes from the database
            var routes = await _context.Routes.Where(r => !string.IsNullOrEmpty(r.CPU)).Select(route => new CPURouteDTO(route.Adres, route.CPU)).ToListAsync();

            // Return the list of routes as an Ok response
            return Ok(routes);
        }
    }
}
