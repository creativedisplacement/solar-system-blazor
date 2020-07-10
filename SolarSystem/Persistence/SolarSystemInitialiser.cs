using System;
using System.Linq;
using SolarSystem.Domain.Entities;

namespace SolarSystem.Persistence
{
    public class SolarSystemInitialiser
    {
        public static void Initialise(SolarSystemDbContext context)
        {
            var initialiser = new SolarSystemInitialiser();
            initialiser.SeedEverything(context);
        }

        public void SeedEverything(SolarSystemDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Planets.Any())
            {
                return;
            }

            SeedPlanets(context);
        }


        public void SeedPlanets(SolarSystemDbContext context)
        {
            var planets = new[]
            {
                new Planet(Guid.NewGuid(),
                    "Mercury", 
                    "The smallest planet in our solar system and nearest to the Sun, Mercury is only slightly larger than Earth's Moon.", 
                    "From the surface of Mercury, the Sun would appear more than three times as large as it does when viewed from Earth, and the sunlight would be as much as seven times brighter. Despite its proximity to the Sun, Mercury is not the hottest planet in our solar system – that title belongs to nearby Venus, thanks to its dense atmosphere. \r\n Mercury formed about 4.5 billion years ago when gravity pulled swirling gas and dust together to form this small planet nearest the Sun. Like its fellow terrestrial planets, Mercury has a central core, a rocky mantle and a solid crust. \r\n Temperatures on the surface of Mercury are extreme, both hot and cold. During the day, temperatures on Mercury's surface can reach 800 degrees Fahrenheit (430 degrees Celsius). Because the planet has no atmosphere to retain that heat, nighttime temperatures on the surface can drop to minus 290 degrees Fahrenheit (minus 180 degrees Celsius). \r\n Mercury may have water ice at its north and south poles inside deep craters, but only in regions of permanent shadow. There it could be cold enough to preserve water ice despite the high temperatures on sunlit parts of the planet. \r\n Mercury's highly eccentric, egg-shaped orbit takes the planet as close as 29 million miles (47 million kilometers) and as far as 43 million miles (70 million kilometers) from the Sun. It speeds around the Sun every 88 days, traveling through space at nearly 29 miles (47 kilometers) per second, faster than any other planet.\r\n Mercury's axis of rotation is tilted just 2 degrees with respect to the plane of its orbit around the Sun. That means it spins nearly perfectly upright and so does not experience seasons like many other planets do. \r\n Mercury's environment is not conducive to life as we know it. The temperatures and solar radiation that characterize this planet are most likely too extreme for organisms to adapt to.",
                    5.43,
                    2,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/769_PIA16820.jpg",
                    1408,
                    0.24,
                    2439,
                    0,
                    0.3871,
                    0.206,
                    47.89,
                    0.06,
                    7,
                    "Terrestrial",
                    1),
                new Planet(Guid.NewGuid(),
                    "Venus", 
                    "The second planet from the Sun and our closest planetary neighbour.", 
                    "Similar in structure and size to Earth, Venus spins slowly in the opposite direction from most planets. Its thick atmosphere traps heat in a runaway greenhouse effect, making it the hottest planet in our solar system with surface temperatures hot enough to melt lead. Glimpses below the clouds reveal volcanoes and deformed mountains. \r\n Venus is named for the ancient Roman goddess of love and beauty, who was known as Aphrodite to the Ancient Greeks. \n Venus' rotation and orbit are unusual in several ways. Venus is one of just two planets that rotate from east to west. Only Venus and Uranus have this 'backwards' rotation. It completes one rotation in 243 Earth days — the longest day of any planet in our solar system, even longer than a whole year on Venus. But the Sun doesn't rise and set each 'day' on Venus like it does on most other planets. On Venus, one day-night cycle takes 117 Earth days because Venus rotates in the direction opposite of its orbital revolution around the Sun. \r\n No human has visited Venus, but the spacecraft that have been sent to the surface of Venus do not last very long there. Venus' high surface temperatures overheat electronics in spacecraft in a short time, so it seems unlikely that a person could survive for long on the Venusian surface. \r\n There is speculation about life existing in Venus' distant past, as well as questions about the possibility of life in the top cloud layers of Venus' atmosphere, where the temperatures are less extreme.",
                    5.25,
                    177.3,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/688_Venus.jpg",
                    5832,
                    0.62,
                    6052,
                    0,
                    0.7233,
                    0.007,
                    35.04,
                    0.82,
                    3.4,
                    "Terrestrial",
                    2),
                new Planet(Guid.NewGuid(),
                    "Earth", 
                    "Our home planet is the third planet from the Sun, and the only place we know of so far that’s inhabited by living things.", 
                    "While Earth is only the fifth largest planet in the solar system, it is the only world in our solar system with liquid water on the surface. Just slightly larger than nearby Venus, Earth is the biggest of the four planets closest to the Sun, all of which are made of rock and metal. \r\n The name Earth is at least 1,000 years old. All of the planets, except for Earth, were named after Greek and Roman gods and goddesses. However, the name Earth is a Germanic word, which simply means “the ground.” \r\n As Earth orbits the Sun, it completes one rotation every 23.9 hours. It takes 365.25 days to complete one trip around the Sun. That extra quarter of a day presents a challenge to our calendar system, which counts one year as 365 days. To keep our yearly calendars consistent with our orbit around the Sun, every four years we add one day. That day is called a leap day, and the year it's added to is called a leap year. \r\n Earth's axis of rotation is tilted 23.4 degrees with respect to the plane of Earth's orbit around the Sun. This tilt causes our yearly cycle of seasons. During part of the year, the northern hemisphere is tilted toward the Sun and the southern hemisphere is tilted away. With the Sun higher in the sky, solar heating is greater in the north producing summer there. Less direct solar heating produces winter in the south. Six months later, the situation is reversed. When spring and fall begin, both hemispheres receive roughly equal amounts of heat from the Sun. \r\n Earth has a very hospitable temperature and mix of chemicals that have made life possible here. Most notably, Earth is unique in that most of our planet is covered in water, since the temperature allows liquid water to exist for extended periods of time. Earth's vast oceans provided a convenient place for life to begin about 3.8 billion years ago.",
                    5.52,
                    23.45,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/786_1-bluemarble_west.jpg",
                    23.93,
                    1,
                    6378,
                    1,
                    1,
                    0.017,
                    29.79,
                    1,
                    0,
                    "Terrestrial",
                    3),
                new Planet(Guid.NewGuid(),
                    "Mars", 
                    "The fourth planet from the Sun, Mars is a dusty, cold, desert world with a very thin atmosphere.", 
                    "This dynamic planet has seasons, polar ice caps and weather and canyons and extinct volcanoes, evidence of an even more active past. \r\n Mars is one of the most explored bodies in our solar system, and it's the only planet where we've sent rovers to roam the alien landscape. NASA currently has three spacecraft in orbit, one rover and one lander on the surface and another rover under construction here on Earth. India and ESA also have spacecraft in orbit above Mars. \r\n These robotic explorers have found lots of evidence that Mars was much wetter and warmer, with a thicker atmosphere, billions of years ago. \r\n As Mars orbits the Sun, it completes one rotation every 24.6 hours, which is very similar to one day on Earth (23.9 hours). Martian days are called sols—short for 'solar day'. A year on Mars lasts 669.6 sols, which is the same as 687 Earth days. \r\n Mars' axis of rotation is tilted 25 degrees with respect to the plane of its orbit around the Sun. This is another similarity with Earth, which has an axial tilt of 23.4 degrees. Like Earth, Mars has distinct seasons, but they last longer than seasons here on Earth since Mars takes longer to orbit the Sun (because it's farther away). And while here on Earth the seasons are evenly spread over the year, lasting 3 months (or one quarter of a year), on Mars the seasons vary in length because of Mars' elliptical, egg-shaped orbit around the Sun. \r\n Scientists don't expect to find living things currently thriving on Mars. Instead, they're looking for signs of life that existed long ago, when Mars was warmer and covered with water.",
                    3.95,
                    25.19,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/683_6453_mars-globe-valles-marineris-enhanced-full2.jpg",
                    24.62,
                    1.88,
                    3397,
                    2,
                    1.524,
                    0.093,
                    24.14,
                    0.11,
                    1.85,
                    "Terrestrial",
                    4),
                new Planet(Guid.NewGuid(),
                    "Jupiter", 
                    "The fifth planet from our Sun and is, by far, the largest planet in the solar system – more than twice as massive as all the other planets combined.", 
                    "Jupiter's stripes and swirls are actually cold, windy clouds of ammonia and water, floating in an atmosphere of hydrogen and helium. Jupiter’s iconic Great Red Spot is a giant storm bigger than Earth that has raged for hundreds of years. \r\n Jupiter is surrounded by dozens of moons. Jupiter also has several rings, but unlike the famous rings of Saturn, Jupiter’s rings are very faint and made of dust, not ice.\r\n Jupiter has the shortest day in the solar system. One day on Jupiter takes only about 10 hours (the time it takes for Jupiter to rotate or spin around once), and Jupiter makes a complete orbit around the Sun (a year in Jovian time) in about 12 Earth years (4,333 Earth days).\r\n Its equator is tilted with respect to its orbital path around the Sun by just 3 degrees. This means Jupiter spins nearly upright and does not have seasons as extreme as other planets do. \r\n Jupiter’s environment is probably not conducive to life as we know it. The temperatures, pressures and materials that characterize this planet are most likely too extreme and volatile for organisms to adapt to. \r\nWhile planet Jupiter is an unlikely place for living things to take hold, the same is not true of some of its many moons. Europa is one of the likeliest places to find life elsewhere in our solar system. There is evidence of a vast ocean just beneath its icy crust, where life could possibly be supported.",
                    1.33,
                    3.12,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/2486_stsci-h-p1936a_1800.jpg",
                    9.92,
                    11.86,
                    71490,
                    28,
                    5.203,
                    0.048,
                    13.06,
                    317.89,
                    1.3,
                    "Gas giant",
                    5),
                new Planet(Guid.NewGuid(),
                    "Saturn", 
                    "The sixth planet from the Sun and the second largest planet in our solar system.", 
                    "Adorned with thousands of beautiful ringlets, Saturn is unique among the planets. It is not the only planet to have rings—made of chunks of ice and rock—but none are as spectacular or as complicated as Saturn's. \r\n Like fellow gas giant Jupiter, Saturn is a massive ball made mostly of hydrogen and helium. \r\n Saturn has the second-shortest day in the solar system. One day on Saturn takes only 10.7 hours (the time it takes for Saturn to rotate or spin around once), and Saturn makes a complete orbit around the Sun (a year in Saturnian time) in about 29.4 Earth years (10,756 Earth days). \r\n Its axis is tilted by 26.73 degrees with respect to its orbit around the Sun, which is similar to Earth's 23.5-degree tilt. This means that, like Earth, Saturn experiences seasons. \r\n Saturn's environment is not conducive to life as we know it. The temperatures, pressures and materials that characterize this planet are most likely too extreme and volatile for organisms to adapt to. \r\n While planet Saturn is an unlikely place for living things to take hold, the same is not true of some of its many moons. Satellites like Enceladus and Titan, home to internal oceans, could possibly support life.",
                    0.69,
                    26.73,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/16020_6020_IMG005020_ai_wm_display.jpg",
                    29.46,
                    1,
                    60268,
                    30,
                    9.539,
                    00.056,
                    9.64,
                    95.18,
                    2.49,
                    "Gas giant",
                    6),
                new Planet(Guid.NewGuid(),
                    "Uranus", 
                    "The seventh planet from the Sun with the third largest diameter in our solar system, Uranus is very cold and windy.", 
                    "The ice giant is surrounded by 13 faint rings and 27 small moons as it rotates at a nearly 90-degree angle from the plane of its orbit. This unique tilt makes Uranus appear to spin on its side, orbiting the Sun like a rolling ball. \r\n The first planet found with the aid of a telescope, Uranus was discovered in 1781 by astronomer William Herschel, although he originally thought it was either a comet or a star. It was two years later that the object was universally accepted as a new planet, in part because of observations by astronomer Johann Elert Bode. \r\n William Herschel tried unsuccessfully to name his discovery Georgium Sidus after King George III. Instead the planet was named for Uranus, the Greek god of the sky, as suggested by Johann Bode. \r\n One day on Uranus takes about 17 hours (the time it takes for Uranus to rotate or spin once). And Uranus makes a complete orbit around the Sun (a year in Uranian time) in about 84 Earth years (30,687 Earth days). \r\n Uranus is the only planet whose equator is nearly at a right angle to its orbit, with a tilt of 97.77 degrees—possibly the result of a collision with an Earth-sized object long ago. This unique tilt causes the most extreme seasons in the solar system. For nearly a quarter of each Uranian year, the Sun shines directly over each pole, plunging the other half of the planet into a 21-year-long, dark winter. \r\n Uranus is also one of just two planets that rotate in the opposite direction than most of the planets (Venus is the other one), from east to west. \r\n Uranus' environment is not conducive to life as we know it. The temperatures, pressures and materials that characterize this planet are most likely too extreme and volatile for organisms to adapt to.",
                    1.29,
                    97.86,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/599_PIA18182.jpg",
                    17.24,
                    84.01,
                    25559,
                    24,
                    19.19,
                    0.046,
                    6.81,
                    14.53,
                    0.77,
                    "Ice giant",
                    7),
                new Planet(Guid.NewGuid(),
                    "Neptune", 
                    "Dark, cold and whipped by supersonic winds, ice giant Neptune is the eighth and most distant planet in our solar system.", 
                    "More than 30 times as far from the Sun as Earth, Neptune is the only planet in our solar system not visible to the naked eye. In 2011 Neptune completed its first 165-year orbit since its discovery in 1846. \r\n Neptune is so far from the Sun that high noon on the big blue planet would seem like dim twilight to us. The warm light we see here on our home planet is roughly 900 times as bright as sunlight on Neptune. \r\n The ice giant Neptune was the first planet located through mathematical calculations. Using predictions made by Urbain Le Verrier, Johann Galle discovered the planet in 1846. The planet is named after the Roman god of the sea, as suggested by Le Verrier. \r\n One day on Neptune takes about 16 hours (the time it takes for Neptune to rotate or spin once). And Neptune makes a complete orbit around the Sun (a year in Neptunian time) in about 165 Earth years (60,190 Earth days). \r\n Sometimes Neptune is even farther from the Sun than dwarf planet Pluto. Pluto's highly eccentric, oval-shaped orbit brings it inside Neptune's orbit for a 20-year period every 248 Earth years. This switch, in which Pluto is closer to the Sun than Neptune, happened most recently from 1979 to 1999. Pluto can never crash into Neptune, though, because for every three laps Neptune takes around the Sun, Pluto makes two. This repeating pattern prevents close approaches of the two bodies. \r\n Neptune’s axis of rotation is tilted 28 degrees with respect to the plane of its orbit around the Sun, which is similar to the axial tilts of Mars and Earth. This means that Neptune experiences seasons just like we do on Earth; however, since its year is so long, each of the four seasons lasts for over 40 years.\r\n Neptune's environment is not conducive to life as we know it. The temperatures, pressures and materials that characterize this planet are most likely too extreme and volatile for organisms to adapt to.",
                    1.64,
                    29.6,
                    "https://solarsystem.nasa.gov/system/resources/detail_files/611_PIA01492.jpg",
                    16.11,
                    164.79,
                    25269,
                    8,
                    30.06,
                    0.01,
                    6.81,
                    17.14,
                    1.77,
                    "Ice giant",
                    8),
            };
            context.Planets.AddRange(planets);
            context.SaveChanges();
        }
    }
}