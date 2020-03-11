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
            var grade = SpongebobQuizViewModel.GradeQuiz();

            QuizResults.Text = $"{NameEntry.Text} is exactly like: {grade}. Congratulations, very impressive for a {AgeEntry.Text} year old.";
            QuizResults.IsVisible = true;
            ResetButton.IsVisible = true;

            NameEntry.IsVisible = false;
            AgeEntry.IsVisible = false;
            QuizList.IsVisible = false;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;
            InputGrid.IsVisible = false;
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

            QuizResults.Text = string.Empty;
            QuizResults.IsVisible = false;
            ResetButton.IsVisible = false;
            
            NameEntry.IsVisible = true;
            AgeEntry.IsVisible = true;
            QuizList.IsVisible = true;
            SubmitButton.IsVisible = true;
        }

        private void QuizList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) e.Item;

            if (activeQuestion is null) return;
            QuestionLabel.Text = activeQuestion.Question;
            AnswerLabel.Text = activeQuestion.Answer.ToString();

            QuestionLabel.IsVisible = true;
            AnswerLabel.IsVisible = true;
            InputGrid.IsVisible = true;
        }

        private void SNeg_Clicked(object sender, EventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (activeQuestion is null) return;
            activeQuestion.Answer = SurveyResponse.StrongNegative;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;

            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            InputGrid.IsVisible = false;
        }

        private void Neg_Clicked(object sender, EventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (activeQuestion is null) return;
            activeQuestion.Answer = SurveyResponse.Negative;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;

            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            InputGrid.IsVisible = false;
        }

        private void Neu_Clicked(object sender, EventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (activeQuestion is null) return;
            activeQuestion.Answer = SurveyResponse.Neutral;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;

            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            InputGrid.IsVisible = false;
        }

        private void Pos_Clicked(object sender, EventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (activeQuestion is null) return;
            activeQuestion.Answer = SurveyResponse.Positive;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;

            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            InputGrid.IsVisible = false;
        }

        private void SPos_Clicked(object sender, EventArgs e)
        {
            var activeQuestion = (SpongebobQuizViewModel) QuizList.SelectedItem;

            if (activeQuestion is null) return;
            activeQuestion.Answer = SurveyResponse.StrongPositive;
            QuestionLabel.IsVisible = false;
            AnswerLabel.IsVisible = false;

            var indexOfActive = SpongebobQuizViewModel.QuizQuestions.IndexOf(activeQuestion);
            SpongebobQuizViewModel.QuizQuestions[indexOfActive] = activeQuestion;
            InputGrid.IsVisible = false;
        }
    }
}