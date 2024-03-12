using System;

// Represents the count of confirmed cases on a specific date.
namespace CV19.Models
{
    internal struct ConfirmedCount
    {
        public DateTime Date { get; set; } // The date of the count.
        public int Count { get; set; } // The number of confirmed cases.
    }
}
