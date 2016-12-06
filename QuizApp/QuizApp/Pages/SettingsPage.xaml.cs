using System;
using System.Collections.Generic;
using QuizApp.Helpers;
using Xamarin.Forms;

namespace QuizApp
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();
		}

		public async void OnSaveClicked(object sender, System.EventArgs e)
		{
			Settings.AdminUserName = txtUserName.Text.Trim().ToLower();
			Settings.AdminUserPwd = txtPwd.Text.Trim().ToLower();

			App.Current.OpenQuiz();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			txtUserName.Text = Settings.AdminUserName;
			txtPwd.Text = Settings.AdminUserPwd;
		}	
	}
}
