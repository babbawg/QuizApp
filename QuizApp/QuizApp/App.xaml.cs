using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class App : Application
    {
        public static QuizRepository QuizRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new QuizApp.MainPage();
        }

        public App(string dbPath, ISQLitePlatform sqlitePlatform)
        {
            //set database path first, then retrieve main page
            QuizRepo = new QuizRepository(sqlitePlatform, dbPath);

            this.MainPage = new MainPage();
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
