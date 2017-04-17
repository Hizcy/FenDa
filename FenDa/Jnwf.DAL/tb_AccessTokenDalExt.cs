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
    /// 数据层实例化接口类 dbo.tb_AccessToken.
    /// </summary>
    public partial class tb_AccessTokenDataAccessLayer 
    {
        public tb_AccessTokenEntity GetModel(string userid, string weixincode)
        {
            tb_AccessTokenEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;

            string sqlStr = "select * from tb_AccessToken with(nolock) where UserID=@userid and WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_AccessTokenEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_AccessTokenEntity GetModel(string weixincode)
        {
            tb_AccessTokenEntity _obj = null;
            SqlParameter[] _param ={
			
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            
            _param[0].Value = weixincode;

            string sqlStr = "select * from tb_AccessToken with(nolock) where WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_AccessTokenEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
