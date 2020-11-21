using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViaExample.Models
{
    public class Programme
    {
        public int Id { get; set; }
        
        [Required, MaxLength(256)]
        public string Name { get; set; }
        
        [Required, MaxLength(16)]
        public string ShortName { get; set; }
        
        [Required, MaxLength(4)]
        public string HeadOfDepartment { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        public ICollection<Course> Courses { get; set; }
    }
}