// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Log.cs
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
    /// 数据层实例化接口类 dbo.tb_Log.
    /// </summary>
    public partial class tb_LogDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_LogDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_LogModel">tb_Log实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_LogEntity _tb_LogModel)
		{
			string sqlStr="insert into tb_Log([TypeID],[Title],[LogContent],[AddTime]) values(@TypeID,@Title,@LogContent,@AddTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@TypeID",SqlDbType.VarChar),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@LogContent",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_LogModel.TypeID;
			_param[1].Value=_tb_LogModel.Title;
			_param[2].Value=_tb_LogModel.LogContent;
			_param[3].Value=_tb_LogModel.AddTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_LogModel">tb_Log实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_LogEntity _tb_LogModel)
		{
			string sqlStr="insert into tb_Log([TypeID],[Title],[LogContent],[AddTime]) values(@TypeID,@Title,@LogContent,@AddTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@TypeID",SqlDbType.VarChar),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@LogContent",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_LogModel.TypeID;
			_param[1].Value=_tb_LogModel.Title;
			_param[2].Value=_tb_LogModel.LogContent;
			_param[3].Value=_tb_LogModel.AddTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Log更新一条记录。
		/// </summary>
		/// <param name="_tb_LogModel">_tb_LogModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_LogEntity _tb_LogModel)
		{
            string sqlStr="update tb_Log set [TypeID]=@TypeID,[Title]=@Title,[LogContent]=@LogContent,[AddTime]=@AddTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@TypeID",SqlDbType.VarChar),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@LogContent",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_LogModel.ID;
				_param[1].Value=_tb_LogModel.TypeID;
				_param[2].Value=_tb_LogModel.Title;
				_param[3].Value=_tb_LogModel.LogContent;
				_param[4].Value=_tb_LogModel.AddTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Log更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_LogModel">_tb_LogModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_LogEntity _tb_LogModel)
		{
            string sqlStr="update tb_Log set [TypeID]=@TypeID,[Title]=@Title,[LogContent]=@LogContent,[AddTime]=@AddTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@TypeID",SqlDbType.VarChar),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@LogContent",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_LogModel.ID;
				_param[1].Value=_tb_LogModel.TypeID;
				_param[2].Value=_tb_LogModel.Title;
				_param[3].Value=_tb_LogModel.LogContent;
				_param[4].Value=_tb_LogModel.AddTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Log中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_Log where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Log中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_Log where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_log 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_log 数据实体</returns>
		public tb_LogEntity Populate_tb_LogEntity_FromDr(DataRow row)
		{
			tb_LogEntity Obj = new tb_LogEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.TypeID =  row["TypeID"].ToString();
				Obj.Title =  row["Title"].ToString();
				Obj.LogContent =  row["LogContent"].ToString();
				Obj.AddTime = (( row["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["AddTime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_log 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_log 数据实体</returns>
		public tb_LogEntity Populate_tb_LogEntity_FromDr(IDataReader dr)
		{
			tb_LogEntity Obj = new tb_LogEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.TypeID =  dr["TypeID"].ToString();
				Obj.Title =  dr["Title"].ToString();
				Obj.LogContent =  dr["LogContent"].ToString();
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Log对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_Log对象</returns>
		public tb_LogEntity Get_tb_LogEntity (int iD)
		{
			tb_LogEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_Log with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_LogEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Log所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_LogEntity> Get_tb_LogAll()
		{
			IList< tb_LogEntity> Obj=new List< tb_LogEntity>();
			string sqlStr="select * from tb_Log";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_LogEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Log(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_Log where ID=@iD";
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
