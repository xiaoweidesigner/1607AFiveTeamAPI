using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;

namespace DAL
{
    //评论表DAL
    public class CommentDAL : ICommon<Comment>
    {
        #region 单例
        private static CommentDAL dal = null;
        private CommentDAL()
        {
        }
        public static CommentDAL CreateCommentDal()
        {
            if (dal == null)
            {
                dal = new CommentDAL();
            }
            return dal;
        }
        #endregion
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Comment t)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Comment.Add(t);
                return db.SaveChanges();
            }
        }
        //删除某条信息
        public int Del(int Id)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Comment.Remove(db.Comment.Where(s => s.CoId == Id).FirstOrDefault());
                return db.SaveChanges();
            }
        }
        //评论列表信息显示
        public List<Comment> Show()
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Comment.Include("Custom").ToList();
            }
        }
        //显示某条评论信息
        public Comment ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Comment.Include("Custom").Where(s => s.CoId == Id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改评论信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Comment t)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Comment>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
