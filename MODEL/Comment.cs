﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    //评论表
    public class Comment
    {
        [Key]
        public int CoId { get; set; }//编号
        [ForeignKey("Custom")]
        public int CustomId { get; set; }//顾客表外键
        public string Details { get; set; }//评论内容
        public DateTime C_Time { get; set; }//评论时间
        [ForeignKey("Movie")]
        public int MovieId { get; set; }//电影外键

        public Movie Movie { get; set; }
        public Custom Custom { get; set; }
    }
}
