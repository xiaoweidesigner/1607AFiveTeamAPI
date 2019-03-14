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
    public class EmployeeBLL
    {
        private static ICommon<Employee> bll;
        public EmployeeBLL()
        {
            if (bll == null)
            {
                bll = new EmployeeBLL() as ICommon<Employee>;
            }
        }
        public int Add(Employee t)
        {
            return bll.Add(t);
        }

        public int Del(int Id)
        {
            return bll.Del(Id);
        }

        public List<Employee> Show()
        {
            return bll.Show();
        }

        public Employee ShowById(int Id)
        {
            return bll.ShowById(Id);
        }

        public int Upd(Employee t)
        {
            return bll.Upd(t);
        }
    }
}
