using AutoMapper;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI
{
    public class MeetupProfile:Profile        
    {
        public MeetupProfile()
        {
            CreateMap<Meetup, MeetupDetailsDto>()
                .ForMember(m => m.Name, map => map.MapFrom(meetup => meetup.Name))
                .ForMember(m => m.Organizer, map => map.MapFrom(meetup => meetup.Organizer))
                .ForMember(m => m.Date, map => map.MapFrom(meetup => meetup.Date))
                .ForMember(m => m.IsPrivate, map => map.MapFrom(meetup => meetup.IsPrivate))
                .ForMember(m => m.City, map => map.MapFrom(meetup => meetup.Location.City))
                .ForMember(m => m.Street, map => map.MapFrom(meetup => meetup.Location.Street))
                .ForMember(m => m.PostCode, map => map.MapFrom(meetup => meetup.Location.PostCode));

            CreateMap<MeetupDto, Meetup>();

            CreateMap<LectureDto, Lecture>()
                .ReverseMap();
        }
    }
}
