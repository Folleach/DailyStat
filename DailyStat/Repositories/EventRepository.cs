using System;
using System.Threading.Tasks;
using DailyStat.Entities;

namespace DailyStat.Repositories
{
    public class EventRepository : CassandraRepository
    {
        public EventRepository(CassandraCluster context) : base(context)
        {
            CreateIfNotExists<EventEntity>();
        }

        public async Task<bool> Add(string id, string thingId, DateTime startTime)
        {
            var yearDay = startTime.CreateYearDayValue();
            await GetMapper().InsertAsync(new EventEntity()
            {
                StatId = id,
                StartTime = startTime,
                ThingId = thingId,
                YearDay = yearDay
            });

            return await GetMapper().FetchAsync<EventEntity>(
                $"WHERE {nameof(EventEntity.StatId)} = ? AND {nameof(EventEntity.YearDay)} = ? AND {nameof(EventEntity.StartTime)} = ?",
                id, yearDay, startTime) != null;
        }
    }
}
