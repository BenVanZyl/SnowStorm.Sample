using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnowStorm.QueryExecutors;

namespace SnowStormSample.Web.Services.Api
{
    public class BaseApiController : Controller
    {
        public BaseApiController(IQueryExecutor  executor, IMediator mediator)
        {
            Executor=executor;
            Mediator = mediator;
        }

        public IQueryExecutor Executor { get; set; } 
        public IMediator Mediator { get; set; }

    }
}
