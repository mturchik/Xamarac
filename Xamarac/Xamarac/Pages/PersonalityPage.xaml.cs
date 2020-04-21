using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarac.Services;
using Xamarac.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarac.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalityPage : ContentPage
    {
        public PersonalityPage() => InitializeComponent();

        private void Submit_Quiz(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text))
            {
                QuizError.Text = "You gotta have a name.";
                return;
            }

            if (!int.TryParse(AgeEntry.Text, out var age))
            {
                QuizError.Text = "Everyone has an age, except people who aint got no age.";
                return;
            }

            QuizError.Text = string.Empty;
            SpongebobQuizViewModel.Name = NameEntry.Text;
            SpongebobQuizViewModel.Age = age;


            var grade = SpongebobQuizViewModel.GradeQuiz();

            QuizResults.Text = $"{NameEntry.Text} is exactly like: {grade}. " +
                               $"Congratulations, very impressive for a {AgeEntry.Text} year old.";
            QuizResults.IsVisible = true;
            ResetButton.IsVisible = true;
            Image.Source = grade.GetImageUrl();
            Image.IsVisible = true;

            NameEntry.IsVisible = false;
            AgeEntry.IsVisible = false;
            QuizList.IsVisible = false;
            SubmitButton.IsVisible = false;
        }

        private void Reset_Quiz(object sender, EventArgs e)
        {
            var toReset = SpongebobQuizViewModel.QuizQuestions.ToList();
            foreach (var question in toReset)
            {
                question.Answer = false;

                var indexOfQuestion = SpongebobQuizViewModel.QuizQuestions.IndexOf(question);
                SpongebobQuizViewModel.QuizQuestions[indexOfQuestion] = question;
            }

            QuizResults.IsVisible = false;
            ResetButton.IsVisible = false;
            Image.IsVisible = false;

            NameEntry.IsVisible = true;
            AgeEntry.IsVisible = true;
            QuizList.IsVisible = true;
            SubmitButton.IsVisible = true;
        }
    }
}