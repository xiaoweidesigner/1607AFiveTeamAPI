using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;
using Newtonsoft.Json;
using StackExchange.Redis;

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
        public List<Custom> ShowCustom()
        {
            return CustomBLL.CreateCustomBll().Show();
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
        public List<MovieHall> SH()
        {
            return MovieHallBLL.CreateMovieHallBLL().SH();
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
        

    }
}
