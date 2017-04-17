// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_User.cs
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
    /// 数据层实例化接口类 dbo.tb_User.
    /// </summary>
    public partial class tb_UserDataAccessLayer 
    {
        /// <summary>
        /// 根据用户名和密码,返回一个tb_User对象
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="pwd">pwd</param>
        /// <returns>tb_User对象</returns>
        public tb_UserEntity Get_tb_UserEntity(string name , string pwd)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@name",SqlDbType.VarChar,50),
            new SqlParameter("@pwd",SqlDbType.VarChar,50)
			};
            _param[0].Value = name;
            _param[1].Value = pwd;
            string sqlStr = "select * from tb_User with(nolock) where UserID=@name and PWD=@pwd";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        /// <summary>
        /// 根据用户名,返回一个tb_User对象
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>tb_User对象</returns>
        public tb_UserEntity Get_tb_UserEntity(string name)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@name",SqlDbType.VarChar,50)
			};
            _param[0].Value = name;

            string sqlStr = "select * from tb_User with(nolock) where UserID=@name ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }

        public tb_UserEntity GetModelByWeiXin(string weixin)
        {
            tb_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@weixin",SqlDbType.VarChar,50)
			};
            _param[0].Value = weixin;

            string sqlStr = "select * from tb_User with(nolock) where WeiXinCode=@weixin ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
	}
}
