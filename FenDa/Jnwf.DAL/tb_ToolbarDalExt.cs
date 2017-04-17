// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Toolbar.cs
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
    /// 数据层实例化接口类 dbo.tb_Toolbar.
    /// </summary>
    public partial class tb_ToolbarDataAccessLayer 
    {
        public IList<tb_ToolbarEntity> GetList(string userid, string weixincode)
        {
            IList<tb_ToolbarEntity> Obj = new List<tb_ToolbarEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            string sqlStr = "select * from tb_Toolbar with(nolock) where UserID=@userid and WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ToolbarEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public IList<Model.tb_ToolbarEntity> GetFirstList(string userid, string weixincode)
        {
            IList<tb_ToolbarEntity> Obj = new List<tb_ToolbarEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            string sqlStr = "select * from tb_Toolbar with(nolock) where UserID=@userid and WeiXinCode=@weixincode and ToolLevel=1";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ToolbarEntity_FromDr(dr));
                }
            }
            return Obj;
        }
        public IList<Model.tb_ToolbarEntity> GetSecondList(string userid, string weixincode, int parentid)
        {
            IList<tb_ToolbarEntity> Obj = new List<tb_ToolbarEntity>();
            SqlParameter[] _param ={
			new SqlParameter("@userid",SqlDbType.VarChar,50),
            new SqlParameter("@weixincode",SqlDbType.VarChar,50),
            new SqlParameter("@parentid",SqlDbType.Int)
			};
            _param[0].Value = userid;
            _param[1].Value = weixincode;
            _param[2].Value = parentid;
            string sqlStr = "select * from tb_Toolbar with(nolock) where UserID=@userid and WeiXinCode=@weixincode and ToolLevel=2 and ParentID=@parentid";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_ToolbarEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public int Update(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content, int id)
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
            new SqlParameter("@OrderBy",SqlDbType.Int),

            new SqlParameter("@id",SqlDbType.Int)
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

            _param[10].Value = id;

            string sqlStr = "dbo.pro_UpdateToolbar";

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

        public tb_MaterialExtEntity GetMaterialExtByToolbar(string weixincode, string eventkey)
        {
            tb_ToolbarEntity Obj = new tb_ToolbarEntity();
            SqlParameter[] _param ={
			new SqlParameter("@eventkey",SqlDbType.VarChar,50),
			new SqlParameter("@weixincode",SqlDbType.VarChar,50)
            };
            _param[0].Value = eventkey;
            _param[1].Value = weixincode;
            string sqlStr = "select top 1 * from tb_Toolbar where Params=@eventkey and WeiXinCode=@weixincode";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj = Populate_tb_ToolbarEntity_FromDr(dr);
                }
            }
            if (Obj.MaterialID == 0)
                return null;

            tb_MaterialDataAccessLayer dal = new tb_MaterialDataAccessLayer();
            return dal.GetMaterialExt(Obj.MaterialID);
        }
	}
}
