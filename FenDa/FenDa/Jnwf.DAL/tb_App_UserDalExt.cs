// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_App_User.cs
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
    /// 数据层实例化接口类 dbo.tb_App_User.
    /// </summary>
    public partial class tb_App_UserDataAccessLayer 
    {
        public tb_App_UserEntity Get_tb_App_UserEntity(string openid,string weixincode,int status)
        {
            tb_App_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@openid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50),
            new SqlParameter("@status",SqlDbType.Int)
			};
            _param[0].Value = openid;
            _param[1].Value = weixincode;
            _param[2].Value = status;

            string sqlStr = "select * from tb_App_User with(nolock) where WeiXinCode=@weixincode and OpenID=@openid and Status=@status";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_App_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }

        public tb_App_UserExtEntity GetUserInfo(string openid)
        {
            tb_App_UserExtEntity _obj = new tb_App_UserExtEntity();

            SqlParameter[] _param ={
			new SqlParameter("@openid",SqlDbType.VarChar,50)
            };
            _param[0].Value = openid;

            string sqlStr = "select * from tb_App_User a with(nolock) inner join tb_OpenID_User b with (nolock) on a.openid=b.openid where a.OpenID=@openid and Status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj.user = Populate_tb_App_UserEntity_FromDr(dr);
                    _obj.ext = new Jnwf.DAL.tb_OpenID_UserDataAccessLayer().Populate_tb_OpenID_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }

        public IList<tb_App_UserEntity> GetNotExistsOpenInfo()
        {
            IList<tb_App_UserEntity> Obj = new List<tb_App_UserEntity>();
            string sqlStr = "SELECT top 10 a.* FROM tb_App_User a with (nolock) left join tb_OpenID_User b with (nolock) on a.openid=b.openid where b.id is null and a.status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr)) 
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_App_UserEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int GetRecommandCount(string openid)
        {
            SqlParameter[] _param ={
			new SqlParameter("@OpenId",SqlDbType.VarChar)
			};
            _param[0].Value = openid;
            string sqlStr = "select count(*) FROM tb_App_User where Recommend=@OpenId and status=1";

            int rows = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW, CommandType.Text, sqlStr, _param));

            return rows;
        }
        public tb_App_UserEntity GetModelByOpenId(string openid)
        {
            tb_App_UserEntity _obj = null;

            SqlParameter[] _param ={
			new SqlParameter("@openid",SqlDbType.VarChar)
            };
            _param[0].Value = openid;

            string sqlStr = "select * from tb_App_User with(nolock) where openid=@openid and Status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_App_UserEntity_FromDr(dr);
                   
                }
            }
            return _obj;
        }
        public int InsertProcedure(tb_App_UserEntity _tb_App_UserModel)
        {
            int res;
            SqlParameter[] _param ={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@OpenID",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@Recommend",SqlDbType.VarChar)
            };
            _param[0].Value = _tb_App_UserModel.WeiXinCode;
            _param[1].Value = _tb_App_UserModel.OpenID;
            _param[2].Value = _tb_App_UserModel.Status;
            _param[3].Value = _tb_App_UserModel.Recommend;

            res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW, CommandType.StoredProcedure, "pro_Add_App_User", _param));
            return res;
        }
        public DataSet GetList(string weixincode, string me, int id)
        {

            SqlParameter[] _param ={
			new SqlParameter("@weixincode",SqlDbType.VarChar),
            new SqlParameter("@me",SqlDbType.VarChar),
            new SqlParameter("@id",SqlDbType.Int)
            };
            _param[0].Value = weixincode;
            _param[1].Value = me;
            _param[2].Value = id;


            //string sqlStr = "select top @num * from v_Users with(nolock) where weixincode=@weixincode and Id<@id order by orderid";
            return SqlHelper.ExecuteDataset(WebConfig.weixinRW, CommandType.StoredProcedure, "pro_Get_v_Users", _param);

        }
        public DataSet GetListByRenRen(string weixincode, string me, int id)
        {

            SqlParameter[] _param ={
			new SqlParameter("@weixincode",SqlDbType.VarChar),
            new SqlParameter("@me",SqlDbType.VarChar),
            new SqlParameter("@id",SqlDbType.Int)
            };
            _param[0].Value = weixincode;
            _param[1].Value = me;
            _param[2].Value = id;


            //string sqlStr = "select top @num * from v_Users with(nolock) where weixincode=@weixincode and Id<@id order by orderid";
            return SqlHelper.ExecuteDataset(WebConfig.weixinRW, CommandType.StoredProcedure, "pro_Get_RenRen_Users", _param);

        }
	}
}
