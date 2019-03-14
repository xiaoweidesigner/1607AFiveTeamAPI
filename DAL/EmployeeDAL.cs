using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL : ICommon<Employee>
    {
        #region 单例
        private static EmployeeDAL dal = null;
        private EmployeeDAL()
        {
            if (dal == null)
            {
                dal = new EmployeeDAL();
            }
        }
        #endregion
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Employee t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Employee.Add(t);
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
                Employee p = my.Employee.Find(Id);
                my.Employee.Remove(p);
                return my.SaveChanges();
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Employee> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.Employee.Include("Employee").ToList();
            }
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Employee ShowById(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.Employee.Include("Employee").Where(s => s.EId == Id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Employee t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return my.SaveChanges();
            }
        }
    }
}
