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
    [Route("api/Meetup")]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;
        public MeetupController(MeetupContext meetupContext,IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }
        // GET: Meetup
        public ActionResult<List<Meetup>> Get()
        {
            var meetups = _meetupContext.Meetups.Include(m=>m.Location).ToList();
            var meetupDtos = _mapper.Map<List<MeetupDetailsDto>>(meetups);
            return Ok(meetupDtos); 
            return meetups;
        }
    }
}