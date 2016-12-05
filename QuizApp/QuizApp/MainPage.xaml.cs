using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.QuizRepo.AddNewQuizAsync(newQuiz.Text, "des...", "Mia domanda", "44", DateTime.Now, DateTime.Now.AddDays(7));
            statusMessage.Text = App.QuizRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Model.Quiz> qList = await App.QuizRepo.GetAllQuizAsync();

            ObservableCollection<Model.Quiz> pplCollection = new ObservableCollection<Model.Quiz>(qList);
            quizList.ItemsSource = pplCollection;
        }

    }
}
