using System.Runtime.Serialization;

namespace DailyStat.Dtos
{
    [DataContract]
    public class InsertDataDto
    {
        [DataMember(Name = "thingName")] public string ThingName { get; set; }
    }
}
