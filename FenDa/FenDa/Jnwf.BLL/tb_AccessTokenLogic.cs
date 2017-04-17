// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_AccessToken.cs
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
    public partial class tb_AccessTokenBLL : BaseBLL< tb_AccessTokenBLL>

    {
        tb_AccessTokenDataAccessLayer tb_AccessTokendal;
        public tb_AccessTokenBLL()
        {
            tb_AccessTokendal = new tb_AccessTokenDataAccessLayer();
        }

        public int Insert(tb_AccessTokenEntity tb_AccessTokenEntity)
        {
            return tb_AccessTokendal.Insert(tb_AccessTokenEntity);            
        }

        public void Update(tb_AccessTokenEntity tb_AccessTokenEntity)
        {
            tb_AccessTokendal.Update(tb_AccessTokenEntity);
        }

        public tb_AccessTokenEntity GetAdminSingle(int iD)
        {
           return tb_AccessTokendal.Get_tb_AccessTokenEntity(iD);
        }

        public IList<tb_AccessTokenEntity> Gettb_AccessTokenList()
        {
            IList<tb_AccessTokenEntity> tb_AccessTokenList = new List<tb_AccessTokenEntity>();
            tb_AccessTokenList=tb_AccessTokendal.Get_tb_AccessTokenAll();
            return tb_AccessTokenList;
        }

        public tb_AccessTokenEntity GetModel(string userid,string weixincode)
        {
            return tb_AccessTokendal.GetModel(userid,weixincode);
        }

        public tb_AccessTokenEntity GetModel(string weixincode)
        {
            return tb_AccessTokendal.GetModel(weixincode);
        }
    }
}
