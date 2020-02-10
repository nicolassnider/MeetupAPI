using MeetupAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPI
{
    public class MeetupSeeder
    {
        private readonly MeetupContext _meetupContext;

        public MeetupSeeder(MeetupContext meetupContext)
        {
            _meetupContext = meetupContext;
        }

        public void Seed()
        {
            if (_meetupContext.Database.CanConnect())
            {
                if (!_meetupContext.Meetups.Any()) { 
                
                    InsertSimpleData();
                }
            }
        }

        private void InsertSimpleData()
        {
            var meetups = new List<Meetup>
            {
                new Meetup{
                Name="Web summit",
                Date =DateTime.Now.AddDays(7),
                IsPrivate=  false,
                Organizer="Microsoft",
                Location= new Location
                {
                    City="Krakow",
                    Street="Szeroka 33/5",
                    PostCode="31-337"
                },
                Lectures = new List<Lecture>
                {
                    new Lecture{
                        Author="Bob Clark",
                        Topic="Modern Browsers",
                        Description="Deep dive into V8"
                    }
                }
                },
                new Meetup{
                Name="Summit web",
                Date =DateTime.Now.AddDays(7),
                IsPrivate=  false,
                Organizer="Macrofost",
                Location= new Location
                {
                    City="Warbok",
                    Street="Salerosa 35",
                    PostCode="44-447"
                },
                Lectures = new List<Lecture>
                {
                    new Lecture{
                        Author="Clark Bob",
                        Topic="Mufern Bowsers",
                        Description="Deep dive into V9"
                    },
                    new Lecture{
                        Author="Clark",
                        Topic="Modern",
                        Description="Deep dive into V10"
                    },
                    new Lecture{
                        Author="Bark",
                        Topic="Browsers",
                        Description="Deep dive into V11"
                    }
                }
                }
            };
            _meetupContext.AddRange(meetups);
            _meetupContext.SaveChanges();

        }
    }
}
