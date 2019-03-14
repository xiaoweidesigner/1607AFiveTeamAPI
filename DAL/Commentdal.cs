using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataService;

namespace DAL
{
    public class Commentdal : ICommon<Comment>
    {
        private static Commentdal dal = null;
        private Commentdal()
        {
        }

        public static Commentdal CreateCommentDal()
        {
            if (dal == null)
            {
                dal = new Commentdal();
            }
            return dal;
        }

        public int Add(Comment t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Comment.Add(t);
                return db.SaveChanges();
            }
        }

        public int Del(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Comment.Remove(db.Comment.Where(s => s.CoId == Id).FirstOrDefault());
                return db.SaveChanges();
            }
        }

        public List<Comment> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Comment.ToList();
            }
        }

        public Comment ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Comment.Where(s => s.CoId == Id).FirstOrDefault();
            }
        }

        public int Upd(Comment t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Comment>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
