using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;

namespace RecallOnTime.Controllers
{
    public class XjwController : ApiController
    {
        #region 顾客的CRUD 及操作  充值
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
        public int JoinHY(int CId,int C_Name,string Img)
        {
            return CustomBLL.CreateCustomBll().JoinHY(CId,C_Name,Img);
        }
        #endregion

        #region 评论的CRUD 及操作
        [HttpPost]
        public int AddComment(Comment comment)
        {
            return CommentBLL.CreateCommentBll().Add(comment);
        }
        [HttpGet]
        public List<Comment> ShowComment() {
            return CommentBLL.CreateCommentBll().Show();
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
        
    }
}
