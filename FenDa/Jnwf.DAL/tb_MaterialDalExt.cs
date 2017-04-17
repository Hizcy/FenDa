// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Material.cs
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
using System.Linq;

namespace Jnwf.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_Material.
    /// </summary>
    public partial class tb_MaterialDataAccessLayer 
    {
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


            string sqlStr = "dbo.pro_AddMaterial";

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

        public int Save(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content, Jnwf.Model.tb_CustomReplyEntity model)
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

            new SqlParameter("@Keyword",SqlDbType.VarChar),
            new SqlParameter("@MatchingTypeID",SqlDbType.Int),
            new SqlParameter("@ReplyTypeID",SqlDbType.Int)
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

            _param[10].Value = model.Keyword;
            _param[11].Value = model.MatchingTypeID;
            _param[12].Value = model.ReplyTypeID;

            string sqlStr = "dbo.pro_AddCustomReply";
           
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.StoredProcedure, sqlStr, _param))
            {
                while (dr.Read())
                {
                    int i = 0;
                    int.TryParse(dr[0].ToString(),out i);
                    result = i;
                }
            }
            return result;
        }

        public Jnwf.Model.tb_MaterialExtEntity GetMaterialExt(int materialid)
        {
            tb_MaterialExtEntity Obj = new tb_MaterialExtEntity();
            SqlParameter[] _param ={
			new SqlParameter("@materialid",SqlDbType.Int)

			};
            _param[0].Value = materialid;

            string sqlStr = "select * from tb_Material where ID=@materialid and Status=1";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj = Populate_tb_MaterialExtEntity_FromDr(dr);
                }
            }

            string sqlStr2 = "select * from tb_MaterialContent where MaterialID=@materialid ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr2, _param))
            {
                while (dr.Read())
                {
                    Obj.list.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
                }
            }
            return Obj;
        }

        public tb_MaterialExtEntity Populate_tb_MaterialExtEntity_FromDr(IDataReader dr)
        {
            tb_MaterialExtEntity Obj = new tb_MaterialExtEntity();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.UserID = dr["UserID"].ToString();
            Obj.WeiXinCode = dr["WeiXinCode"].ToString();
            Obj.TypeID = ((dr["TypeID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TypeID"]);
            Obj.Status = ((dr["Status"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Status"]);
            Obj.AddTime = ((dr["AddTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["AddTime"]);
            Obj.UpdateTime = ((dr["UpdateTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["UpdateTime"]);

            return Obj;
        }

        public tb_MaterialContentEntity Populate_tb_MaterialContentEntity_FromDr(IDataReader dr)
        {
            tb_MaterialContentEntity Obj = new tb_MaterialContentEntity();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.MaterialID = ((dr["MaterialID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["MaterialID"]);
            Obj.Title = dr["Title"].ToString();
            Obj.Author = dr["Author"].ToString();
            Obj.Description = dr["Description"].ToString();
            Obj.ImageUrl = dr["ImageUrl"].ToString();
            Obj.TextContent = dr["TextContent"].ToString();
            Obj.Url = dr["Url"].ToString();
            Obj.OrderBy = ((dr["OrderBy"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["OrderBy"]);

            return Obj;
        }

        public int Insert(tb_MaterialEntity tb_MaterialEntity, List<tb_MaterialContentEntity> tb_MaterialContentList)
        {
            
            //没加事务，后期补上
            int materialid = Insert( tb_MaterialEntity);

            if (materialid > 0)
            {
                tb_MaterialContentDataAccessLayer dal = new tb_MaterialContentDataAccessLayer();
                foreach (var m in tb_MaterialContentList)
                {
                    m.MaterialID = materialid;
                    dal.Insert(m);
                }
            }
            return materialid;
            
        }

        public void Update(int materialid, List<tb_MaterialContentEntity> tb_MaterialContentList)
        {
            
            tb_MaterialEntity model = Get_tb_MaterialEntity(materialid);
            model.UpdateTime = DateTime.Now;
            Update(model);

            tb_MaterialContentDataAccessLayer dal = new tb_MaterialContentDataAccessLayer();
            dal.DeleteByMaterialID(materialid);

            foreach (var m in tb_MaterialContentList)
            {
                dal.Insert( m);
            }
            
        }

        public IList<tb_MaterialExtEntity> Get_tb_MaterialList(string weixincode)
        {
            IList<tb_MaterialAllEntity> Obj = new List<tb_MaterialAllEntity>();
            IList<tb_MaterialExtEntity> ext = new List<tb_MaterialExtEntity>(); 
            SqlParameter[] _param ={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar)

			};
            _param[0].Value = weixincode;
            string sqlStr = "select a.ID,a.UserID,a.WeiXinCode,a.TypeID,a.Status,a.AddTime, b.MaterialID, b.Title, b.Author, b.Description, b.ImageUrl, b.TextContent, b.Url, b.OrderBy from tb_Material a inner join tb_MaterialContent b on a.ID=b.MaterialID where a.WeiXinCode=@WeiXinCode and a.Status=1 and a.TypeID in (2,3)";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
            {
                while (dr.Read())
                {
                    Obj.Add(Populate_tb_MaterialAllEntity_FromDr(dr));
                }
            }
            //return Obj;
            
            List<tb_MaterialAllEntity> list = Obj as List<tb_MaterialAllEntity>;
            if (list != null)
            {
                foreach (IGrouping<int, tb_MaterialAllEntity> arr in list.GroupBy(c => c.ID))
                {
                    tb_MaterialExtEntity e = new tb_MaterialExtEntity();

                    foreach (tb_MaterialAllEntity m in arr)
                    {
                        e.ID = m.ID;
                        e.UserID = m.UserID;
                        e.WeiXinCode = m.WeiXinCode;
                        e.TypeID = m.TypeID;
                        e.Status = m.Status;
                        e.AddTime = m.AddTime;

                        e.list.Add(new tb_MaterialContentEntity()
                        {
                             MaterialID = m.MaterialID,
                             Title = m.Title,
                             Author = m.Author,
                             Description = m.Description,
                             ImageUrl = m.ImageUrl,
                             TextContent = m.TextContent,
                             Url = m.Url,
                             OrderBy = m.OrderBy
                        });
                    }
                    ext.Add(e);
                }
            }
            return ext;
        }
        public tb_MaterialAllEntity Populate_tb_MaterialAllEntity_FromDr(IDataReader dr)
        {
            tb_MaterialAllEntity Obj = new tb_MaterialAllEntity();

            Obj.ID = ((dr["ID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["ID"]);
            Obj.UserID = dr["UserID"].ToString();
            Obj.WeiXinCode = dr["WeiXinCode"].ToString();
            Obj.TypeID = ((dr["TypeID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["TypeID"]);
            Obj.Status = ((dr["Status"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["Status"]);
            Obj.AddTime = ((dr["AddTime"]) == DBNull.Value) ? Convert.ToDateTime("1900-1-1") : Convert.ToDateTime(dr["AddTime"]);

            Obj.MaterialID = ((dr["MaterialID"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["MaterialID"]);
            Obj.Title = dr["Title"].ToString();
            Obj.Author = dr["Author"].ToString();
            Obj.Description = dr["Description"].ToString();
            Obj.ImageUrl = dr["ImageUrl"].ToString();
            Obj.TextContent = dr["TextContent"].ToString();
            Obj.Url = dr["Url"].ToString();
            Obj.OrderBy = ((dr["OrderBy"]) == DBNull.Value) ? 0 : Convert.ToInt32(dr["OrderBy"]);

            return Obj;
        }
	}
}
