using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAssistantApp.Models
{
    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string questionText, List<string> options, int correctIndex, string explanation)
        {
            QuestionText = questionText;
            Options = options;
            CorrectIndex = correctIndex;
            Explanation = explanation;
        }
    }
}
