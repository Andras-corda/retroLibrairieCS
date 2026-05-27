using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace retroLib.Faker
{
    /// <summary>
    /// Provides functionality for loading embedded Faker data resources.
    /// </summary>
    internal static class FakerDataLoader
    {
        /// <summary>
        /// Loads and deserializes an embedded JSON resource into the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The target type used for deserialization.
        /// </typeparam>
        /// <param name="filename">
        /// The name of the embedded JSON resource file.
        /// </param>
        /// <returns>
        /// An instance of the specified type populated with data from the resource.
        /// </returns>
        public static T Load<T>(string filename)
        {
            var assembly = typeof(FakerDataLoader).Assembly;
            var resourceName = $"retroLib.Faker.Data.{filename}";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream!);
            return JsonSerializer.Deserialize<T>(reader.ReadToEnd())!;
        }
    }
}
