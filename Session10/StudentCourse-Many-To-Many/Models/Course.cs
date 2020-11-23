using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentCourse_Many_To_Many.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; init; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int ECTS { get; set; }
        public int Semester { get; set; }
        [JsonIgnore]
        public IList<Student> Students { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
