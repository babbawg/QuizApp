using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace QuizApp.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(50)]
        public string Name { get; set; }

        public string City { get; set; }

        [Unique]
        public string Email { get; set; }

        public string PhoneNr { get; set; }

        public byte[] Image { get; set; }

        [NotNull]
        public DateTime DteCreated { get; set; }
    }
}
