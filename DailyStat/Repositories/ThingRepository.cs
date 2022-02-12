using System.Collections.Generic;
using System.Threading.Tasks;
using DailyStat.Dtos;
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

        public async Task<IEnumerable<ThingEntity>> Get(string statId)
        {
            return await GetMapper().FetchAsync<ThingEntity>($"WHERE {nameof(ThingEntity.StatId)} = ?", statId);
        }
    }
}
