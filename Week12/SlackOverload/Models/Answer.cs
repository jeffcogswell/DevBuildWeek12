using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace SlackOverload.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public long ID {get; set;}
        public string Username {get; set;}
        public string Detail {get; set;}
        public long QuestionID {get; set;}
        public DateTime Posted {get; set;}
        public long Upvotes {get; set;}

        // Read invididual answer
        public static Answer Get(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            return db.Get<Answer>(_id);
        }

        // Read all answers for specific question
        public static List<Answer> GetForQuestion(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            return db.Query<Answer>("select * from Answer where QuestionID = @id", new { id = _id }).ToList();
        }

        // Add answer
        public static Answer Add(Answer _answer)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            long id = db.Insert(_answer);
            _answer.ID = id;
            return _answer;
        }

        // Update answer
        public static void Update(Answer _answer)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            db.Update(_answer);
        }

        // Delete answer
        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            db.Delete(new Answer() { ID = _id });
        }
    }

}
