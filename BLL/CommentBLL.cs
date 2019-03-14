using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataService;
using MODEL;

namespace BLL
{
    public class CommentBLL : ICommon<Comment>
    {
        #region 单例
        private static CommentBLL bll = null;
        private CommentBLL()
        {
        }
        public static CommentBLL CreateCommentBll()
        {
            if (bll == null)
            {
                bll = new CommentBLL();
            }
            return bll;
        }
        #endregion
        public int Add(Comment t)
        {
            return CommentDAL.CreateCommentDal().Add(t);
        }

        public int Del(int Id)
        {
            return CommentDAL.CreateCommentDal().Del(Id);
        }

        public List<Comment> Show()
        {
            return CommentDAL.CreateCommentDal().Show();
        }

        public Comment ShowById(int Id)
        {
            return CommentDAL.CreateCommentDal().ShowById(Id);
        }

        public int Upd(Comment t)
        {
            return CommentDAL.CreateCommentDal().Upd(t);
        }
    }
}
