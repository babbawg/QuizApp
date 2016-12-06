using System;
using System.Collections.Generic;
using QuizApp.Helpers;
using Xamarin.Forms;

namespace QuizApp
{
	public partial class AdminLoginPage : ContentPage
	{
		public AdminLoginPage()
		{
			InitializeComponent();
		}

		public async void OnCancelClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		public async void OnLoginClicked(object sender, System.EventArgs e)
		{
			if (txtUserName.Text.ToLower() == Settings.AdminUserName &&
				txtPwd.Text.ToLower() == Settings.AdminUserPwd)
			{
				await Navigation.PopModalAsync(true);
				App.Current.OpenAdminPage();
			}
			else {
				lblMessage.TextColor = Color.Red;
				lblMessage.Text = "Login invalido!";
			}
		}

		protected void OnUserNameTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			this.EnableLoginButton();
		}

		protected void OnPwdTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			this.EnableLoginButton();
		}

		private void EnableLoginButton() {
			btnLogin.IsEnabled = (!string.IsNullOrEmpty(txtUserName.Text) 
			                      && !string.IsNullOrEmpty(txtPwd.Text));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			txtUserName.Focus();
			btnLogin.IsEnabled = false;
		}

	}
}
