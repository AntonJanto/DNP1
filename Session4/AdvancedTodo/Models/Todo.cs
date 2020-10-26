using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdvancedTodo.Models
{
    public class Todo
    {
        [JsonPropertyName("userId")]
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Please enter a value bigger than {1}")]
        public int UserID { get; set; }
        
        [JsonPropertyName("id")]
        public int TodoID { get; set; }

        [JsonPropertyName("title")]
        [Required, MaxLength(128)]
        public string Title { get; set; }

        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }
    }
}
