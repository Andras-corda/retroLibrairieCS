using retroLib.Faker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Faker
{
    /// <summary>
    /// Provides methods for generating fake data such as names,
    /// addresses, internet information, and person-related values.
    /// </summary>
    public static class Faker
    {
        private static readonly Random _rng = new();
        private static readonly NamesData _names = FakerDataLoader.Load<NamesData>("names.json");
        private static readonly PlacesData _places = FakerDataLoader.Load<PlacesData>("places.json");

        /// <summary>
        /// Provides methods for generating fake names.
        /// </summary>
        public static class FakerName
        {
            /// <summary>
            /// Generates a random first name (male or female).
            /// </summary>
            /// <returns>A randomly selected first name.</returns>
            public static string FirstName() => _rng.Next(2) == 0 ? FirstNameMale() : FirstNameFemale();

            /// <summary>
            /// Generates a random male first name.
            /// </summary>
            /// <returns>A randomly selected male first name.</returns>
            public static string FirstNameMale() => _names.FirstNamesMale[_rng.Next(_names.FirstNamesMale.Count)];

            /// <summary>
            /// Generates a random female first name.
            /// </summary>
            /// <returns>A randomly selected female first name.</returns>
            public static string FirstNameFemale() => _names.FirstNamesFemale[_rng.Next(_names.FirstNamesFemale.Count)];

            /// <summary>
            /// Generates a random last name.
            /// </summary>
            /// <returns>A randomly selected last name.</returns>
            public static string LastName() => _names.LastNames[_rng.Next(_names.LastNames.Count)];

            /// <summary>
            /// Generates a full name consisting of a first name and a last name.
            /// </summary>
            /// <returns>A randomly generated full name.</returns>
            public static string FullName() => $"{FirstName()} {LastName()}";
        }

        /// <summary>
        /// Provides methods for generating fake internet-related data.
        /// </summary>
        public static class FakerInternet
        {
            /// <summary>
            /// Generates a random email address.
            /// </summary>
            /// <returns>A randomly generated email address.</returns>
            public static string Email()
            {
                string first = FakerName.FirstName().ToLower();
                string last = FakerName.LastName().ToLower();
                string domain = _names.EmailDomains[_rng.Next(_names.EmailDomains.Count)];
                return _rng.Next(4) switch
                {
                    0 => $"{first}.{last}@{domain}",
                    1 => $"{first}{last}@{domain}",
                    2 => $"{first[0]}{last}@{domain}",
                    _ => $"{first}.{last}{_rng.Next(100)}@{domain}"
                };
            }
        }

        /// <summary>
        /// Provides methods for generating fake address information.
        /// </summary>
        public static class FakerAddress
        {
            /// <summary>
            /// Generates a random city name.
            /// </summary>
            /// <returns>A randomly selected city.</returns>
            public static string City() => _places.Cities[_rng.Next(_places.Cities.Count)];

            /// <summary>
            /// Generates a random country name.
            /// </summary>
            /// <returns>A randomly selected country.</returns>
            public static string Country() => _places.Countries[_rng.Next(_places.Countries.Count)];

            /// <summary>
            /// Generates a random street address.
            /// </summary>
            /// <returns>A randomly generated street address.</returns>
            public static string Street()
            {
                int number = _rng.Next(1, 200);
                string street = _places.Streets[_rng.Next(_places.Streets.Count)];
                return $"{number} {street}";
            }

            /// <summary>
            /// Generates a complete address including street, city, and country.
            /// </summary>
            /// <returns>A randomly generated full address.</returns>
            public static string Full() => $"{Street()}, {City()}, {Country()}";
        }

        /// <summary>
        /// Provides methods for generating fake person-related data.
        /// </summary>
        public static class FakerHuman
        {
            /// <summary>
            /// Generates a random age between 18 and 79.
            /// </summary>
            /// <returns>A randomly generated age.</returns>
            public static int Age() => _rng.Next(18, 80);

            /// <summary>
            /// Generates a random gender value.
            /// </summary>
            /// <returns>
            /// Either <c>"Male"</c> or <c>"Female"</c>.
            /// </returns>
            public static string Gender() => _rng.Next(2) == 0 ? "Male" : "Female";

            /// <summary>
            /// Generates a random phone number with an international-style format.
            /// </summary>
            /// <returns>
            /// A randomly generated phone number.
            /// </returns>
            public static string Phone()
            {
                int countryCode = _rng.Next(1, 100);
                int part1 = _rng.Next(100, 999);
                int part2 = _rng.Next(100, 999);
                int part3 = _rng.Next(1000, 9999);
                return $"+{countryCode} {part1} {part2} {part3}";
            }
        }
    }
}
