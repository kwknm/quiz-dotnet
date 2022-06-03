using Quiz.Models;

namespace Quiz.Core
{
    public static class QuizCore
    {
        private static QuizState? _state;
        public static void Initialize(List<QuestionModel> questions, string title)
        {
            _state = new QuizState();

            Console.WriteLine($"Welcome to the quiz: {title}!");
            Console.WriteLine("Your task is to answer the questions correctly");
            Console.WriteLine(Environment.NewLine);

            while (questions.Count != _state.CurrectQuestionIndex)
            {
                var currentIndex = _state.CurrectQuestionIndex;
                var currentQuestion = questions[currentIndex];
                START:
                Console.WriteLine($"Question {currentIndex + 1}/{questions.Count}: {currentQuestion.Title}");
                Console.WriteLine("Choose the correct option:");
                for (int i = 0; i < currentQuestion.AnswerOptions.Length; i++)
                {
                    var option = currentQuestion.AnswerOptions[i];
                    Console.WriteLine($"- Option [{i + 1}]: {option}");
                }
                Console.Write("Your choice(number): ");
                var answer = int.TryParse(Console.ReadLine(), out int result);
                if (!answer)
                {
                    goto START;
                }

                if (currentQuestion.CorrectAnswerIndex == result - 1)
                {
                    DisplayIsolatedTextWithColor("Correct answer!", 
                        ConsoleColor.Green);
                    _state.CorrectAnswers++;
                }
                else
                {
                    DisplayIsolatedTextWithColor("Wrong answer!", 
                        ConsoleColor.Red);
                }

                _state.CurrectQuestionIndex++;
            }

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Results:");
            Console.WriteLine($"Correct answers: {_state.CorrectAnswers}/{questions.Count}");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void DisplayIsolatedTextWithColor(
            string text,
            ConsoleColor color)
        {
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.WriteLine(Environment.NewLine);
            Console.ResetColor();
        }
    }
}
