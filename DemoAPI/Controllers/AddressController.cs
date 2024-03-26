using DemoAPI.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public AddressController(DemoDbContext context)
        {
            _context = context;
        }
        [HttpPost("/api/get-address")]
        public async Task<ActionResult> GetAddress([FromBody] AddressRequest request)
        {
            try
            {
                var address = await _context.Addresses.Where(x => x.ParentId == request.ParentId).ToListAsync();
                return Ok(new
                {
                    status = "Succedd",
                    message = "",
                    address = address
                });
            }
            catch (Exception)
            {

                return Ok(new
                {
                    status = "Error",
                    message = "Something wrong",
                });
            }
        }

    }
}
