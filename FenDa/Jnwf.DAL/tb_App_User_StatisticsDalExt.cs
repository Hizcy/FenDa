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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Jnwf.Model;
using Jnwf.Utils.Data;


namespace Jnwf.DAL
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_App_User_Statistics.
    /// </summary>
    public partial class tb_App_User_StatisticsDataAccessLayer 
    {
        public IList<tb_App_User_StatisticsEntity> GetList(string weixincode,DateTime begintime,DateTime endtime)
        {
            IList<tb_App_User_StatisticsEntity> Obj = new List<tb_App_User_StatisticsEntity>();
            SqlParameter[] _param ={
			    new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
                new SqlParameter("@begintime",SqlDbType.DateTime),
                new SqlParameter("@endtime",SqlDbType.DateTime)
			};
            _param[0].Value = weixincode;
            _param[1].Value = begintime;
            _param[2].Value = endtime;

            string sqlStr = "select * from tb_App_User_Statistics where date>=@begintime and date<=@endtime and weixincode=@WeiXinCode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_App_User_StatisticsEntity_FromDr(dr));
                }
            }
            return Obj;
        }
	}
}
