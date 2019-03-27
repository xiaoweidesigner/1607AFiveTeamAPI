using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public  class UserOrder
    {
        public int OId { get; set; }//编号
        public int SessionSId { get; set; }//场次表外键
        public decimal O_Money { get; set; }//金额
        public int CustomId { get; set; }//顾客表外键
        public int CO_State { get; set; }//顾客订单状态  1、订票  2、退票 3、已使用 
        public DateTime O_STime { get; set; }
        public string SeatContent { get; set; }//座位信息  放映厅名称+座位号

        public int MId { get; set; }//编号
        public string M_Name { get; set; }//电影名称
        public string M_Img { get; set; }//电影图片

        public DateTime S_BeginTime { get; set; }//开始时间
    }
}
