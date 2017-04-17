// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Log.cs
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
    public partial class tb_LogBLL : BaseBLL< tb_LogBLL>

    {
        tb_LogDataAccessLayer tb_Logdal;
        public tb_LogBLL()
        {
            tb_Logdal = new tb_LogDataAccessLayer();
        }

        public int Insert(tb_LogEntity tb_LogEntity)
        {
            return tb_Logdal.Insert(tb_LogEntity);            
        }

        public void Update(tb_LogEntity tb_LogEntity)
        {
            tb_Logdal.Update(tb_LogEntity);
        }

        public tb_LogEntity GetAdminSingle(int iD)
        {
           return tb_Logdal.Get_tb_LogEntity(iD);
        }

        public IList<tb_LogEntity> Gettb_LogList()
        {
            IList<tb_LogEntity> tb_LogList = new List<tb_LogEntity>();
            tb_LogList=tb_Logdal.Get_tb_LogAll();
            return tb_LogList;
        }
    }
}
