using System.ComponentModel.DataAnnotations;

namespace ViaExample.Models
{
    public class Course
    {
        [Key, MaxLength(4)]
        public string Id { get; set; }
        
        [Required, MaxLength(256)]
        public string Name { get; set; }
        
        [Range(1,7,ErrorMessage = "This ain't GBE, yo!")]
        public int Semester { get; set; }
        
        [Required]
        public bool IsElective { get; set; }
    }
}