﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;
using StackExchange.Redis;
using RecallOnTime.Models;
using Newtonsoft.Json;

namespace RecallOnTime.Controllers
{
    public class XjwController : ApiController
    {
        #region 顾客的CRUD 充值操作  加入会员操作   
        [HttpPost]
        public int AddCustom(Custom custom)
        {
            return CustomBLL.CreateCustomBll().Add(custom);
        }
        [HttpGet]
        public RedisValue[] ShowCustom()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetCustom"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<Custom> list = CustomBLL.CreateCustomBll().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for(int i=0;i<list.Count;i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].CId);
                    SortedSetEntry sse = new SortedSetEntry(value,did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetCustom", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetCustom", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis=db.SortedSetRangeByRank("GetCustom");
            return redis;
        }
        [HttpGet]
        public Custom ShowByIdCustom(int Id)
        {
            return CustomBLL.CreateCustomBll().ShowById(Id);
        }
        [HttpPost]
        public int DelCustom(int Id)
        {
            return CustomBLL.CreateCustomBll().Del(Id);
        }
        [HttpPost]
        public int UpdCustom(Custom custom)
        {
            return CustomBLL.CreateCustomBll().Upd(custom);
        }
        [HttpPost]
        public int UpdCustomName(Custom c)
        {
            int CId = c.CId;
            string C_Name = c.C_Name;
            return CustomBLL.CreateCustomBll().UpdCustomName(CId,C_Name);
        }
        //充值
        [HttpGet]
        public int CZ(float C_integral, int CId)
        {
            return CustomBLL.CreateCustomBll().CZ(C_integral, CId);
        }


        [HttpGet]
        //加入会员   将状态改为1,将个人资料完善   普通游客添加时名称一律使用游客  以手机号进行标识
        public int Join(int CId,string C_Name,string Img)
        {
            return CustomBLL.CreateCustomBll().JoinHY(CId,C_Name,Img);
        }
        #endregion

        #region 卫生部的人看到的该打扫的放映厅
        /// <summary>
        /// 打扫卫生能看到的该打扫的影厅信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] SH()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetMovieHallsDaSao"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<MovieHall> list = MovieHallBLL.CreateMovieHallBLL().SH();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].HId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetMovieHallsDaSao", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetMovieHallsDaSao", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetMovieHallsDaSao");
            return redis;
        }
        /// <summary>
        /// 改变员工当前状态为工作中  放映厅为打扫中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int UpdEmployeeStatus(int EId, int HId)
        {
            int Code;
            return EmployeeBLL.CreateEmployeeBLL().UpdEmployeeStatus(EId, HId, out Code);
        }
        /// <summary>
        /// 改变员工当前状态为空闲中  改变放映厅当前状态为空闲中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int UpdEmployeeStatus2(int EId, int HId)
        {
            int Code;
            return EmployeeBLL.CreateEmployeeBLL().UpdEmployeeStatus2(EId, HId, out Code);
        }
     
        #endregion

        #region 评论的CRUD 及操作
        [HttpPost]
        public int AddComment(Comment comment)
        {
            comment.C_Time = DateTime.Now;
            return CommentBLL.CreateCommentBll().Add(comment);
        }
        [HttpGet]
        public RedisValue[] ShowComment()
        {
            var conn = ConnectionMultiplexerManager.GetRedisConn();
            var db = conn.GetDatabase();
            if (!db.KeyExists("GetComment"))
            {
                List<Comment> list = CommentBLL.CreateCommentBll().Show();
                SortedSetEntry[] entries = new SortedSetEntry[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    DateTime time = Convert.ToDateTime(list[i].C_Time);
                    TimeSpan tstime = time - new DateTime(1970, 1, 1);
                    SortedSetEntry sorted = new SortedSetEntry(value, tstime.TotalMilliseconds);
                    entries[i] = sorted;
                }
                db.SortedSetAdd("GetComment", entries);
                db.KeyExpire("GetComment", DateTime.Now.AddMinutes(3));
            }
             RedisValue[] ff = db.SortedSetRangeByRank("GetComment");
             return ff;
        }
        [HttpGet]
        public Comment ShowByIdComment(int Id)
        {
            return CommentBLL.CreateCommentBll().ShowById(Id);
        }
        [HttpPost]
        public int DelComment(int Id)
        {
            return CommentBLL.CreateCommentBll().Del(Id);
        }
        [HttpPost]
        public int UpdComment(Comment comment)
        {
            
            return CommentBLL.CreateCommentBll().Upd(comment);
        }
        #endregion

        SeatBLL bll = new SeatBLL();
        //找到该场次放映厅的所有座位
        [HttpGet]
        public List<Seat> ShowSeat(int HId)
        {
            List<Seat> list = bll.Show();
            list = list.Where(s => s.MovieHallId == HId).ToList();
            return list;
        }
        #region 微信端
        [HttpGet]
        public List<Comment> ShowMovieId(int Id)
        {
            List<Comment> list = ShowComment();
            list = list.Where(s => s.MovieId == Id).ToList();
            return list;
        }
        [HttpPost]
        public int AddCustomWX(Custom c)
        {
            c.C_EndTime = 0;
            c.C_integral = 0;
            c.C_Name = "游客";
            c.C_State = 2;//默认为游客
            int result = CustomBLL.CreateCustomBll().Add(c);
            return result;
        }
        #endregion

    }
}
