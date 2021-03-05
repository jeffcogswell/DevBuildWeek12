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
    [Table("Question")]
    public class Question
    {
        [Key]
        public long ID { get; set; }

        public string Username { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Posted { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public long  Status { get; set; }

        // Read invididual Question
        public static Question Get(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            return db.Get<Question>(_id);
        }

        // Read 10 most recent questions
        public static List<Question> Get()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            return db.Query<Question>("select top 10 * from Question").ToList();
        }

        // Read all Questions for specific user
        public static List<Question> GetForUser(string _username)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            return db.Query<Question>("select * from Question where Username = @username", new { username = _username }).ToList();
        }

        // Add Question
        public static Question Add(Question _question)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            long id = db.Insert(_question);
            _question.ID = id;
            return _question;
        }

        // Update Question
        public static void Update(Question _question)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            db.Update(_question);
        }

        // Delete Question
        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=SlackOverload;user id=sa;password=abc123;");
            db.Delete(new Question() { ID = _id });
        }
    }
}
