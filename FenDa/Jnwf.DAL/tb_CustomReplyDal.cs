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
using Jnwf.Utils.Data;
using Jnwf.Model;



namespace Jnwf.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_CustomReply.
    /// </summary>
    public partial class tb_CustomReplyDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_CustomReplyDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_CustomReplyModel">tb_CustomReply实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_CustomReplyEntity _tb_CustomReplyModel)
		{
			string sqlStr="insert into tb_CustomReply([UserID],[WeiXinCode],[Keyword],[MatchingTypeID],[ReplyTypeID],[MaterialID],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@Keyword,@MatchingTypeID,@ReplyTypeID,@MaterialID,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Keyword",SqlDbType.VarChar),
			new SqlParameter("@MatchingTypeID",SqlDbType.Int),
			new SqlParameter("@ReplyTypeID",SqlDbType.Int),
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_CustomReplyModel.UserID;
			_param[1].Value=_tb_CustomReplyModel.WeiXinCode;
			_param[2].Value=_tb_CustomReplyModel.Keyword;
			_param[3].Value=_tb_CustomReplyModel.MatchingTypeID;
			_param[4].Value=_tb_CustomReplyModel.ReplyTypeID;
			_param[5].Value=_tb_CustomReplyModel.MaterialID;
			_param[6].Value=_tb_CustomReplyModel.AddTime;
			_param[7].Value=_tb_CustomReplyModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_CustomReplyModel">tb_CustomReply实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_CustomReplyEntity _tb_CustomReplyModel)
		{
			string sqlStr="insert into tb_CustomReply([UserID],[WeiXinCode],[Keyword],[MatchingTypeID],[ReplyTypeID],[MaterialID],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@Keyword,@MatchingTypeID,@ReplyTypeID,@MaterialID,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Keyword",SqlDbType.VarChar),
			new SqlParameter("@MatchingTypeID",SqlDbType.Int),
			new SqlParameter("@ReplyTypeID",SqlDbType.Int),
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_CustomReplyModel.UserID;
			_param[1].Value=_tb_CustomReplyModel.WeiXinCode;
			_param[2].Value=_tb_CustomReplyModel.Keyword;
			_param[3].Value=_tb_CustomReplyModel.MatchingTypeID;
			_param[4].Value=_tb_CustomReplyModel.ReplyTypeID;
			_param[5].Value=_tb_CustomReplyModel.MaterialID;
			_param[6].Value=_tb_CustomReplyModel.AddTime;
			_param[7].Value=_tb_CustomReplyModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_CustomReply更新一条记录。
		/// </summary>
		/// <param name="_tb_CustomReplyModel">_tb_CustomReplyModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_CustomReplyEntity _tb_CustomReplyModel)
		{
            string sqlStr="update tb_CustomReply set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[Keyword]=@Keyword,[MatchingTypeID]=@MatchingTypeID,[ReplyTypeID]=@ReplyTypeID,[MaterialID]=@MaterialID,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Keyword",SqlDbType.VarChar),
				new SqlParameter("@MatchingTypeID",SqlDbType.Int),
				new SqlParameter("@ReplyTypeID",SqlDbType.Int),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_CustomReplyModel.ID;
				_param[1].Value=_tb_CustomReplyModel.UserID;
				_param[2].Value=_tb_CustomReplyModel.WeiXinCode;
				_param[3].Value=_tb_CustomReplyModel.Keyword;
				_param[4].Value=_tb_CustomReplyModel.MatchingTypeID;
				_param[5].Value=_tb_CustomReplyModel.ReplyTypeID;
				_param[6].Value=_tb_CustomReplyModel.MaterialID;
				_param[7].Value=_tb_CustomReplyModel.AddTime;
				_param[8].Value=_tb_CustomReplyModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_CustomReply更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_CustomReplyModel">_tb_CustomReplyModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_CustomReplyEntity _tb_CustomReplyModel)
		{
            string sqlStr="update tb_CustomReply set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[Keyword]=@Keyword,[MatchingTypeID]=@MatchingTypeID,[ReplyTypeID]=@ReplyTypeID,[MaterialID]=@MaterialID,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Keyword",SqlDbType.VarChar),
				new SqlParameter("@MatchingTypeID",SqlDbType.Int),
				new SqlParameter("@ReplyTypeID",SqlDbType.Int),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_CustomReplyModel.ID;
				_param[1].Value=_tb_CustomReplyModel.UserID;
				_param[2].Value=_tb_CustomReplyModel.WeiXinCode;
				_param[3].Value=_tb_CustomReplyModel.Keyword;
				_param[4].Value=_tb_CustomReplyModel.MatchingTypeID;
				_param[5].Value=_tb_CustomReplyModel.ReplyTypeID;
				_param[6].Value=_tb_CustomReplyModel.MaterialID;
				_param[7].Value=_tb_CustomReplyModel.AddTime;
				_param[8].Value=_tb_CustomReplyModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_CustomReply中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_CustomReply where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_CustomReply中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_CustomReply where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_customreply 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_customreply 数据实体</returns>
		public tb_CustomReplyEntity Populate_tb_CustomReplyEntity_FromDr(DataRow row)
		{
			tb_CustomReplyEntity Obj = new tb_CustomReplyEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID =  row["UserID"].ToString();
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.Keyword =  row["Keyword"].ToString();
				Obj.MatchingTypeID = (( row["MatchingTypeID"])==DBNull.Value)?0:Convert.ToInt32( row["MatchingTypeID"]);
				Obj.ReplyTypeID = (( row["ReplyTypeID"])==DBNull.Value)?0:Convert.ToInt32( row["ReplyTypeID"]);
				Obj.MaterialID = (( row["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( row["MaterialID"]);
				Obj.AddTime = (( row["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["AddTime"]);
				Obj.UpdateTime = (( row["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["UpdateTime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_customreply 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_customreply 数据实体</returns>
		public tb_CustomReplyEntity Populate_tb_CustomReplyEntity_FromDr(IDataReader dr)
		{
			tb_CustomReplyEntity Obj = new tb_CustomReplyEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID =  dr["UserID"].ToString();
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.Keyword =  dr["Keyword"].ToString();
				Obj.MatchingTypeID = (( dr["MatchingTypeID"])==DBNull.Value)?0:Convert.ToInt32( dr["MatchingTypeID"]);
				Obj.ReplyTypeID = (( dr["ReplyTypeID"])==DBNull.Value)?0:Convert.ToInt32( dr["ReplyTypeID"]);
				Obj.MaterialID = (( dr["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( dr["MaterialID"]);
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_CustomReply对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_CustomReply对象</returns>
		public tb_CustomReplyEntity Get_tb_CustomReplyEntity (int iD)
		{
			tb_CustomReplyEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_CustomReply with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_CustomReplyEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_CustomReply所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_CustomReplyEntity> Get_tb_CustomReplyAll()
		{
			IList< tb_CustomReplyEntity> Obj=new List< tb_CustomReplyEntity>();
			string sqlStr="select * from tb_CustomReply";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_CustomReplyEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_CustomReply(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_CustomReply where ID=@iD";
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
