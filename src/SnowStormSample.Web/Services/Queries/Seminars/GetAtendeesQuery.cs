using SnowStorm.QueryExecutors;
using SnowStormSample.Web.Data.Seminars;

namespace SnowStormSample.Web.Services.Queries.Seminars
{
    public class GetAtendeesQuery : IQueryResultList<Atendee>
    {
        private readonly long? _seminarId;

        /// <summary>
        /// Limit list ony to selected seminar. (Enforcing a business rule)
        /// </summary>
        /// <param name="seminarId"></param>
        public GetAtendeesQuery(long seminarId)
        {
            _seminarId = seminarId;
        }

        public IQueryable<Atendee> Get(IQueryableProvider queryableProvider)
        {
            var baseQuery = queryableProvider.Query<Atendee>();

            if (_seminarId.HasValue)
                baseQuery = baseQuery.Where(w => w.SeminarId == _seminarId.Value);

            return baseQuery
               .OrderBy(o => o.AttendeeName)
               .AsQueryable();
        }
    }
}
