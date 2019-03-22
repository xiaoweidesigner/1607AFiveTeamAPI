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
        public List<DepartMent> ShowDepartMent()
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
        [HttpGet]
        public Employee ShowEmployeeId(int Id)
        {
            return EmployeeBLL.CreateEmployeeBLL().ShowById(Id);
        }
        [HttpPost]
        public int UpdEmployee(Employee de)
        {
            return EmployeeBLL.CreateEmployeeBLL().Upd(de);
        }
        /// <summary>
        /// 显示评论信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Comment> ShowComments()
        {
            return CommentBLL.CreateCommentBll().Show();
        }
        /// <summary>
        /// 删除评论信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public int DelComments(int Id)
        {
            return CommentBLL.CreateCommentBll().Del(Id);
        }

        //员工/管理员登录
        [HttpGet]
        public Employee Login(string E_Account, string E_Pwd)
        {
            return EmployeeBLL.CreateEmployeeBLL().Login(E_Account, E_Pwd);
        }
        /// <summary>
        /// 显示金额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Finance> ShowFinances()
        {
            return FinanceBLL.CreateFinanceBLL().ShowFinance();
        }
        public IEnumerable<dynamic> GetBanner()
        {
            return new List<dynamic>
            {
                new { lunbo_pic = "http://localhost:5646/Images/a.JPG" },
                new { lunbo_pic = "http://localhost:5646/Images/b.JPG" },
                new { lunbo_pic = "http://localhost:5646/Images/c.JPG" }
            };
        }
    }
}
