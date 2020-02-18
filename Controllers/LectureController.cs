using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Controllers
{
    [Route("api/Meetup/{MeetupName}/lecture")]
    public class LectureController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;

        public LectureController(MeetupContext meetupContext,IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult Post(string meetupName, [FromBody]LectureDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var meetup = _meetupContext.Meetups
                .Include(m => m.Lectures)
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower().Equals(meetupName.ToLower()));

            return Created($"api/Meetup/{meetupName}", null);
        }
        
    }
}
        