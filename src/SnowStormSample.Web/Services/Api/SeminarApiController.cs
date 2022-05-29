using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnowStorm.QueryExecutors;
using SnowStormSample.Web.Services.Queries.Seminars;

namespace SnowStormSample.Web.Services.Api
{
    //[Authorize]  // uncomment to apply required authorisation for all endpoints in this class (controller)
    [RequireHttps]
    public class SeminarApiController : BaseApiController
    {
        public SeminarApiController(IQueryExecutor executor, IMediator mediator) : base(executor, mediator)
        {
        }

        [HttpGet]
        [Route("api/seminars")]
        public async Task<IActionResult> GetSeminars()
        {
            try
            {
                var results = await Executor.Get(new GetSeminarsQuery());

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/seminars/{id}")]
        public async Task<IActionResult> GetSeminar(long id)
        {
            try
            {
                var results = await Executor.Get(new GetSeminarQuery(id));

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/seminars/{id}/Atendees")]
        public async Task<IActionResult> GetSeminarAtendees(long id)
        {
            try
            {
                var results = await Executor.Get(new GetAtendeesQuery(id));

                return Ok(results);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
