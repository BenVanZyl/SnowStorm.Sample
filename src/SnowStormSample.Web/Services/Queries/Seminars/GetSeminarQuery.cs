using SnowStorm.QueryExecutors;
using SnowStormSample.Web.Data.Seminars;

namespace SnowStormSample.Web.Services.Queries.Seminars
{
    public class GetSeminarQuery : IQueryResultSingle<Seminar>
    {
        private readonly long _id;

        public GetSeminarQuery(long id)
        {
            _id = id;
        }

        public IQueryable<Seminar> Get(IQueryableProvider queryableProvider)
        {
            return queryableProvider.Query<Seminar>()
               .Where(w => w.Id == _id);
        }
    }
}
