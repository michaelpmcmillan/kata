﻿using System.Text.Json.Serialization;

namespace HolidaySearch.Model
{
    public class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("departure_date")]
        public DateTime DepartureDate { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }
    }
}