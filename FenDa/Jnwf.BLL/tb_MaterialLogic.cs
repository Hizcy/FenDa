// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Material.cs
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
    public partial class tb_MaterialBLL : BaseBLL< tb_MaterialBLL>

    {
        tb_MaterialDataAccessLayer tb_Materialdal;
        public tb_MaterialBLL()
        {
            tb_Materialdal = new tb_MaterialDataAccessLayer();
        }

        public int Insert(tb_MaterialEntity tb_MaterialEntity)
        {
            return tb_Materialdal.Insert(tb_MaterialEntity);            
        }
        public int Insert(tb_MaterialEntity tb_MaterialEntity, List<tb_MaterialContentEntity> tb_MaterialContentList)
        {
            return tb_Materialdal.Insert(tb_MaterialEntity, tb_MaterialContentList);
        }
        public void Update(tb_MaterialEntity tb_MaterialEntity)
        {
            tb_Materialdal.Update(tb_MaterialEntity);
        }
        public void Update(int materialid, List<tb_MaterialContentEntity> tb_MaterialContentList)
        {
            tb_Materialdal.Update(materialid, tb_MaterialContentList);
        }
        public tb_MaterialEntity GetAdminSingle(int iD)
        {
           return tb_Materialdal.Get_tb_MaterialEntity(iD);
        }

        public IList<tb_MaterialEntity> Gettb_MaterialList()
        {
            IList<tb_MaterialEntity> tb_MaterialList = new List<tb_MaterialEntity>();
            tb_MaterialList=tb_Materialdal.Get_tb_MaterialAll();
            return tb_MaterialList;
        }
        //public IList<Jnwf.Model.tb_MaterialEntity> LoadMulti(string userid, string weixincode)
        //{
        //    IList<tb_MaterialEntity> tb_MaterialContentList = new List<tb_MaterialEntity>();
        //    tb_MaterialContentList = tb_Materialdal.LoadMulti(userid, weixincode);
        //    return tb_MaterialContentList;
        //}
        public int Save(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content, Jnwf.Model.tb_CustomReplyEntity model)
        {
            return tb_Materialdal.Save(material,content,model);
        }
        public int Save(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content)
        {
            return tb_Materialdal.Save(material, content);
        }

        public Jnwf.Model.tb_MaterialExtEntity GetMaterialExt(int materialid)
        {
            return tb_Materialdal.GetMaterialExt(materialid);
        }
        public IList<Jnwf.Model.tb_MaterialExtEntity> GetMaterialExtList(string weixincode)
        {
            return tb_Materialdal.Get_tb_MaterialList(weixincode);

        }
    }
}
