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
            if (string.IsNullOrEmpty(NameEntry.Text)) return;
            SpongebobQuizViewModel.Name = NameEntry.Text;

            if (int.TryParse(AgeEntry.Text, out var age))
                SpongebobQuizViewModel.Age = age;
            else return;
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
            AnswerLabel.IsVisible = false;
            SubmitButton.IsVisible = false;
        }

        private void Reset_Quiz(object sender, EventArgs e)
        {
            var toReset = SpongebobQuizViewModel.QuizQuestions.ToList();
            foreach (var question in toReset)
            {
                question.Answer = SurveyResponse.Neutral;

                var indexOfQuestion = SpongebobQuizViewModel.QuizQuestions.IndexOf(question);
                SpongebobQuizViewModel.QuizQuestions[indexOfQuestion] = question;
            }

            QuizResults.IsVisible = false;
            ResetButton.IsVisible = false;
            Image.IsVisible = false;

            NameEntry.IsVisible = true;
            AgeEntry.IsVisible = true;
            QuizList.IsVisible = true;
            AnswerLabel.IsVisible = true;
            SubmitButton.IsVisible = true;
        }
        
        private void ItemSwiped(object sender, SwipedEventArgs e)
        {
            if (QuizList.SelectedItem is null) return;
            
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (e.Direction is SwipeDirection.Left)
                activeQuestion.Answer = activeQuestion.Answer.DecreaseResponse();
            else if (e.Direction is SwipeDirection.Right)
                activeQuestion.Answer = activeQuestion.Answer.IncreaseResponse();

            
            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            AnswerLabel.Text = activeQuestion.Answer.ToString();
        }

        private void QuizList_OnItemSelected(object sender, SelectedItemChangedEventArgs e) =>
            AnswerLabel.Text = ((SpongebobQuizViewModel) QuizList.SelectedItem).Answer.ToString();
    }
}