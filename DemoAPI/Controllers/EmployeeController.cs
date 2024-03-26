using DemoAPI.Models.Data;
using DemoAPI.Models.Request;

using Newtonsoft.Json;
namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        protected readonly DemoDbContext _context;
        public EmployeeController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpPost("/api/add-employee")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeRequest request)
        {

            try
            {


                //add employee

                var empJson = JsonConvert.SerializeObject(request);
                var emplObj = JsonConvert.DeserializeObject<Employee>(empJson);


                // Conteint of  Emloyee Experiencd 
                var empExperRequest = (from exp in request.EmployeeExperienceRequests
                                       select new
                                       {
                                           EmployeeExperiendId = exp.EmployeeExperiendId,
                                           EmployeeId = request.EmployeeId,
                                           Position = exp.Position,
                                           Salary = exp.Salary,
                                           DateJoin = exp.DateJoin,
                                           ResignJo = exp.DateResign



                                       }).ToList();
                //End Content Exp

                var emoExperJson = JsonConvert.SerializeObject(empExperRequest);
                var empExperObj = JsonConvert.DeserializeObject<List<EmployeeExperience>>(emoExperJson);

                //Content Of Edu
                var empEduReuest = (from edu in request.EmployeeEductionRequests
                                    select new
                                    {
                                        EmployeeEducationId = edu.EmployeeEducationId,
                                        EmployeeId = request.EmployeeId,
                                        EducationLevel = edu.EducationLevel,
                                        Majo = edu.Majo,
                                        SchoolName = edu.SchoolName,
                                        YearStart = edu.YearStart,
                                        YearEnd = edu.YearEnd

                                    }).ToList();

                //End Content of Edu

                var emplEduJson = JsonConvert.SerializeObject(empEduReuest);
                var empEudObj = JsonConvert.DeserializeObject<List<EmployeeExperience>>(emplEduJson);



                await _context.Employees.AddAsync(emplObj);
                await _context.SaveChangesAsync();
                //end employe




                return Ok(new
                {
                    status = "Succeed",
                    message = "You transaction is complete",
                    emplObj = emplObj,
                    empEudObj = empEudObj,
                    empExperObj
                });
            }
            catch (Exception)
            {

                return Ok(new
                {
                    status = "Error",
                    message = "Something's wrong!"
                });

            } //catch

        }

    }

    internal class RouteAttribute : Attribute
    {
    }
}
