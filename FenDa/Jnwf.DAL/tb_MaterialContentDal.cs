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
using Jnwf.Utils.Data;
using Jnwf.Model;



namespace Jnwf.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_MaterialContent.
    /// </summary>
    public partial class tb_MaterialContentDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_MaterialContentDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_MaterialContentModel">tb_MaterialContent实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_MaterialContentEntity _tb_MaterialContentModel)
		{
			string sqlStr="insert into tb_MaterialContent([MaterialID],[Title],[Author],[Description],[ImageUrl],[TextContent],[Url],[OrderBy]) values(@MaterialID,@Title,@Author,@Description,@ImageUrl,@TextContent,@Url,@OrderBy) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@Author",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@ImageUrl",SqlDbType.VarChar),
			new SqlParameter("@TextContent",SqlDbType.VarChar),
			new SqlParameter("@Url",SqlDbType.VarChar),
			new SqlParameter("@OrderBy",SqlDbType.Int)
			};			
			_param[0].Value=_tb_MaterialContentModel.MaterialID;
			_param[1].Value=_tb_MaterialContentModel.Title;
			_param[2].Value=_tb_MaterialContentModel.Author;
			_param[3].Value=_tb_MaterialContentModel.Description;
			_param[4].Value=_tb_MaterialContentModel.ImageUrl;
			_param[5].Value=_tb_MaterialContentModel.TextContent;
			_param[6].Value=_tb_MaterialContentModel.Url;
			_param[7].Value=_tb_MaterialContentModel.OrderBy;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_MaterialContentModel">tb_MaterialContent实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_MaterialContentEntity _tb_MaterialContentModel)
		{
			string sqlStr="insert into tb_MaterialContent([MaterialID],[Title],[Author],[Description],[ImageUrl],[TextContent],[Url],[OrderBy]) values(@MaterialID,@Title,@Author,@Description,@ImageUrl,@TextContent,@Url,@OrderBy) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@Author",SqlDbType.VarChar),
			new SqlParameter("@Description",SqlDbType.VarChar),
			new SqlParameter("@ImageUrl",SqlDbType.VarChar),
			new SqlParameter("@TextContent",SqlDbType.VarChar),
			new SqlParameter("@Url",SqlDbType.VarChar),
			new SqlParameter("@OrderBy",SqlDbType.Int)
			};			
			_param[0].Value=_tb_MaterialContentModel.MaterialID;
			_param[1].Value=_tb_MaterialContentModel.Title;
			_param[2].Value=_tb_MaterialContentModel.Author;
			_param[3].Value=_tb_MaterialContentModel.Description;
			_param[4].Value=_tb_MaterialContentModel.ImageUrl;
			_param[5].Value=_tb_MaterialContentModel.TextContent;
			_param[6].Value=_tb_MaterialContentModel.Url;
			_param[7].Value=_tb_MaterialContentModel.OrderBy;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_MaterialContent更新一条记录。
		/// </summary>
		/// <param name="_tb_MaterialContentModel">_tb_MaterialContentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_MaterialContentEntity _tb_MaterialContentModel)
		{
            string sqlStr="update tb_MaterialContent set [MaterialID]=@MaterialID,[Title]=@Title,[Author]=@Author,[Description]=@Description,[ImageUrl]=@ImageUrl,[TextContent]=@TextContent,[Url]=@Url,[OrderBy]=@OrderBy where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@Author",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@ImageUrl",SqlDbType.VarChar),
				new SqlParameter("@TextContent",SqlDbType.VarChar),
				new SqlParameter("@Url",SqlDbType.VarChar),
				new SqlParameter("@OrderBy",SqlDbType.Int)
				};				
				_param[0].Value=_tb_MaterialContentModel.ID;
				_param[1].Value=_tb_MaterialContentModel.MaterialID;
				_param[2].Value=_tb_MaterialContentModel.Title;
				_param[3].Value=_tb_MaterialContentModel.Author;
				_param[4].Value=_tb_MaterialContentModel.Description;
				_param[5].Value=_tb_MaterialContentModel.ImageUrl;
				_param[6].Value=_tb_MaterialContentModel.TextContent;
				_param[7].Value=_tb_MaterialContentModel.Url;
				_param[8].Value=_tb_MaterialContentModel.OrderBy;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_MaterialContent更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_MaterialContentModel">_tb_MaterialContentModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_MaterialContentEntity _tb_MaterialContentModel)
		{
            string sqlStr="update tb_MaterialContent set [MaterialID]=@MaterialID,[Title]=@Title,[Author]=@Author,[Description]=@Description,[ImageUrl]=@ImageUrl,[TextContent]=@TextContent,[Url]=@Url,[OrderBy]=@OrderBy where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@Author",SqlDbType.VarChar),
				new SqlParameter("@Description",SqlDbType.VarChar),
				new SqlParameter("@ImageUrl",SqlDbType.VarChar),
				new SqlParameter("@TextContent",SqlDbType.VarChar),
				new SqlParameter("@Url",SqlDbType.VarChar),
				new SqlParameter("@OrderBy",SqlDbType.Int)
				};				
				_param[0].Value=_tb_MaterialContentModel.ID;
				_param[1].Value=_tb_MaterialContentModel.MaterialID;
				_param[2].Value=_tb_MaterialContentModel.Title;
				_param[3].Value=_tb_MaterialContentModel.Author;
				_param[4].Value=_tb_MaterialContentModel.Description;
				_param[5].Value=_tb_MaterialContentModel.ImageUrl;
				_param[6].Value=_tb_MaterialContentModel.TextContent;
				_param[7].Value=_tb_MaterialContentModel.Url;
				_param[8].Value=_tb_MaterialContentModel.OrderBy;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_MaterialContent中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_MaterialContent where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_MaterialContent中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_MaterialContent where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_materialcontent 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_materialcontent 数据实体</returns>
		public tb_MaterialContentEntity Populate_tb_MaterialContentEntity_FromDr(DataRow row)
		{
			tb_MaterialContentEntity Obj = new tb_MaterialContentEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.MaterialID = (( row["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( row["MaterialID"]);
				Obj.Title =  row["Title"].ToString();
				Obj.Author =  row["Author"].ToString();
				Obj.Description =  row["Description"].ToString();
				Obj.ImageUrl =  row["ImageUrl"].ToString();
				Obj.TextContent =  row["TextContent"].ToString();
				Obj.Url =  row["Url"].ToString();
				Obj.OrderBy = (( row["OrderBy"])==DBNull.Value)?1:Convert.ToInt32( row["OrderBy"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_materialcontent 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_materialcontent 数据实体</returns>
		public tb_MaterialContentEntity Populate_tb_MaterialContentEntity_FromDr(IDataReader dr)
		{
			tb_MaterialContentEntity Obj = new tb_MaterialContentEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.MaterialID = (( dr["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( dr["MaterialID"]);
				Obj.Title =  dr["Title"].ToString();
				Obj.Author =  dr["Author"].ToString();
				Obj.Description =  dr["Description"].ToString();
				Obj.ImageUrl =  dr["ImageUrl"].ToString();
				Obj.TextContent =  dr["TextContent"].ToString();
				Obj.Url =  dr["Url"].ToString();
				Obj.OrderBy = (( dr["OrderBy"])==DBNull.Value)?0:Convert.ToInt32( dr["OrderBy"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_MaterialContent对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_MaterialContent对象</returns>
		public tb_MaterialContentEntity Get_tb_MaterialContentEntity (int iD)
		{
			tb_MaterialContentEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_MaterialContent with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_MaterialContentEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_MaterialContent所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_MaterialContentEntity> Get_tb_MaterialContentAll()
		{
			IList< tb_MaterialContentEntity> Obj=new List< tb_MaterialContentEntity>();
			string sqlStr="select * from tb_MaterialContent";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_MaterialContentEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_MaterialContent(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_MaterialContent where ID=@iD";
            int a=Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
            if(a>0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        #endregion
		
		#region----------自定义实例化接口函数----------
		#endregion
    }
}
