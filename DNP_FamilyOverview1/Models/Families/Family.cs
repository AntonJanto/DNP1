using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DNP_FamilyOverview1.Models.Families
{
    public class Family
    {
        //public int Id { get; set; }

        [JsonPropertyName("streetName")]
        [Required]
        public string StreetName { get; set; }

        [JsonPropertyName("houseNumber")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "House number must be greater than 0")]
        public int HouseNumber { get; set; }

        
        [JsonPropertyName("adults")]
        public List<Adult> Adults { get; set; }

        [JsonPropertyName("children")]
        public List<Child> Children { get; set; }

        [JsonPropertyName("pets")]
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

        public int TotalFamilyMembers() =>
            Children!=null ? Adults.Count + Children.Count : Adults.Count;

    }


}