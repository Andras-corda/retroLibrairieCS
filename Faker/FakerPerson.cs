using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retroLib.Faker
{
    /// <summary>
    /// Represents a generated fake person with personal and contact information.
    /// </summary>
    public class FakerPerson
    {
        /// <summary>
        /// Gets or sets the person's first name.
        /// </summary>
        public string FirstName { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's last name.
        /// </summary>
        public string LastName { get; set; } = "";

        /// <summary>
        /// Gets the person's full name composed of first and last name.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Gets or sets the person's gender.
        /// </summary>
        public string Gender { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's phone number.
        /// </summary>
        public string Phone { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's email address.
        /// </summary>
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's address.
        /// </summary>
        public string Address { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the person's country.
        /// </summary>
        public string Country { get; set; } = "";

        /// <summary>
        /// Gets or sets the person's city.
        /// </summary>
        public string City { get; set; } = "";
    }
}
