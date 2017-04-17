// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_OpenID_User.cs
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
    /// 数据层实例化接口类 dbo.tb_OpenID_User.
    /// </summary>
    public partial class tb_OpenID_UserDataAccessLayer
    {
        public tb_OpenID_UserEntity GetModelByOpenId(string openid)
        {
            tb_OpenID_UserEntity _obj = null;
            SqlParameter[] _param ={
			new SqlParameter("@openid",SqlDbType.VarChar)
			};
            _param[0].Value = openid;
            string sqlStr = "select * from tb_OpenID_User with(nolock) where openid=@openid";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_OpenID_UserEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public IList<tb_OpenID_UserEntity> GetRecommendListByOpenId(string openid)
        {
            IList<tb_OpenID_UserEntity> Obj = new List<tb_OpenID_UserEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@OpenId",SqlDbType.VarChar)
			};
            _param[0].Value = openid;
            string sqlStr = "select a.* FROM tb_OpenID_User a inner join tb_App_User b on a.OpenId=b.OpenId where Recommend=@OpenId and status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_OpenID_UserEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public int UpdateQrcode(int shopid,string openid ,string qrcode)
        {
            string sqlStr = "pro_Update_qrcode";
            SqlParameter[] _param ={
			new SqlParameter("@ShopId",SqlDbType.Int),
            new SqlParameter("@Me",SqlDbType.VarChar),
            new SqlParameter("@Qrcode",SqlDbType.VarChar)
			};
            _param[0].Value = shopid;
            _param[1].Value = openid;
            _param[2].Value = qrcode;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW, CommandType.StoredProcedure, sqlStr, _param));
        }
        public int UpdateRenRenQrcode(int shopid, string openid, string qrcode)
        {
            string sqlStr = "pro_Update_RenRen_qrcode";
            SqlParameter[] _param ={
			new SqlParameter("@ShopId",SqlDbType.Int),
            new SqlParameter("@Me",SqlDbType.VarChar),
            new SqlParameter("@Qrcode",SqlDbType.VarChar)
			};
            _param[0].Value = shopid;
            _param[1].Value = openid;
            _param[2].Value = qrcode;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW, CommandType.StoredProcedure, sqlStr, _param));
        }
	}
}
