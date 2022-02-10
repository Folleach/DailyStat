using Cassandra.Data.Linq;
using Cassandra.Mapping;

namespace DailyStat
{
    public class CassandraRepository
    {
        private readonly CassandraCluster context;
        private readonly Mapper mapper;

        public CassandraRepository(CassandraCluster context)
        {
            this.context = context;
            var session = context.GetSession();

            mapper = new Mapper(session);
        }

        protected void CreateIfNotExists<TTable>()
        {
            var requestsTable = new Table<TTable>(context.GetSession());
            requestsTable.CreateIfNotExists();
        }

        protected Mapper GetMapper() => mapper;
    }
}
