using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    [Table("Quiz")]
    public class Quiz
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        [NotNull]
        public string Question { get; set; }

        [NotNull]
        public string Answer { get; set; }

        [NotNull]
        public DateTime DteStart { get; set; }

        [NotNull]
        public DateTime DteEnd { get; set; }

    }
}
