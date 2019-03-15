﻿using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecallOnTime.Controllers
{
    public class WangLuChaoController : ApiController
    {
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddDepartMent(DepartMent de)
        {
            return DepartMentBLL.CreateDepartMentBLL().Add(de);
        }
        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DepartMent> ShowCustom()
        {
            return DepartMentBLL.CreateDepartMentBLL().Show();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddEmployee(Employee de)
        {
            return EmployeeBLL.CreateEmployeeBLL().Add(de);
        }
        /// <summary>
        /// 显示员工
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employee> ShowEmployee()
        {
            return EmployeeBLL.CreateEmployeeBLL().Show();
        }
    }
}
