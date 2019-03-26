﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class OMCH
    {
        public int OId { get; set; }//编号
        public decimal O_Money { get; set; }//金额
        public int O_State { get; set; }//状态   1已处理 2未处理    管理员状态
        public int CO_State { get; set; }//订单状态  1订票  2退票  3已使用
        public string MName { get; set; }
        public string HName { get; set; }
        public string CName { get; set; }
        public DateTime BeginTime { get; set; }
        public string Phone { get; set; }
        public string SeatContent { get; set; }
    }
}
