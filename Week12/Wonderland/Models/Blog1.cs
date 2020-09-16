using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;

namespace Wonderland.Models
{
    [Table("Blog1")]
    public class Blog1
    {
        [Key]
        public long id { get; set; }
        public string paragraphs { get; set; }
        public string title { get; set; }

        // Read
        public static List<Blog1> Read()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            List<Blog1> blogs = db.GetAll<Blog1>().ToList();
            return blogs;
        }

        public static List<Blog1> Read(string search)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            List<Blog1> blogs = db.Query<Blog1>($"select id, title from Blog1 where paragraphs like '%{search}%'").AsList();
            return blogs;
        }

        public static Blog1 Read(long _id)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            Blog1 blog = db.Get<Blog1>(_id);
            return blog;
        }

        public static void Create(string _title, string _paragraphs)
        {
            Blog1 blog = new Blog1() { title = _title, paragraphs = _paragraphs };
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            db.Insert(blog);
        }

        public static void Update(long _id, string _title, string _paragraphs)
        {
            Blog1 blog = new Blog1() { id = _id, title = _title, paragraphs = _paragraphs };
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            db.Update(blog);

        }

        public static long TestProc()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=devbuild1;user id=sa;password=abc123;");
            int result = db.QuerySingle<int>("AddBlog", new { paragraphs = "test", title = "test2" }, commandType:CommandType.StoredProcedure);
            return result;
        }

    }
}

