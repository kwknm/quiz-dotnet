using System.Text.Json.Serialization;

namespace Quiz.Models
{
    public class QuestionModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
        [JsonPropertyName("answerOptions")]
        public string[] AnswerOptions { get; set; } = default!;
        [JsonPropertyName("correctAnswerIndex")]
        public int CorrectAnswerIndex { get; set; }
    }
}
