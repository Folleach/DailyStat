using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DailyStat.Dtos;
using DailyStat.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DailyStat.Controllers
{
    [ApiController, Route("thing/{statId}")]
    public class ThingController
    {
        private readonly EventRepository eventRepository;
        private readonly ThingRepository thingRepository;

        private static readonly Regex NormalizeRegex = new Regex("[^A-Za-zА-Яа-я0-9]", RegexOptions.Compiled);

        public ThingController(EventRepository eventRepository, ThingRepository thingRepository)
        {
            this.eventRepository = eventRepository;
            this.thingRepository = thingRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ThingDto>> Get(string statId)
        {
            return (await thingRepository.Get(statId)).Select(x => new ThingDto()
            {
                Id = x.Id,
                Name = x.DisplayName,
                Color = x.Color,
                IsCurrent = false
            });
        }

        [HttpPost]
        public async Task<ActionResult<EventInsertDto>> Post(string statId, [FromBody] InsertDataDto data)
        {
            var normalizedName = NormalizeRegex.Replace(data.ThingName, string.Empty).ToLower();
            await thingRepository.AddIfNotExists(statId, normalizedName, data.ThingName);
            var success = await eventRepository.Add(statId, normalizedName, DateTime.UtcNow);

            return new EventInsertDto()
            {
                Success = success,
                Selected = success ? normalizedName : string.Empty
            };
        }
    }
}
