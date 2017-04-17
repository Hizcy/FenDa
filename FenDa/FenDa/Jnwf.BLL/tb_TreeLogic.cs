// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Tree.cs
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
    public partial class tb_TreeBLL : BaseBLL< tb_TreeBLL>

    {
        tb_TreeDataAccessLayer tb_Treedal;
        public tb_TreeBLL()
        {
            tb_Treedal = new tb_TreeDataAccessLayer();
        }

        public int Insert(tb_TreeEntity tb_TreeEntity)
        {
            return tb_Treedal.Insert(tb_TreeEntity);            
        }

        public void Update(tb_TreeEntity tb_TreeEntity)
        {
            tb_Treedal.Update(tb_TreeEntity);
        }

        public tb_TreeEntity GetAdminSingle(int iD)
        {
           return tb_Treedal.Get_tb_TreeEntity(iD);
        }

        public IList<tb_TreeEntity> Gettb_TreeList()
        {
            IList<tb_TreeEntity> tb_TreeList = new List<tb_TreeEntity>();
            tb_TreeList=tb_Treedal.Get_tb_TreeAll();
            return tb_TreeList;
        }
    }
}
