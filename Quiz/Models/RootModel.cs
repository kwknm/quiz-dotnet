using System.Text.Json.Serialization;

namespace Quiz.Models
{
    public class RootModel
    {
        [JsonPropertyName("questions")]
        public List<QuestionModel> Questions { get; set; } = default!;
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
    }
}
