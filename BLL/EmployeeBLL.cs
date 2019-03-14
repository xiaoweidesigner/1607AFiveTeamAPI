using DAL;
using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL : ICommon<Employee>
    {
        private static EmployeeBLL dal = null;
        public static EmployeeBLL DepartMent()
        {
            if (dal == null)
            {
                dal = new EmployeeBLL();
            }
            return DepartMent();
        }
        public int Add(Employee t)
        {
            return dal.Add(t);
        }

        public int Del(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Show()
        {
            throw new NotImplementedException();
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
