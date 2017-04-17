// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_MaterialContent.cs
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
    public partial class tb_MaterialContentBLL : BaseBLL< tb_MaterialContentBLL>

    {
        tb_MaterialContentDataAccessLayer tb_MaterialContentdal;
        public tb_MaterialContentBLL()
        {
            tb_MaterialContentdal = new tb_MaterialContentDataAccessLayer();
        }

        public int Insert(tb_MaterialContentEntity tb_MaterialContentEntity)
        {
            return tb_MaterialContentdal.Insert(tb_MaterialContentEntity);            
        }

        public void Update(tb_MaterialContentEntity tb_MaterialContentEntity)
        {
            tb_MaterialContentdal.Update(tb_MaterialContentEntity);
        }

        public tb_MaterialContentEntity GetAdminSingle(int iD)
        {
           return tb_MaterialContentdal.Get_tb_MaterialContentEntity(iD);
        }

        public IList<tb_MaterialContentEntity> Gettb_MaterialContentList()
        {
            IList<tb_MaterialContentEntity> tb_MaterialContentList = new List<tb_MaterialContentEntity>();
            tb_MaterialContentList=tb_MaterialContentdal.Get_tb_MaterialContentAll();
            return tb_MaterialContentList;
        }

        public IList<Jnwf.Model.tb_MaterialContentEntity> LoadSingle(string userid, string weixincode)
        {
            IList<tb_MaterialContentEntity> tb_MaterialContentList = new List<tb_MaterialContentEntity>();
            tb_MaterialContentList = tb_MaterialContentdal.LoadSingle(userid,weixincode);
            return tb_MaterialContentList;
        }

        public IList<Jnwf.Model.tb_MaterialContentEntity> LoadMulti(string userid, string weixincode)
        {
            IList<tb_MaterialContentEntity> tb_MaterialContentList = new List<tb_MaterialContentEntity>();
            tb_MaterialContentList = tb_MaterialContentdal.LoadMulti(userid, weixincode);
            return tb_MaterialContentList;
        }

        public IList<Jnwf.Model.tb_MaterialContentEntity> LoadAll(string userid, string weixincode)
        {
            IList<tb_MaterialContentEntity> tb_MaterialContentList = new List<tb_MaterialContentEntity>();
            tb_MaterialContentList = tb_MaterialContentdal.LoadAll(userid, weixincode);
            return tb_MaterialContentList;
        }

        public IList<tb_MaterialContentEntity> GetList(int materialid)
        {
            IList<tb_MaterialContentEntity> tb_MaterialContentList = new List<tb_MaterialContentEntity>();
            tb_MaterialContentList = tb_MaterialContentdal.GetList(materialid);
            return tb_MaterialContentList;
        }
    }
}
