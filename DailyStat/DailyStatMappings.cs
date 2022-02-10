using Cassandra.Mapping;
using DailyStat.Entities;

namespace DailyStat
{
    public class DailyStatMappings : MyMappings
    {
        public DailyStatMappings() : base("dailyStat")
        {
            My<EventEntity>()
                .PartitionKey(nameof(EventEntity.StatId), nameof(EventEntity.YearDay))
                .ClusteringKey(e => e.StartTime, SortOrder.Ascending)
                .TableName("events");

            My<ThingEntity>()
                .PartitionKey(thing => thing.StatId)
                .ClusteringKey(thing => thing.Id)
                .TableName("things");
        }
    }
}
