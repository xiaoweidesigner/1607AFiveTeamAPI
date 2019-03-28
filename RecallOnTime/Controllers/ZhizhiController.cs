using BLL;
using MODEL;
using RecallOnTime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace RecallOnTime.Controllers
{
    public class ZhizhiController : ApiController
    {

        #region 活动
        ActivityBLL activityBLL = new ActivityBLL();
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddActivity(Activity t)
        {
            return activityBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelActivity(int Id)
        {
            return activityBLL.Del(Id);
        }
        /// <summary>
        /// 查询活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Activity> ShowActivity()
        {
            return activityBLL.Show();

        }
        /// <summary>
        /// 根据ID活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Activity ShowByIdActivity(int Id)
        {
            return activityBLL.ShowById(Id);

        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdActivity(Activity t)
        {
            return activityBLL.Upd(t);

        }
        #endregion

        #region 订单
        OrderBLL orderBLL = new OrderBLL();
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddOrder(MODEL.Order t)
        {
            return orderBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelOrder(int Id)
        {
            return orderBLL.Del(Id);

        }
       
        //修改订单状态 为已取消
        public int UpdOrderState(int OId)
        {
            return orderBLL.UpdOrderState(OId);
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowOrder()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetOrders"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<MODEL.Order> list = orderBLL.Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].OId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetOrders", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetOrders", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetOrders");
            return redis;
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdOrder(MODEL.Order t)
        {
            return orderBLL.Upd(t);

        }
        /// <summary>
        /// 显示订单及订单有关系的表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowAll()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetOMCH"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<OMCH> list = orderBLL.ShowAll();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].OId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetOMCH", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetOMCH", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetOMCH");
            return redis;
        }
        #endregion


        #region 座位
        SeatBLL seatBLL = new SeatBLL();
        /// <summary>
        /// 添加座位
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddSeat(Seat t)
        {
            return seatBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelSeat(int Id)
        {
            return seatBLL.Del(Id);

        }
        /// <summary>
        /// 查询座位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Seat> ShowSeat()
        {
            return seatBLL.Show();

        }
        /// <summary>
        /// 根据ID座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Seat ShowByIdSeat(int Id)
        {
            return seatBLL.ShowById(Id);

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdSeat(Seat t)
        {
            return seatBLL.Upd(t);

        }
        #endregion



        FinanceBLL financeBLL = FinanceBLL.CreateFinanceBLL();
        /// <summary>
        /// 根据年月日查询财务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable ShowCaiwuRi(int year, int month, int day, int state)
        {

            return financeBLL.ShowCaiwuRi(year, month, day, state);
        }
        /// <summary>
        /// 根据年月日查询图表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable ShowTuBiaoRi(int year, int month, int day)
        {
            return financeBLL.ShowTuBiaoRi(year, month, day);
        }
        #region 微信端
        //获取所有座位信息
        SeatBLL bll = new SeatBLL();
        [HttpGet]
        public List<Seat> GetSeats(int HId)
        {
            List<Seat> list= bll.Show().Where(s=>s.MovieHallId==HId).ToList();
            return list;
        }
        //更改座位状态
        [HttpGet]
        public int UpdSeatWX(string Ids)
        {
            string strResult = Ids.Substring(0,Ids.LastIndexOf(','));
            int result= seatBLL.UpdSeats(strResult);
            return result;
        }
        
        //添加订单 
        [HttpPost]
        public int AddOrderWX(MODEL.Order o)
        {
            o.CO_State = 1;//默认  下订单
            o.O_State = 2;//默认  未处理
            o.O_STime = DateTime.Now;
            int result = orderBLL.Add(o);
            return result;
        }

        /// <summary>
        /// 根据手机号查询
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Custom> shouCustomTel(string tel)
        {
            return CustomBLL.CreateCustomBll().shouCustomTel(tel);
        }
        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders1(string tel)
        {
            return orderBLL.orders1(tel);
        }
        /// <summary>
        /// 已完成
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders2(string tel)
        {
            return orderBLL.orders2(tel);
        }
        /// <summary>
        /// 已取消
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders3(string tel)
        {
            return orderBLL.orders3(tel);
        }
        //下单成功  减去个人余额
        [HttpPost]
        public int UpdYuE(Custom c)
        {
            int CId= c.CId;
            float C_integral = c.C_integral;
            return CustomBLL.CreateCustomBll().UpdYuE(CId,C_integral);
        }
        #endregion
    }
}
