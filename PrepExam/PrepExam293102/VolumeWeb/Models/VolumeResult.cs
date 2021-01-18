using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VolumeWebService
{
    public class VolumeResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("height")]
        [Range(0, Double.MaxValue)]
        public double Height { get; set; }
        
        [JsonPropertyName("radius")]
        [Range(0, Double.MaxValue)]
        public double Radius { get; set; }
        
        [JsonPropertyName("volume")]
        public double Volume { get; set; }
    }
}