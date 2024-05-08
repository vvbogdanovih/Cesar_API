using BLL.DTO;
using DLL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
        [Authorize]
        [HttpGet("GetGPURoutes")]
        public async Task<ActionResult<List<GPURouteDTO>>> GetGPURoutes()
        {
            // Retrieve the list of routes from the database
            var routes = await _context.Routes.Where(r => !string.IsNullOrEmpty(r.GPU)).Select(route => new GPURouteDTO(route.Adres, route.GPU)).ToListAsync();

            // Return the list of routes as an Ok response
            return Ok(routes);
        }
        [Authorize]
        [HttpGet("GetCPURoutes")]
        public async Task<ActionResult<List<GPURouteDTO>>> GetCPURoutes()
        {
            // Retrieve the list of routes from the database
            var routes = await _context.Routes.Where(r => !string.IsNullOrEmpty(r.CPU)).Select(route => new CPURouteDTO(route.Adres, route.CPU)).ToListAsync();

            // Return the list of routes as an Ok response
            return Ok(routes);
        }
        [Authorize]
        [HttpGet("GetAllRoutes")]
        public async Task<ActionResult> GetAllRoutes()
        {
            // Retrieve the list of routes from the database
            var routes = await _context.Routes.ToListAsync();
            
            // Return the list of routes as an Ok response
            return Ok(routes);
        }

        [Authorize]
        [HttpPost("EditRoutes")]
        public async Task<ActionResult> EditRoutes([FromBody] IdRouteDTO r)
        {
            DLL.Data.Entities.Route entity = _context.Routes.Find(r.Id);
            if (entity != null)
            {
                // Змініть значення поля, яке потрібно редагувати
                entity.Adres = r.Adres;
                entity.GPU = r.GPU;
                entity.CPU = r.CPU;

                // Збережіть зміни
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Об'єкт з Id {r.Id} не знайдено.");
            }
            
        }

        [Authorize]
        [HttpPost("AddRoutes")]
        public async Task<ActionResult> AddRoutes([FromBody] RouteDTO route)
        {
            DLL.Data.Entities.Route newRoute = new DLL.Data.Entities.Route
            {
                Id = Guid.NewGuid(), 
                Adres = route.Adres,
                GPU = route.GPU,
                CPU = route.CPU
            };
            
            _context.Routes.Add(newRoute);

            
            _context.SaveChanges();
            
            return Ok();
        }
        [Authorize]
        [HttpPost("DeleteRoutes")]
        public async Task<ActionResult> DeleteRoutes([FromBody] IdRouteDTO r)
        {
            try
            {
                Console.WriteLine(_context.Routes.Find(r.Id).Adres);
                _context.Routes.Remove(_context.Routes.Find(r.Id));
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
