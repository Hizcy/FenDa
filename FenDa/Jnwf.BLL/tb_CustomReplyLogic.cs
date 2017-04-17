// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_CustomReply.cs
// 项目名称：微信平台
// 创建时间：2015/3/30
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Jnwf.DAL;
using Jnwf.Model;

namespace Jnwf.BLL 
{
    public partial class tb_CustomReplyBLL : BaseBLL< tb_CustomReplyBLL>

    {
        tb_CustomReplyDataAccessLayer tb_CustomReplydal;
        public tb_CustomReplyBLL()
        {
            tb_CustomReplydal = new tb_CustomReplyDataAccessLayer();
        }

        public int Insert(tb_CustomReplyEntity tb_CustomReplyEntity)
        {
            return tb_CustomReplydal.Insert(tb_CustomReplyEntity);            
        }

        public void Update(tb_CustomReplyEntity tb_CustomReplyEntity)
        {
            tb_CustomReplydal.Update(tb_CustomReplyEntity);
        }
        public int Delete(int iD)
        {
            return tb_CustomReplydal.Delete(iD);
        }

        public tb_CustomReplyEntity GetAdminSingle(int iD)
        {
           return tb_CustomReplydal.Get_tb_CustomReplyEntity(iD);
        }

        public IList<tb_CustomReplyEntity> Gettb_CustomReplyList()
        {
            IList<tb_CustomReplyEntity> tb_CustomReplyList = new List<tb_CustomReplyEntity>();
            tb_CustomReplyList=tb_CustomReplydal.Get_tb_CustomReplyAll();
            return tb_CustomReplyList;
        }

        public IList<tb_CustomReplyEntity> Gettb_CustomReplyList(string userid,string weixincode)
        {
            IList<tb_CustomReplyEntity> tb_CustomReplyList = new List<tb_CustomReplyEntity>();
            tb_CustomReplyList = tb_CustomReplydal.GetList(userid,weixincode);
            return tb_CustomReplyList;
        }

        public tb_MaterialExtEntity GetMaterialExtByCustomReply(string weixincode, string keyword)
        {
            tb_MaterialExtEntity tb_MaterialExtEntity = new tb_MaterialExtEntity();
            tb_MaterialExtEntity = tb_CustomReplydal.GetMaterialExtByCustomReply(weixincode, keyword);
            return tb_MaterialExtEntity;
        }
    }
}
