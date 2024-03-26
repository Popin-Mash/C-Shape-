using DemoAPI.Models.Data;
using DemoAPI.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly DemoDbContext _context;
        public PositionController(DemoDbContext context)
        {
            _context = context;
        }
        [HttpGet("/api/position-get")]
        public async Task<ActionResult> GetPosition()
        {

            try
            {
                var positionList = await _context.Positions.ToListAsync();
                if (positionList != null)
                {
                    return Ok(new
                    {
                        status = "Succeed",
                        message = "",
                        position = positionList
                    });

                }
                return Ok(new
                {
                    status = "Error",
                    message = "Something is wrong!"
                });

            }
            catch (Exception)
            {
                return Ok(new
                {
                    status = "Error",
                    message = "Something is wrong!"
                });
            }
        }

        [HttpGet("/api/position-by-id/{positionsID}")]
        public async Task<ActionResult> GetPositById(int positionsID)
        {

            try
            {
                var positionList = await _context.Positions.Where(x => x.PositionId == positionsID).ToListAsync();
                if (positionList != null)
                {
                    return Ok(new
                    {
                        status = "Succeed",
                        message = "",
                        position = positionList
                    });

                }
                return Ok(new
                {
                    status = "Error",
                    message = "Something is wrong!"
                });


            }
            catch (Exception)
            {
                return Ok(new
                {
                    status = "Error",
                    message = "Something is wrong!"
                });
            }
        }


        [HttpPost("/api/positon-cud")]
        public async Task<ActionResult> CUDPosition([FromBody] PositionRequest request)
        {
            try
            {
                DateTime traData = DateTime.Now;
                var p = new Position();
                p.PositionNameKh = request.PositionNameKh;
                p.PositionNameEn = request.PositionNameEn;
                p.IsAvtive = request.IsAvtive;
                p.LastUpdateBy = request.CreateBy;
                p.LastUpdateDate = traData;
                if (request.CUD == "C")
                {
                    p.PositionId = 0;
                    p.CreateBy = request.CreateBy;


                    await _context.Positions.AddAsync(p);
                    _context.SaveChanges();
                }
                //else if
                else if (request.CUD == "U")
                {
                    var positioExist = await _context.Positions.Where(x => x.PositionId == request.PositionId).FirstOrDefaultAsync();
                    if (positioExist != null)
                    {
                        _context.ChangeTracker.Clear();
                        p.PositionId = request.PositionId;
                        p.CreateBy = positioExist.CreateBy;
                        p.LastUpdateBy = positioExist.CreateBy;
                        p.LastUpdateDate = traData;

                        _context.Positions.Update(p);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "Error",
                            message = "Data not found"
                        });
                    }
                }
                // content D
                else if (request.CUD == "D")
                {
                    var positioExist = await _context.Positions.Where(x => x.PositionId == request.PositionId).FirstOrDefaultAsync();
                    if (positioExist != null)
                    {
                        _context.ChangeTracker.Clear();
                        _context.Positions.Remove(positioExist);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = "Error",
                            message = "Data not found"
                        });
                    }
                }
                //End Content D
                else
                {
                    return Ok(new
                    {
                        status = "Error",
                        message = "Invalid Event"
                    });
                }

                //end else if

                return Ok(new
                {
                    status = "Succeed",
                    message = "Your Transaction complate"
                });
            }

            catch (Exception)
            {

                return Ok(new
                {
                    status = "Error",
                    message = "Something is wrong"
                });
            }
        }

    }
}
