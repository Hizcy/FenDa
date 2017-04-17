// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_JsapiTicket.cs
// 项目名称：买车网
// 创建时间：2015/4/19
// 负责人：
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
    /// 数据层实例化接口类 dbo.tb_JsapiTicket.
    /// </summary>
    public partial class tb_JsapiTicketDataAccessLayer
    {
        public tb_JsapiTicketEntity GetModel( string weixincode)
        {
            tb_JsapiTicketEntity _obj = null;
            SqlParameter[] _param ={
			
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            
            _param[0].Value = weixincode;

            string sqlStr = "select * from tb_JsapiTicket with(nolock) where  WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_JsapiTicketEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
