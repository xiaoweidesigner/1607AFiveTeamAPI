using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeDAL : ICommon<Employee>
    {
        #region 单例
        private static EmployeeDAL dal = null;
        public EmployeeDAL()
        {

        }
        public static EmployeeDAL CreatEmployeeDAL()
        {
            if (dal == null)
            {
                dal = new EmployeeDAL();
            }
            return dal;
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
                return my.Employee.Include("DepartMent").ToList();
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
                return my.Employee.Include("DepartMent").Where(s => s.EId == Id).FirstOrDefault();
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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="E_Account"></param>
        /// <param name="E_Pwd"></param>
        /// <returns></returns>
        public Employee Login(string E_Account, string E_Pwd)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                Employee e= db.Database.SqlQuery<Employee>($"select * from Employees where E_Account='{E_Account}' and E_Pwd='{E_Pwd}'").FirstOrDefault();
                return e;
            }
        }
        /// <summary>
        /// 改变员工当前状态为工作中  改变放映厅当前状态为打扫中
        /// </summary>
        /// <returns></returns>
        public int UpdEmployeeStatus(int EId,int HId,out int Code)
        {
            using (MyDbContext db=new MyDbContext())
            {
                SqlParameter PEId = new SqlParameter("@EId", SqlDbType.Int);
                PEId.Value = EId;
                SqlParameter PHId = new SqlParameter("@HId", SqlDbType.Int);
                PHId.Value = HId;
                SqlParameter PCode = new SqlParameter("@Code", SqlDbType.Int);
                PCode.Direction = ParameterDirection.Output;
                SqlParameter[] para = new SqlParameter[] { PEId, PHId, PCode };
                string sql = $"exec dbo.p_ChangeEMStatusAndMHStatus2 @EId,@HId,@Code output";
                db.Database.ExecuteSqlCommand(sql, para);
                Code = Convert.ToInt32(PCode.Value);
                return Code;
            }
        }
        /// <summary>
        /// 改变员工当前状态为空闲中  改变放映厅当前状态为空闲中
        /// </summary>
        /// <returns></returns>
        public int UpdEmployeeStatus2(int EId, int HId, out int Code)
        {
            using (MyDbContext db = new MyDbContext())
            {
                SqlParameter PEId = new SqlParameter("@EId", SqlDbType.Int);
                PEId.Value = EId;
                SqlParameter PHId = new SqlParameter("@HId", SqlDbType.Int);
                PHId.Value = HId;
                SqlParameter PCode = new SqlParameter("@Code", SqlDbType.Int);
                PCode.Direction = ParameterDirection.Output;
                SqlParameter[] para = new SqlParameter[] { PEId, PHId, PCode };
                string sql = $"exec dbo.p_ChangeEMStatusAndMHStatus1 @EId,@HId,@Code output";
                db.Database.ExecuteSqlCommand(sql, para);
                Code = Convert.ToInt32(PCode.Value);
                return Code;
            }
        }
    }
}
