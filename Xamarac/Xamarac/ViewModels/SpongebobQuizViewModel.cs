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
        }

        public string Question { get; }
        public SpongebobCharacter PositiveCharacter { get; set; }
        public SpongebobCharacter NegativeCharacter { get; set; }
        public bool Answer { get; set; }

        static SpongebobQuizViewModel() =>
            QuizQuestions = new ObservableCollection<SpongebobQuizViewModel>
            {
                new SpongebobQuizViewModel("I love catching jellyfish",
                    SpongebobCharacter.Spongebob, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel("I don't need water",
                    SpongebobCharacter.Spongebob, SpongebobCharacter.Patrick),
                new SpongebobQuizViewModel("People are only good when they're giving me money",
                    SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("Sponge is my best friend",
                    SpongebobCharacter.Patrick, SpongebobCharacter.MrCrabs),
                new SpongebobQuizViewModel("Friends are overrated, I'm my own best friend",
                    SpongebobCharacter.Squidward, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("I'm the real dirty dan",
                    SpongebobCharacter.Patrick, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel("Is this the Krusty Krab?",
                    SpongebobCharacter.Patrick, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel("CHOCOLATE!?!?!?",
                    SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("What is the secret formula?",
                    SpongebobCharacter.MrCrabs, SpongebobCharacter.Spongebob),
                new SpongebobQuizViewModel("Do you enjoy free balloon day?",
                    SpongebobCharacter.Spongebob, SpongebobCharacter.Squidward),
                new SpongebobQuizViewModel("Do you play the clarinet?",
                    SpongebobCharacter.Squidward, SpongebobCharacter.Patrick),
                new SpongebobQuizViewModel("Is mayonaise an instrument?",
                    SpongebobCharacter.Patrick, SpongebobCharacter.Squidward)
            };

        public static ObservableCollection<SpongebobQuizViewModel> QuizQuestions { get; set; }

        public static string Name { get; set; }
        public static int Age { get; set; }

        public static SpongebobCharacter GradeQuiz()
        {
            var list = new List<int> {0, 0, 0, 0};
            foreach (var question in QuizQuestions)
            {
                if (question.Answer)
                    list[(int) question.PositiveCharacter] += 1;
                else
                    list[(int) question.NegativeCharacter] += 1;
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
                case 0: return SpongebobCharacter.Spongebob;
                case 1: return SpongebobCharacter.Patrick;
                case 2: return SpongebobCharacter.Squidward;
                case 3: return SpongebobCharacter.MrCrabs;
                default: return SpongebobCharacter.Spongebob;
            }
        }
    }
}