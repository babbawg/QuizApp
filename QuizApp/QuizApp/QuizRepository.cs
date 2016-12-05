using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System.Threading.Tasks;
using QuizApp.Model;

namespace QuizApp
{
    public class QuizRepository
    { 
       private SQLiteAsyncConnection dbConn;

        public string StatusMessage { get; set; }

        public QuizRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock
                    (
                        sqlitePlatform,
                        new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
                    ));

                dbConn = new SQLiteAsyncConnection(connectionFunc);
                dbConn.CreateTableAsync<Quiz>();
                dbConn.CreateTableAsync<User>();
                dbConn.CreateTableAsync<Answer>();
            }
        }


        public async Task AddNewQuizAsync(string name, string description, string question, string answer, DateTime start, DateTime end)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                Quiz quiz = new Quiz();
                quiz.Name = name;
                quiz.Description = description;
                quiz.Question = question;
                quiz.Answer = answer;
                quiz.DteStart = start;
                quiz.DteEnd = end;

                result = await dbConn.InsertAsync(quiz);

                StatusMessage = string.Format("{0} record(s) added [Quiz: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<Quiz>> GetAllQuizAsync()
        {
            //return a list of people saved to the Person table in the database
            List<Quiz> quitzs = await dbConn.Table<Quiz>().ToListAsync();
            return quitzs;
        }


        public async Task AddNewUserAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                //insert a new person into the Person table
                result = await dbConn.InsertAsync(new User { Name = name, DteCreated=DateTime.Now });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<User>> GetAllUserAsync()
        {
            //return a list of people saved to the Person table in the database
            List<User> users = await dbConn.Table<User>().ToListAsync();
            return users;
        }
    }
}