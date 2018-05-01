namespace CIT218FinalApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CIT218FinalApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Rollercoasters";
        }

        protected override void Seed(CIT218FinalApp.Models.ApplicationDbContext context)
        {
            var rollercoasters = new List<Models.Rollercoaster>
            {
                new Models.Rollercoaster()
                {
                    Name = "Top Thrill Dragster",
                    Description = "The Top Thrill Dragster is a steel accelerator roller coaster built by Intamin at Cedar Point in Sandusky, Ohio, United States.",
                    Speed = 120,
                    Height = 420,
                    Location = "Cedar Point, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "Millennium Force",
                    Description = "Millennium Force is a steel roller coaster built by Intamin at Cedar Point amusement park in Sandusky, Ohio, United States.",
                    Speed = 93,
                    Height = 308,
                    Location = "Cedar Point, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "Formula Rossa",
                    Description = "Formula Rossa is a launched roller coaster located at Ferrari World in Abu Dhabi, United Arab Emirates.",
                    Speed = 149,
                    Height = 174,
                    Location = "Abu Dhabi, United Arab Emirates"
                },
                new Models.Rollercoaster()
                {
                    Name = "Fury 325",
                    Description = "Fury 325 is a steel roller coaster at the Carowinds amusement park located in Charlotte, North Carolina and Fort Mill, South Carolina.",
                    Speed = 95,
                    Height = 325,
                    Location = "Charlotte, North Carolina"
                },
                new Models.Rollercoaster()
                {
                    Name = "Intimidator 305",
                    Description = "ntimidator 305 is a steel roller coaster located at Kings Dominion in Doswell, Virginia, United States.",
                    Speed = 90,
                    Height = 305,
                    Location = "Doswell, Virginia"
                },
                new Models.Rollercoaster()
                {
                    Name = "Steel Dragon 2000",
                    Description = "Steel Dragon 2000 is a steel roller coaster at Nagashima Spa Land amusement park in Mie Prefecture, Japan.",
                    Speed = 95,
                    Height = 318,
                    Location = "Kuwana, Japan"
                },
                new Models.Rollercoaster()
                {
                    Name = "El Toro",
                    Description = "El Toro, a Spanish term meaning The Bull, is a wooden roller coaster at Six Flags Great Adventure in Jackson, New Jersey. ",
                    Speed = 70,
                    Height = 181,
                    Location = "Jackson, New Jersey"
                },
                new Models.Rollercoaster()
                {
                    Name = "Superman: Escape from Krypton",
                    Description = "Superman: Escape from Krypton is a steel shuttle roller coaster located at Six Flags Magic Mountain in Valencia, California.",
                    Speed = 100,
                    Height = 415,
                    Location = "Valencia, California"
                },
                new Models.Rollercoaster()
                {
                    Name = "Intimidator",
                    Description = "Intimidator is a steel roller coaster built by Bolliger & Mabillard at Carowinds.",
                    Speed = 75,
                    Height = 232,
                    Location = "Charlotte, North Carolina"
                },
                new Models.Rollercoaster()
                {
                    Name = "Takabisha",
                    Description = "Takabisha is a Gerstlauer Euro-Fighter steel roller coaster located at the Fuji-Q Highland theme park in Fujiyoshida, Yamanashi, Japan.",
                    Speed = 62,
                    Height = 141,
                    Location = "Yamanashi, Japan"
                },
                new Models.Rollercoaster()
                {
                    Name = "Outlaw Run",
                    Description = "Outlaw Run is a wooden roller coaster located at the Silver Dollar City amusement park in Branson, Missouri.",
                    Speed = 68,
                    Height = 108,
                    Location = "Branson, Missouri"
                },
                new Models.Rollercoaster()
                {
                    Name = "Superman The Ride",
                    Description = "Superman the Ride is a steel roller coaster located at Six Flags New England in Agawam, Massachusetts. ",
                    Speed = 77,
                    Height = 208,
                    Location = "Agawam, Massachusetts"
                },
                new Models.Rollercoaster()
                {
                    Name = "The Racer ",
                    Description = "The Racer is a wooden, racing roller coaster located at Kings Island amusement park in Mason, Ohio.",
                    Speed = 53,
                    Height = 88,
                    Location = "Mason, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "Colossos",
                    Description = "Colossos is a wooden roller coaster at Heide Park in Soltau, Lower Saxony, Germany.",
                    Speed = 68,
                    Height = 171,
                    Location = "Lower Sazony, Germany"
                },
                new Models.Rollercoaster()
                {
                    Name = "The Smiler",
                    Description = "The Smiler is a steel roller coaster located at Alton Towers in Staffordshire, United Kingdom.",
                    Speed = 53,
                    Height = 72,
                    Location = "Staffordshire, United Kingdom"
                },
                new Models.Rollercoaster()
                {
                    Name = "The Beast",
                    Description = "The Beast is a wooden roller coaster located at Kings Island in Mason, Ohio. Built in-house, it opened in 1979 as the tallest, fastest, and longest wooden roller coaster in the world.",
                    Speed = 65,
                    Height = 112,
                    Location = "Mason, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "Valravn",
                    Description = "Valravn is a steel roller coaster at Cedar Point amusement park in Sandusky, Ohio. ",
                    Speed = 75,
                    Height = 223,
                    Location = "Sandusky, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "Dragon Khan",
                    Description = "Dragon Khan is a steel sit-down roller coaster located in the PortAventura Park theme park in Salou and Vilaseca, Catalonia, Spain.",
                    Speed = 141,
                    Height = 65,
                    Location = "Catalonia, Spain"
                },
                new Models.Rollercoaster()
                {
                    Name = "GateKeeper",
                    Description = "GateKeeper is a steel roller coaster located at Cedar Point in Sandusky, Ohio. Designed by Bolliger & Mabillard, it was the fifth Wing Coaster installation in the world.",
                    Speed = 67,
                    Height = 170,
                    Location = "Sanduskey, Ohio"
                },
                new Models.Rollercoaster()
                {
                    Name = "The Incredible Hulk Coaster",
                    Description = "The Incredible Hulk Coaster is a launched roller coaster located in the Universal's Islands of Adventure theme park at Universal Orlando Resort.",
                    Speed = 67,
                    Height = 110,
                    Location = "Orlando, Florida"
                }
            };

            rollercoasters.ForEach(r => context.rollercoasters.Add(r));
            context.SaveChanges();

            var reviews = new List<Models.Review>
            {
                new Models.Review()
            {
                RollercoasterId = 1,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Fun, but...",
                Content = "Fun ride, two hour wait for 7 seconds of pure adrenaline.",
                Rating = 3

            },
                new Models.Review()
            {
                RollercoasterId = 1,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Loved it!",
                Content = "Great experience , tons of g-force.",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 1,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "This ride is crazy",
                Content = "I have been on it and it was so cool. I can't believe that the third fastest roller coaster in the world is in Ohio.",
                Rating = 4

            },
                new Models.Review()
            {
                RollercoasterId = 2,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Loved it!",
                Content = "Hard to beat that first lift hill!  Great coaster!",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 2,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "It was Great!",
                Content = "Millennium Force will forever be one of my favorite coasters! It's always such a rush and is just an all around amazing ride! I recommend front seat for this one.",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 2,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Ride in the back",
                Content = "Back row is where it's at, great airtime on the drop, and on the airtime hills. Great view of the lake. It's overated as heck but it's still fun.",
                Rating = 4

            },
                new Models.Review()
            {
                RollercoasterId = 2,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Loved the Airtime",
                Content = "Great ride, tons of airtime, and it feels like it never slows down. Any coaster enthusiast would absolutely LOVE this.",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 7,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Best Wooden Coaster",
                Content = "This is just the best wooden coaster standing.   Ride the back car for an outrageous experience",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 7,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Don't miss this one",
                Content = "I'd you don't ride El Toro your missing out on life",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 7,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Loved it!",
                Content = "Hands down the fastest, craziest, longest wooden coaster ever.",
                Rating = 4

            },
                new Models.Review()
            {
                RollercoasterId = 7,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Amazing rollercoaster",
                Content = "Amazing rollercoaster",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 11,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Hasn't Aged Well",
                Content = "It broke down while we were on it.",
                Rating = 2

            },
                new Models.Review()
            {
                RollercoasterId = 11,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "It's Great",
                Content = "My family loved this",
                Rating = 1

            },
                new Models.Review()
            {
                RollercoasterId = 11,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Surprisingly Smooth",
                Content = "Best wooden coaster I've ever been on and it's smooth, unlike most wooden coasters ",
                Rating = 1

            },
                new Models.Review()
            {
                RollercoasterId = 11,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Not worth it",
                Content = "The wait time is not worth the 30 second ride. Overrated ride and no neck support equals sore neck.",
                Rating = 1

            },
                new Models.Review()
            {
                RollercoasterId = 16,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "It's a Beast!",
                Content = "All-time favorite coaster for speed and flying through the woods.",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 16,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "First-time Riders",
                Content = "If you're going to ride the Beast set up front first then wait for the back seat where it's more like wagging the tail and is absolutely fantastic and he just bounced around like riding a wild Bronco.",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 16,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Not the best",
                Content = "A little rough but a fast and long trip thtough the woods. Great night ride.",
                Rating = 3

            },
                new Models.Review()
            {
                RollercoasterId = 16,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "Better At night",
                Content = "Best ride at Kings Island. Even better after dark. Mystic Timbers a close second (after dark).",
                Rating = 5

            },
                new Models.Review()
            {
                RollercoasterId = 19,
                UserId = "43ee843e-0239-4c97-9632-77d5d52dc8fa",
                ReviewTitle = "So Good",
                Content = "It's obviously the best in the park.",
                Rating = 5

            }
            };

            reviews.ForEach(r => context.reviews.Add(r));
            context.SaveChanges();

            base.Seed(context);

        }
    }
}
