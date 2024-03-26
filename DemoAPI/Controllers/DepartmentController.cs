using DemoAPI.Models.Data;
using DemoAPI.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public DepartmentController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartment()
        {
            var department = await _context.Departments.ToListAsync();
            return Ok(department);
        }

        [HttpGet("/api/department-by-id/{departmentId}")]
        public async Task<ActionResult> GetDepartmentById(int departmentId)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment([FromBody] DepartmentRequest request)
        {

            try
            {

                var createDate = DateTime.Now;
                var department = new Department()
                {
                    DepartmentNameKh = request.DepartmentNameKh,
                    DepartmentNameEn = request.DepartmentNameEn,
                    IsActive = request.IsActive,
                    CreateBy = request.CreateBy,
                    CreateDate = createDate,
                    LastUpdateBy = request.CreateBy,
                    lastUpdateDate = createDate,

                };
                await _context.Departments.AddAsync(department);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    status = "Succeed",
                    message = "Your transaction is completed !"
                });

            }
            catch (Exception)
            {

                return Ok(new
                {
                    status = "Error",
                    message = "Something when wrong !"
                });

            }

        }


        [HttpPost("/api/Department-Edit")]
        public async Task<ActionResult> EditDepartment([FromBody] DepartmentRequest request)
        {
            try
            {
                var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == request.DepartmentId);
                if (department == null)
                {
                    return NotFound(new
                    {
                        status = "Error",
                        message = "Department not found!"
                    });
                }
                department.DepartmentNameKh = request.DepartmentNameKh;
                department.DepartmentNameEn = request.DepartmentNameEn;
                department.IsActive = request.IsActive;
                department.LastUpdateBy = request.CreateBy;
                department.lastUpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    status = "Succeed",
                    message = "Your transaction is completed !"
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    status = "Error",
                    message = "Something went wrong!"
                });
            }
        }

        [HttpPost("/api/Department-Delete")]
        public async Task<ActionResult> DeleteDepartment([FromBody] DepartmentRequest request)
        {
            try
            {
                var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == request.DepartmentId);
                if (department == null)
                {
                    return NotFound(new
                    {
                        status = "Error",
                        message = "Department not found!"
                    });
                }

                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    status = "Succeed",
                    message = "Your transaction is completed !"
                });
            }
            catch (Exception)
            {
                return Ok(new
                {
                    status = "Error",
                    message = "Something went wrong!"
                });
            }
        }


    }
}
