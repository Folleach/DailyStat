using Cassandra;

namespace DailyStat
{
    public class CassandraCluster
    {
        private readonly Cluster cluster;
        private readonly ISession session;
        
        public CassandraCluster(string login, string password, string keyspace, params string[] contactPoints)
        {
            cluster = Cluster.Builder()
                .AddContactPoints(contactPoints)
                .WithAuthProvider(new PlainTextAuthProvider(login, password))
                .Build();

            session = cluster.Connect();
            session.CreateKeyspaceIfNotExists(keyspace);
        }

        public ISession GetSession()
        {
            return session;
        }
    }
}
