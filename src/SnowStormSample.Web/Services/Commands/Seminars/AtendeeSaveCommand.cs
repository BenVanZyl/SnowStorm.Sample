using MediatR;
using SnowStorm.QueryExecutors;
using SnowStormSample.Shared.Dto;
using SnowStormSample.Web.Data.Seminars;
using SnowStormSample.Web.Services.Queries.Seminars;

namespace SnowStormSample.Web.Services.Commands.Seminars
{
    public class AtendeeSaveCommand : IRequest<bool>
    {
        public AtendeeDto Data { get; set; }

        public AtendeeSaveCommand(AtendeeDto data)
        {
            Data = data;
        }
    }

    public class AtendeeSaveCommandHandler : IRequestHandler<AtendeeSaveCommand, bool>
    {
        private readonly IQueryExecutor _executor;

        public AtendeeSaveCommandHandler(IQueryExecutor executor)
        {
            _executor = executor;
        }

        public async Task<bool> Handle(AtendeeSaveCommand request, CancellationToken cancellationToken)
        {
            var value = await _executor.Get(new GetAtendeeQuery(request.Data.Id));
            if (value == null)
                value = await Atendee.Create(_executor, request.Data);
            else
                value.Save(request.Data);

            await _executor.Save();

            return true;

        }
    }
}
