using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNP_FamilyOverview1.Models.Families
{
    public class Family
    {
        public int Id { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "House number must be greater than 0")]
        public int HouseNumber { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
        }

        public int TotalFamilyMembers() =>
            Children!=null ? Adults.Count + Children.Count : Adults.Count;

    }


}