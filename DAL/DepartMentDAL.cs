using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class DepartMentDAL : ICommon<DepartMent>
    {
        private static DepartMentDAL dal = null;
        public DepartMentDAL()
        {
          
        }
        public static DepartMentDAL CreatDepartMentDal()
        {
            if (dal == null)
            {
                dal = new DepartMentDAL();
            }
            return dal;
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(DepartMent t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.DepartMent.Add(t);
                return my.SaveChanges();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                DepartMent p = my.DepartMent.Find(Id);
                my.DepartMent.Remove(p);
                return my.SaveChanges();
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<DepartMent> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.DepartMent.ToList();
            }
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DepartMent ShowById(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.DepartMent.Find(Id);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(DepartMent t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return my.SaveChanges();
            }
        }
    }
}
