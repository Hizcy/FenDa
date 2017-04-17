// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_App_User.cs
// 项目名称：微信平台
// 创建时间：2015/3/30
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Jnwf.DAL;
using Jnwf.Model;
using Utils.Memcached;
using System.Data;

namespace Jnwf.BLL 
{
    public partial class tb_App_UserBLL : BaseBLL< tb_App_UserBLL>

    {
        //NetQueue<tb_App_UserEntity> mq;
        tb_App_UserDataAccessLayer tb_App_Userdal;
        public tb_App_UserBLL()
        {
            tb_App_Userdal = new tb_App_UserDataAccessLayer();
            //mq = new NetQueue<tb_App_UserEntity>();
        }

        public int Insert(tb_App_UserEntity tb_App_UserEntity)
        {
            int rows = tb_App_Userdal.Insert(tb_App_UserEntity);

            //MemcacheHelper.input("{" + string.Format(act, active.add, table.appuser, rows, "", key.appuser) + "}");
            //MemcacheHelper.input("{" + string.Format(act, active.add, table.openuser, 0, tb_App_UserEntity.OpenID, key.openuser) + "}");

            return rows;
        }

        public void Update(tb_App_UserEntity tb_App_UserEntity)
        {
            tb_App_Userdal.Update(tb_App_UserEntity);
        }

        public tb_App_UserEntity GetAdminSingle(int iD)
        {
           return tb_App_Userdal.Get_tb_App_UserEntity(iD);
        }

        public IList<tb_App_UserEntity> Gettb_App_UserList()
        {
            IList<tb_App_UserEntity> tb_App_UserList = new List<tb_App_UserEntity>();
            tb_App_UserList=tb_App_Userdal.Get_tb_App_UserAll();
            return tb_App_UserList;
        }

        public tb_App_UserEntity GetModelByExist(string openid, string weixincode)
        {
            return tb_App_Userdal.Get_tb_App_UserEntity(openid,weixincode,1);
        }
        public tb_App_UserEntity GetModelByDel(string openid, string weixincode)
        {
            return tb_App_Userdal.Get_tb_App_UserEntity(openid, weixincode,0);
        }

        //public void Send(tb_App_UserEntity tb_App_UserEntity)
        //{
        //    mq.Send(tb_App_UserEntity);
        //}
        //public int ReceiveFromQueue()
        //{
        //    tb_App_UserEntity model = this.mq.Receive();
        //    return Insert(model);
        //}

        public tb_App_UserExtEntity GetUserInfo(string openid)
        {
            
            return tb_App_Userdal.GetUserInfo(openid);
        }
        public tb_App_UserEntity GetModelByCache(string openid)
        {
            string key = "appuser" + openid;
            tb_App_UserEntity model = null;
            object obj = MemcacheHelper.Get(key);
            if (obj != null)
            {
                model = Jnwf.Utils.Json.JsonHelper.DeserializeJson<tb_App_UserEntity>(obj.ToString());
            }
            return model;
        }
        public tb_App_UserEntity GetModelByOpenId(string openid)
        {
            return tb_App_Userdal.GetModelByOpenId(openid);
        }
        /// <summary>
        /// 获取没有真实open信息的用户
        /// </summary>
        /// <returns></returns>
        public IList<tb_App_UserEntity> GetNotExistsOpenInfo()
        {
            return tb_App_Userdal.GetNotExistsOpenInfo();
        }
        public int GetRecommandCount(string openid)
        {
            return tb_App_Userdal.GetRecommandCount(openid);
        }
        public int InsertProcedure(tb_App_UserEntity _tb_App_UserModel)
        {
            return tb_App_Userdal.InsertProcedure(_tb_App_UserModel);
        }
        public DataSet GetList(string weixincode, string me, int id)
        {
            return tb_App_Userdal.GetList(weixincode, me, id);
        }
        public DataSet GetListByRenRen(string weixincode, string me, int id)
        {
            return tb_App_Userdal.GetListByRenRen(weixincode, me, id);
        }
    }
}
