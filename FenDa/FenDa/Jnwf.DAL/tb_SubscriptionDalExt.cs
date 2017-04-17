// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Subscription.cs
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
    /// 数据层实例化接口类 dbo.tb_Subscription.
    /// </summary>
    public partial class tb_SubscriptionDataAccessLayer 
    {
        public tb_SubscriptionEntity GetModelByWeiXinCode(string weixincode)
        {
            tb_SubscriptionEntity _obj = null;
            SqlParameter[] _param ={
			
            new SqlParameter("@weixincode",SqlDbType.VarChar)
			};
            
            _param[0].Value = weixincode;
            string sqlStr = "select * from tb_Subscription with(nolock) where WeiXinCode=@weixincode ";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    _obj = Populate_tb_SubscriptionEntity_FromDr(dr);
                }
            }
            return _obj;
        }
        public tb_MaterialExtEntity GetMaterialExtEntityByWeiXinCode(string weixincode)
        {
            tb_SubscriptionEntity Obj = GetModelByWeiXinCode(weixincode);

            if (Obj == null || Obj.MaterialID == 0)
                return null;
            tb_MaterialDataAccessLayer dal = new tb_MaterialDataAccessLayer();
            return dal.GetMaterialExt(Obj.MaterialID);
        }
        public int Save(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content)
        {
            int result = 0;
            //IList<tb_CustomReplyEntity> Obj = new List<tb_CustomReplyEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
            new SqlParameter("@TypeID",SqlDbType.Int),

            new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@Author",SqlDbType.VarChar),
            new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@ImageUrl",SqlDbType.VarChar),
            new SqlParameter("@TextContent",SqlDbType.VarChar),
			new SqlParameter("@Url",SqlDbType.VarChar),
            new SqlParameter("@OrderBy",SqlDbType.Int)
            };
            _param[0].Value = material.UserID;
            _param[1].Value = material.WeiXinCode;
            _param[2].Value = material.TypeID;

            _param[3].Value = content.Title;
            _param[4].Value = content.Author;
            _param[5].Value = content.Description;
            _param[6].Value = content.ImageUrl;
            _param[7].Value = content.TextContent;
            _param[8].Value = content.Url;
            _param[9].Value = content.OrderBy;


            string sqlStr = "dbo.pro_AddSubscription";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.StoredProcedure, sqlStr, _param))
            {
                while (dr.Read())
                {
                    int i = 0;
                    int.TryParse(dr[0].ToString(), out i);
                    result = i;
                }
            }
            return result;
        }
	}
}
