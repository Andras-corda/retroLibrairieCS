using retroLib.Faker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Faker
{
    /// <summary>
    /// Provides methods for building complete fake objects and entities.
    /// </summary>
    public static class FakerBuilder
    {
        /// <summary>
        /// Generates a fake person with randomly generated personal and contact information.
        /// </summary>
        /// <param name="seed">
        /// An optional seed value used to produce deterministic results.
        /// If null, a random seed is used.
        /// </param>
        /// <returns>
        /// A <see cref="FakerPerson"/> instance populated with generated data.
        /// </returns>
        public static FakerPerson Person(int? seed = null)
        {
            var rng = seed.HasValue ? new Random(seed.Value) : new Random();
            var names = FakerDataLoader.Load<NamesData>("names.json");
            var places = FakerDataLoader.Load<PlacesData>("places.json");

            string first = rng.Next(2) == 0
                ? names.FirstNamesMale[rng.Next(names.FirstNamesMale.Count)]
                : names.FirstNamesFemale[rng.Next(names.FirstNamesFemale.Count)];

            string last = names.LastNames[rng.Next(names.LastNames.Count)];
            string domain = names.EmailDomains[rng.Next(names.EmailDomains.Count)];
            string city = places.Cities[rng.Next(places.Cities.Count)];
            string country = places.Countries[rng.Next(places.Countries.Count)];
            int number = rng.Next(1, 200);
            string street = places.Streets[rng.Next(places.Streets.Count)];

            string email = rng.Next(4) switch
            {
                0 => $"{first.ToLower()}.{last.ToLower()}@{domain}",
                1 => $"{first.ToLower()}{last.ToLower()}@{domain}",
                2 => $"{char.ToLower(first[0])}{last.ToLower()}@{domain}",
                _ => $"{first.ToLower()}.{last.ToLower()}{rng.Next(100)}@{domain}"
            };

            return new FakerPerson
            {
                FirstName = first,
                LastName = last,
                Email = email,
                City = city,
                Country = country,
                Address = $"{number} {street}, {city}",
                Age = rng.Next(18, 80),
                Gender = rng.Next(2) == 0 ? "Male" : "Female",
                Phone = $"+{rng.Next(1, 100)} {rng.Next(100, 999)} {rng.Next(100, 999)} {rng.Next(1000, 9999)}"
            };
        }
    }
}
