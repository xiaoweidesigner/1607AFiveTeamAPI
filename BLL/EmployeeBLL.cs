﻿using DAL;
using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL:ICommon<Employee>
    {
        private static EmployeeBLL bll = null;
        private EmployeeBLL()
        {
        }
        public static EmployeeBLL CreateEmployeeBLL()
        {
            if (bll == null)
            {
                bll = new EmployeeBLL();
            }
            return bll;
        }
        public int Add(Employee t)
        {
            return EmployeeDAL.CreatEmployeeDAL().Add(t);
        }

        public int Del(int Id)
        {
            return EmployeeDAL.CreatEmployeeDAL().Del(Id);
        }

        public List<Employee> Show()
        {
            return EmployeeDAL.CreatEmployeeDAL().Show();
        }

        public Employee ShowById(int Id)
        {
            return EmployeeDAL.CreatEmployeeDAL().ShowById(Id);
        }

        public int Upd(Employee t)
        {
            return EmployeeDAL.CreatEmployeeDAL().Upd(t);
        }
        //登录
        public Employee Login(string E_Account, string E_Pwd)
        {
            return EmployeeDAL.CreatEmployeeDAL().Login(E_Account, E_Pwd);
        }
    }
}