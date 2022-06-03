using Quiz.Models;
using Quiz;
using System.Xml.Serialization;
using System.Text.Json;

namespace Quiz.Utils
{
    public static class JsonUtils
    {
        public static T? DeserializeFromJsonFile<T>(string pathToFile)
            where T : class
        {
            var stream = File.ReadAllText(pathToFile);
            var questions = JsonSerializer.Deserialize<T>(stream);
            return questions;
        }
    }
}
