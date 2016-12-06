using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp
{
	public partial class AdminPage : ContentPage
	{
		public AdminPage()
		{
			InitializeComponent();
		}

		public async void OnSettingsClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}

		public async void OnQuizListClicked(object sender, System.EventArgs e)
		{
			await  Navigation.PushAsync(new AdminQuizList());
		}

		public async void OnLogoutClicked(object sender, System.EventArgs e)
		{
			App.Current.OpenQuiz();
		}


	}
}
