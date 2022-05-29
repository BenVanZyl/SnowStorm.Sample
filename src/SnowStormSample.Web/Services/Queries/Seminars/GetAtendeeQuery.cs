using SnowStorm.QueryExecutors;
using SnowStormSample.Web.Data.Seminars;

namespace SnowStormSample.Web.Services.Queries.Seminars
{
    public class GetAtendeeQuery : IQueryResultSingle<Atendee>
    {
        private readonly long _id;

        public GetAtendeeQuery(long id)
        {
            _id = id;
        }

        public IQueryable<Atendee> Get(IQueryableProvider queryableProvider)
        {
            return queryableProvider.Query<Atendee>()
               .Where(w => w.Id == _id);
        }
    }
}

