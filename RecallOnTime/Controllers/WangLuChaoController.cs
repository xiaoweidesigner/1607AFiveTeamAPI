using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using StackExchange.Redis;
using RecallOnTime.Models;

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
        public RedisValue[] ShowDepartMent()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetDepartMent"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<DepartMent> list = DepartMentBLL.CreateDepartMentBLL().Show(); ;//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].DId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetDepartMent", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetDepartMent", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetDepartMent");
            return redis;
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
        /// 显示员工   登陆
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowEmployee()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetEmployee"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<Employee> list = EmployeeBLL.CreateEmployeeBLL().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].EId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetEmployee", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetEmployee", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetEmployee");
            return redis;
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
        public RedisValue[] ShowComments()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetComments"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<Comment> list = CommentBLL.CreateCommentBll().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].CoId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetComments", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetComments", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetComments");
            return redis;
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
        /// <summary>
        /// 显示金额
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowFinances()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetFinance"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<Finance> list = FinanceBLL.CreateFinanceBLL().ShowFinance();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].FId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetFinance", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetFinance", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetComments");
            return redis;
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
