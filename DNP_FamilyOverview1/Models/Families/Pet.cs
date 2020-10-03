using System.ComponentModel.DataAnnotations;

namespace DNP_FamilyOverview1.Models.Families
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}