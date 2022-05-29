using SnowStorm.QueryExecutors;
using SnowStormSample.Web.Data.Seminars;

namespace SnowStormSample.Web.Services.Queries.Seminars
{
    public class GetSeminarsQuery : IQueryResultList<Seminar>
    {
         
        public IQueryable<Seminar> Get(IQueryableProvider queryableProvider)
        {
            return queryableProvider.Query<Seminar>()
               .OrderBy(o => o.Subject)
               .AsQueryable();
        }
    }
}
