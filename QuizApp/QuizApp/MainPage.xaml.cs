using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Helpers;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		public async void OnAdminClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new AdminLoginPage(), true);
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			QuizApp.Model.Quiz quiz = await App.QuizRepo.GetCurrentQuizAsync();
			if (quiz != null)
			{
				lblQuizDate.Text = quiz.DteEnd.ToString();
				lblQuizTitle.Text = quiz.Name;
				lblQuizDescription.Text = quiz.Description;
			}
		}

        //public async void OnNewButtonClicked(object sender, EventArgs args)
        //{
        //    statusMessage.Text = "";

        //    await App.QuizRepo.AddNewQuizAsync(newQuiz.Text, "des...", "Mia domanda", "44", DateTime.Now, DateTime.Now.AddDays(7));
        //    statusMessage.Text = App.QuizRepo.StatusMessage;
        //}

        //public async void OnGetButtonClicked(object sender, EventArgs args)
        //{
        //    statusMessage.Text = "";

        //    List<Model.Quiz> qList = await App.QuizRepo.GetAllQuizAsync();

        //    ObservableCollection<Model.Quiz> pplCollection = new ObservableCollection<Model.Quiz>(qList);
        //    quizList.ItemsSource = pplCollection;
        //}

    }
}
