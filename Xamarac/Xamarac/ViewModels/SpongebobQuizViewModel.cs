using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarac.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xamarac.ViewModels
{
    public class SpongebobQuizViewModel
    {
        public SpongebobQuizViewModel(int id, string question, SpongebobCharacter pChar, SpongebobCharacter nChar)
        {
            Id = $"Q{id}";
            Question = question;
            PositiveCharacter = pChar;
            NegativeCharacter = nChar;
            Answer = SurveyResponse.Neutral;
        }

        public string Id { get; }
        public string Question { get; }
        public SpongebobCharacter PositiveCharacter { get; set; }
        public SpongebobCharacter NegativeCharacter { get; set; }
        public SurveyResponse Answer { get; set; }

        public Color AnswerColor =>
            Answer is SurveyResponse.StrongNegative ? Color.DarkRed :
            Answer is SurveyResponse.Negative       ? Color.Red :
            Answer is SurveyResponse.Neutral        ? Color.Black :
            Answer is SurveyResponse.Positive       ? Color.DarkSeaGreen :
            Answer is SurveyResponse.StrongPositive ? Color.LawnGreen : Color.Black;

        static SpongebobQuizViewModel() =>
            QuizQuestions = new ObservableCollection<SpongebobQuizViewModel>
            {
                new SpongebobQuizViewModel(1, "I love catching jellyfish",
                                           SpongebobCharacter.Spongebob, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel(2, "I don't need water",
                                           SpongebobCharacter.Spongebob, SpongebobCharacter.Patrick),
                new SpongebobQuizViewModel(3, "People are only good when they're giving me money",
                                           SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel(4, "Spongebob is my best friend",
                                           SpongebobCharacter.Patrick, SpongebobCharacter.MrCrabs),
                new SpongebobQuizViewModel(5, "Friends are overrated, I'm my own best friend",
                                           SpongebobCharacter.Squidward, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel(6, "I'm the real dirty dan",
                                           SpongebobCharacter.Patrick, SpongebobCharacter.Squidward)
            };

        public static ObservableCollection<SpongebobQuizViewModel> QuizQuestions { get; set; }

        public static string Name { get; set; }
        public static int Age { get; set; }

        public static SpongebobCharacter GradeQuiz()
        {
            var list = new List<int> { 0, 0, 0, 0 };
            foreach (var question in QuizQuestions)
            {
                switch (question.Answer)
                {
                    case SurveyResponse.Neutral: continue;
                    case SurveyResponse.StrongNegative:
                        list[(int) question.NegativeCharacter] += 2;
                        list[(int) question.PositiveCharacter] -= 2;
                        break;
                    case SurveyResponse.Negative:
                        list[(int) question.NegativeCharacter] += 1;
                        list[(int) question.PositiveCharacter] -= 1;
                        break;
                    case SurveyResponse.Positive:
                        list[(int) question.NegativeCharacter] -= 1;
                        list[(int) question.PositiveCharacter] += 1;
                        break;
                    case SurveyResponse.StrongPositive:
                        list[(int) question.NegativeCharacter] -= 2;
                        list[(int) question.PositiveCharacter] += 2;
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            if (Name.Length < 3)
                list[0] += 4;
            else if (Name.Length < 6)
                list[1] += 4;
            else if (Name.Length < 9)
                list[2] += 4;
            else
                list[3] += 4;

            if (Age < 20)
                list[0] += 4;
            else if (Age < 30)
                list[1] += 4;
            else if (Age < 40)
                list[2] += 4;
            else
                list[3] += 4;

            switch (list.IndexOf(list.Max()))
            {
                case 0:  return SpongebobCharacter.Spongebob;
                case 1:  return SpongebobCharacter.Patrick;
                case 2:  return SpongebobCharacter.Squidward;
                case 3:  return SpongebobCharacter.MrCrabs;
                default: return SpongebobCharacter.Spongebob;
            }
        }
    }
}