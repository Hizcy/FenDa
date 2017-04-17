// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_MaterialContent.cs
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
    /// 数据层实例化接口类 dbo.tb_MaterialContent.
    /// </summary>
    public partial class tb_MaterialContentDataAccessLayer 
    {
        public IList<tb_MaterialContentEntity> LoadSingle(string userid,string weixincode)
        {
            IList<tb_MaterialContentEntity> Obj = new List<tb_MaterialContentEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            string sqlStr = "select b.* from tb_Material a inner join tb_MaterialContent b on a.ID=b.MaterialID where a.UserID=@userid and a.WeiXinCode=@weixincode and TypeID=2 and Status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public IList<tb_MaterialContentEntity> LoadMulti(string userid, string weixincode)
        {
            IList<tb_MaterialContentEntity> Obj = new List<tb_MaterialContentEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode; 
            string sqlStr = "select * from tb_Material a inner join tb_MaterialContent b on a.ID=b.MaterialID where a.UserID=@userid and a.WeiXinCode=@weixincode and TypeID=3 and Status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public IList<tb_MaterialContentEntity> LoadAll(string userid, string weixincode)
        {
            IList<tb_MaterialContentEntity> Obj = new List<tb_MaterialContentEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            string sqlStr = "select b.* from tb_Material a inner join tb_MaterialContent b on a.ID=b.MaterialID where a.UserID=@userid and a.WeiXinCode=@weixincode and Status=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<tb_MaterialContentEntity> GetList(int materialid)
        {
            IList<tb_MaterialContentEntity> Obj = new List<tb_MaterialContentEntity>();
            SqlParameter[] _param ={
            new SqlParameter("@materialid",SqlDbType.Int)
			};
            _param[0].Value = materialid;

            string sqlStr = "select * from tb_MaterialContent where MaterialID=@materialid";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public int DeleteByMaterialID( int materialid)
        {
            string sqlStr = "delete from tb_MaterialContent where [MaterialID]=@materialid";
            SqlParameter[] _param ={			
			new SqlParameter("@materialid",SqlDbType.Int),
			
			};
            _param[0].Value = materialid;
            return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW, CommandType.Text, sqlStr, _param);
        }
	}
}
