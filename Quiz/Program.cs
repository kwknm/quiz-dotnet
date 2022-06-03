using Quiz;
using Quiz.Models;
using Quiz.Utils;
using Quiz.Core;

var pathToJsonFile = Path.Combine(Directory.GetCurrentDirectory(), Constants.JsonFileName);

if (!File.Exists(pathToJsonFile))
{
    Console.WriteLine($"File '{Constants.JsonFileName}' not found.");
    Console.ReadKey();
    return;
}

var root = JsonUtils.DeserializeFromJsonFile<RootModel>(pathToJsonFile);

if (root is null)
{
    Console.WriteLine($"Some error occured in '{Constants.JsonFileName}'.");
    Console.ReadKey();
    return;
}

var questions = root.Questions;
var title = root.Title;

if (questions.Count == 0)
{
    Console.WriteLine("You have got 0 questions.");
    Console.ReadKey();
    return;
}

QuizCore.Initialize(questions, title);