using Cassandra.Mapping;

namespace DailyStat
{
    public class MyMappings : Mappings
    {
        protected readonly string Keyspace;

        public MyMappings(string keyspace)
        {
            Keyspace = keyspace;
        }

        protected Map<TPoco> My<TPoco>() => For<TPoco>().KeyspaceName(Keyspace);   
    }
}
