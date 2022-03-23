using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DailyStat.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DailyStat.Controllers
{
    [ApiController, Route("stat/{statId}")]
    public class StatController
    {
        private readonly EventRepository eventRepository;

        public StatController(EventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<IEnumerable<>> GetDay(DateTime dt)
        {
            
        }
    }
}