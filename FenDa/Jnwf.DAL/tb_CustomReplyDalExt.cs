// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_CustomReply.cs
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
    /// 数据层实例化接口类 dbo.tb_CustomReply.
    /// </summary>
    public partial class tb_CustomReplyDataAccessLayer 
    {
        public IList<tb_CustomReplyEntity> GetList(string userid,string weixincode)
        {
            IList<tb_CustomReplyEntity> Obj = new List<tb_CustomReplyEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
			new SqlParameter("@weixincode",SqlDbType.VarChar,50)
            };
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            string sqlStr = "select * from tb_CustomReply where UserId=@userid and WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_CustomReplyEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public tb_MaterialExtEntity GetMaterialExtByCustomReply(string weixincode, string keyword)
        {
            tb_CustomReplyEntity Obj = new tb_CustomReplyEntity();
            SqlParameter[] _param ={
			new SqlParameter("@keyword",SqlDbType.VarChar,50),
			new SqlParameter("@weixincode",SqlDbType.VarChar,50)
            };
            _param[0].Value = keyword;
            _param[1].Value = weixincode;
            string sqlStr = "select top 1 * from tb_CustomReply where Keyword=@keyword and WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj = Populate_tb_CustomReplyEntity_FromDr(dr);
                }
            }
            if (Obj.MaterialID == 0)
                return null;
            tb_MaterialDataAccessLayer dal = new tb_MaterialDataAccessLayer();
            return dal.GetMaterialExt(Obj.MaterialID);
        }
	}
}
