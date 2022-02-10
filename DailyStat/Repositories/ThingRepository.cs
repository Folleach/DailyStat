using System.Threading.Tasks;
using DailyStat.Entities;

namespace DailyStat.Repositories
{
    public class ThingRepository : CassandraRepository
    {
        public ThingRepository(CassandraCluster context) : base(context)
        {
            CreateIfNotExists<ThingEntity>();
        }

        public async Task AddIfNotExists(string statId, string thingId, string displayName)
        {
            await GetMapper().InsertIfNotExistsAsync(new ThingEntity()
            {
                StatId = statId,
                Id = thingId,
                DisplayName = displayName,
                Color = "#fff"
            });
        }
    }
}
