using System;
using System.Text.Json.Serialization;

namespace DailyStat
{
    [Serializable]
    public class DailyStatSettings
    {
        [JsonPropertyName("cassandraUserName")] public string CassandraUserName { get; set; }
        [JsonPropertyName("cassandraPassword")] public string CassandraPassword { get; set; }
        [JsonPropertyName("cassandraContactPoints")] public string[] CassandraContactPoints { get; set; }
    }
}
