using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using QuizApp.Helpers;

namespace QuizApp
{
    public partial class App : Application
    {
        public static QuizRepository QuizRepo { get; private set; }
		public static App Current;

        public App()
        {
            InitializeComponent();
			Current = this;
        }

        public App(string dbPath, ISQLitePlatform sqlitePlatform)
        {
			Current = this;

            //set database path first, then retrieve main page
            QuizRepo = new QuizRepository(sqlitePlatform, dbPath);

			//this.MainPage = new MainPage();

			if (Settings.IsFirstStart)
				MainPage = new SettingsPage();
			else
				this.OpenQuiz();

        }

		public void OpenQuiz()
		{
			MainPage = new NavigationPage(new MainPage());
		}

		public void OpenAdminPage()
		{
			MainPage = new NavigationPage(new AdminPage());
		}



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
