using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace QuizApp.Model
{
    [Table("Answer")]
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int IdQuiz { get; set; }

        [NotNull]
        public int IdUser { get; set; }

        [NotNull]
        public string Text { get; set; }

        [NotNull]
        public bool IsValid { get; set; }

        [NotNull]
        public DateTime Dte { get; set; }

    }
}
