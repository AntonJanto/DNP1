using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEF.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int TotalPages { get; set; }
        public DateTime PublishDate { get; set; }

        public Genre Genre { get; set; }
        public Author Author { get; set; }
    }
}
