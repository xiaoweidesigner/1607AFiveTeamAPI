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
        private static EmployeeDAL dal = null;
        public static EmployeeDAL DepartMent()
        {
            if (dal == null)
            {
                dal = new EmployeeDAL();
            }
            return DepartMent();
        }

        public int Add(Employee t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Employee.Add(t);
                return my.SaveChanges();
            }
        }

        public int Del(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                Employee p = my.Employee.Find(Id);
                my.Employee.Remove(p);
                return my.SaveChanges();
            }
        }

        public List<Employee> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.Employee.ToList();
            }
        }

        public Employee ShowById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Upd(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
