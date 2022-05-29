using MediatR;
using SnowStorm.QueryExecutors;
using SnowStormSample.Shared.Dto;
using SnowStormSample.Web.Data.Seminars;
using SnowStormSample.Web.Services.Queries.Seminars;

namespace SnowStormSample.Web.Services.Commands.Seminars
{
    public class SeminarSaveCommand : IRequest<bool>
    {
        public SeminarDto Data { get; set; }

        public SeminarSaveCommand(SeminarDto data)
        {
            Data = data;
        }
    }

    public class SeminarSaveCommandHandler : IRequestHandler<SeminarSaveCommand, bool>
    {
        private readonly IQueryExecutor _executor;

        public SeminarSaveCommandHandler(IQueryExecutor executor)
        {
            _executor = executor;
        }

        public async Task<bool> Handle(SeminarSaveCommand request, CancellationToken cancellationToken)
        {
            var value = await _executor.Get(new GetSeminarQuery(request.Data.Id));
            if (value == null)
                value = await Seminar.Create(_executor, request.Data);
            else
                value.Save(request.Data);

            await _executor.Save();

            return true;

        }
    }
}
