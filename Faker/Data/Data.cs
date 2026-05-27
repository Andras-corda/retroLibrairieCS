using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Faker.Data
{
    /// <summary>
    /// Represents name-related data used by the Faker system.
    /// </summary>
    internal class NamesData
    {
        /// <summary>
        /// Gets or sets the collection of male first names.
        /// </summary>
        public List<string> FirstNamesMale { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of female first names.
        /// </summary>
        public List<string> FirstNamesFemale { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of last names.
        /// </summary>
        public List<string> LastNames { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of email domains.
        /// </summary>
        public List<string> EmailDomains { get; set; } = new();
    }

    /// <summary>
    /// Represents location-related data used by the Faker system.
    /// </summary>
    internal class PlacesData
    {
        /// <summary>
        /// Gets or sets the collection of country names.
        /// </summary>
        public List<string> Countries { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of city names.
        /// </summary>
        public List<string> Cities { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of street names.
        /// </summary>
        public List<string> Streets { get; set; } = new();
    }
}
