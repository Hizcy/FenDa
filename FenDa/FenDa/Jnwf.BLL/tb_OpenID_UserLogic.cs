// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_OpenID_User.cs
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
using System.Web;

namespace Jnwf.BLL 
{
    public partial class tb_OpenID_UserBLL : BaseBLL< tb_OpenID_UserBLL>

    {
        tb_OpenID_UserDataAccessLayer tb_OpenID_Userdal;
        public tb_OpenID_UserBLL()
        {
            tb_OpenID_Userdal = new tb_OpenID_UserDataAccessLayer();
        }

        public int Insert(tb_OpenID_UserEntity tb_OpenID_UserEntity)
        {
            return tb_OpenID_Userdal.Insert(tb_OpenID_UserEntity);            
        }

        public void Update(tb_OpenID_UserEntity tb_OpenID_UserEntity)
        {
            tb_OpenID_Userdal.Update(tb_OpenID_UserEntity);
        }

        public tb_OpenID_UserEntity GetAdminSingle(int iD)
        {
           return tb_OpenID_Userdal.Get_tb_OpenID_UserEntity(iD);
        }

        public IList<tb_OpenID_UserEntity> Gettb_OpenID_UserList()
        {
            IList<tb_OpenID_UserEntity> tb_OpenID_UserList = new List<tb_OpenID_UserEntity>();
            tb_OpenID_UserList=tb_OpenID_Userdal.Get_tb_OpenID_UserAll();
            return tb_OpenID_UserList;
        }

        public tb_OpenID_UserEntity GetModelByCache(string openid)
        {
            string key = "openuser" + openid;
            tb_OpenID_UserEntity model = null;
            object obj = MemcacheHelper.Get(key);
            if (obj != null)
            {
                model = Jnwf.Utils.Json.JsonHelper.DeserializeJson<tb_OpenID_UserEntity>(obj.ToString());
            }
            return model;
        }
       
        public tb_OpenID_UserEntity GetModelByOpenId(string openid)
        {
            return tb_OpenID_Userdal.GetModelByOpenId(openid);
        }
        public IList<tb_OpenID_UserEntity> GetRecommendListByOpenId(string openid)
        {
            IList<tb_OpenID_UserEntity> tb_OpenID_UserList = new List<tb_OpenID_UserEntity>();
            tb_OpenID_UserList = tb_OpenID_Userdal.GetRecommendListByOpenId(openid);
            return tb_OpenID_UserList;
        }
        public int UpdateQrcode(int shopid, string openid, string qrcode)
        {
            return tb_OpenID_Userdal.UpdateQrcode(shopid,openid,qrcode);
        }
        public int UpdateRenRenQrcode(int shopid, string openid, string qrcode)
        {
            return tb_OpenID_Userdal.UpdateRenRenQrcode(shopid, openid, qrcode);
        }
    }
}
