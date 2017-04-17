// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Toolbar.cs
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
    public partial class tb_ToolbarBLL : BaseBLL< tb_ToolbarBLL>

    {
        tb_ToolbarDataAccessLayer tb_Toolbardal;
        public tb_ToolbarBLL()
        {
            tb_Toolbardal = new tb_ToolbarDataAccessLayer();
        }

        public int Insert(tb_ToolbarEntity tb_ToolbarEntity)
        {
            return tb_Toolbardal.Insert(tb_ToolbarEntity);            
        }

        public void Update(tb_ToolbarEntity tb_ToolbarEntity)
        {
            tb_Toolbardal.Update(tb_ToolbarEntity);
        }

        public int Delete(int iD)
        {
            return tb_Toolbardal.Delete(iD);
        }

        public tb_ToolbarEntity GetAdminSingle(int iD)
        {
           return tb_Toolbardal.Get_tb_ToolbarEntity(iD);
        }

        public IList<tb_ToolbarEntity> Gettb_ToolbarList()
        {
            IList<tb_ToolbarEntity> tb_ToolbarList = new List<tb_ToolbarEntity>();
            tb_ToolbarList=tb_Toolbardal.Get_tb_ToolbarAll();
            return tb_ToolbarList;
        }

        public IList<tb_ToolbarEntity> GetList(string userid, string weixincode)
        {
            IList<tb_ToolbarEntity> tb_ToolbarList = new List<tb_ToolbarEntity>();
            tb_ToolbarList = tb_Toolbardal.GetList(userid,weixincode);
            return tb_ToolbarList;
        }

        public IList<Model.tb_ToolbarEntity> GetFirstList(string userid, string weixincode)
        {
            IList<tb_ToolbarEntity> tb_ToolbarList = new List<tb_ToolbarEntity>();
            tb_ToolbarList = tb_Toolbardal.GetFirstList(userid, weixincode);
            return tb_ToolbarList;
        }

        public IList<Model.tb_ToolbarEntity> GetSecondList(string userid, string weixincode, int parentid)
        {
            IList<tb_ToolbarEntity> tb_ToolbarList = new List<tb_ToolbarEntity>();
            tb_ToolbarList = tb_Toolbardal.GetSecondList(userid, weixincode, parentid);
            return tb_ToolbarList;
        }

        public int Update(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content, int id)
        {
            return tb_Toolbardal.Update(material,content,id);
        }

        public tb_MaterialExtEntity GetMaterialExtByToolbar(string weixincode, string eventkey)
        {
            tb_MaterialExtEntity tb_MaterialExtEntity = new tb_MaterialExtEntity();
            tb_MaterialExtEntity = tb_Toolbardal.GetMaterialExtByToolbar(weixincode, eventkey);
            return tb_MaterialExtEntity;
        }
    }
}
