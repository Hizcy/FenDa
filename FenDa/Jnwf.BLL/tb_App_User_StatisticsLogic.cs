// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_App_User_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/6/26
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Jnwf.DAL;
using Jnwf.Model;

namespace Jnwf.BLL
{
    public partial class tb_App_User_StatisticsBLL : BaseBLL< tb_App_User_StatisticsBLL>

    {
        tb_App_User_StatisticsDataAccessLayer tb_App_User_Statisticsdal;
        public tb_App_User_StatisticsBLL()
        {
            tb_App_User_Statisticsdal = new tb_App_User_StatisticsDataAccessLayer();
        }

        public int Insert(tb_App_User_StatisticsEntity tb_App_User_StatisticsEntity)
        {
            return tb_App_User_Statisticsdal.Insert(tb_App_User_StatisticsEntity);            
        }

        public void Update(tb_App_User_StatisticsEntity tb_App_User_StatisticsEntity)
        {
            tb_App_User_Statisticsdal.Update(tb_App_User_StatisticsEntity);
        }

        public tb_App_User_StatisticsEntity GetAdminSingle(int id)
        {
           return tb_App_User_Statisticsdal.Get_tb_App_User_StatisticsEntity(id);
        }

        public IList<tb_App_User_StatisticsEntity> Gettb_App_User_StatisticsList()
        {
            IList<tb_App_User_StatisticsEntity> tb_App_User_StatisticsList = new List<tb_App_User_StatisticsEntity>();
            tb_App_User_StatisticsList=tb_App_User_Statisticsdal.Get_tb_App_User_StatisticsAll();
            return tb_App_User_StatisticsList;
        }
        public IList<tb_App_User_StatisticsEntity> GetList(string weixincode,DateTime begin,DateTime end)
        {
            IList<tb_App_User_StatisticsEntity> tb_App_User_StatisticsList = new List<tb_App_User_StatisticsEntity>();
            tb_App_User_StatisticsList = tb_App_User_Statisticsdal.GetList(weixincode,begin,end);
            return tb_App_User_StatisticsList;
        }
    }
}
