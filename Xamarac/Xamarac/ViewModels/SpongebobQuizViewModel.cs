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
        public SpongebobQuizViewModel(string question, SpongebobCharacter pChar, SpongebobCharacter nChar)
        {
            Question = question;
            PositiveCharacter = pChar;
            NegativeCharacter = nChar;
            Answer = SurveyResponse.Neutral;
        }

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
                new SpongebobQuizViewModel("Crabby Patties are delicious",
                                           SpongebobCharacter.Squidward, SpongebobCharacter.MrCrabs),
                new SpongebobQuizViewModel("I love catching jellyfish",
                                           SpongebobCharacter.Spongebob, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel("I don't need water",
                                           SpongebobCharacter.Spongebob, SpongebobCharacter.Patrick),
                new SpongebobQuizViewModel("People are only good when they're giving me money",
                                           SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("Every moment is the worst part of my day",
                                           SpongebobCharacter.Squidward, SpongebobCharacter.Patrick),
                new SpongebobQuizViewModel("Spongebob is my best friend",
                                           SpongebobCharacter.Patrick, SpongebobCharacter.MrCrabs),
                new SpongebobQuizViewModel("Money is my best friend",
                                           SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("Friends are overrated, I'm my own best friend",
                                           SpongebobCharacter.Squidward, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("I'm the real dirty dan",
                                           SpongebobCharacter.Patrick, SpongebobCharacter.Squidward)
            };

        public static ObservableCollection<SpongebobQuizViewModel> QuizQuestions { get; set; }

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