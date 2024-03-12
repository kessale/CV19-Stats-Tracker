using System.Collections.Generic;
using System.Windows;

// Represents general information about a location including its name, geographical location, and confirmed case counts.
namespace CV19.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; } // The name of the place.
        public Point Location { get; set; } // The geographical location as a Point.

        public IEnumerable<ConfirmedCount> Counts { get; set; } // A collection of confirmed case counts over time.
    }
}
