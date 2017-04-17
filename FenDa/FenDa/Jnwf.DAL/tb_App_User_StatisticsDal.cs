// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_App_User_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/6/26
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
    /// 数据层实例化接口类 dbo.tb_App_User_Statistics.
    /// </summary>
    public partial class tb_App_User_StatisticsDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_App_User_StatisticsDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_App_User_StatisticsModel">tb_App_User_Statistics实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_App_User_StatisticsEntity _tb_App_User_StatisticsModel)
		{
			string sqlStr="insert into tb_App_User_Statistics([Date],[WeiXinCode],[CurrentCount],[AddCount],[SubCount]) values(@Date,@WeiXinCode,@CurrentCount,@AddCount,@SubCount) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Date",SqlDbType.DateTime),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@CurrentCount",SqlDbType.Int),
			new SqlParameter("@AddCount",SqlDbType.Int),
			new SqlParameter("@SubCount",SqlDbType.Int)
			};			
			_param[0].Value=_tb_App_User_StatisticsModel.Date;
			_param[1].Value=_tb_App_User_StatisticsModel.WeiXinCode;
			_param[2].Value=_tb_App_User_StatisticsModel.CurrentCount;
			_param[3].Value=_tb_App_User_StatisticsModel.AddCount;
			_param[4].Value=_tb_App_User_StatisticsModel.SubCount;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_App_User_StatisticsModel">tb_App_User_Statistics实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_App_User_StatisticsEntity _tb_App_User_StatisticsModel)
		{
			string sqlStr="insert into tb_App_User_Statistics([Date],[WeiXinCode],[CurrentCount],[AddCount],[SubCount]) values(@Date,@WeiXinCode,@CurrentCount,@AddCount,@SubCount) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@Date",SqlDbType.DateTime),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@CurrentCount",SqlDbType.Int),
			new SqlParameter("@AddCount",SqlDbType.Int),
			new SqlParameter("@SubCount",SqlDbType.Int)
			};			
			_param[0].Value=_tb_App_User_StatisticsModel.Date;
			_param[1].Value=_tb_App_User_StatisticsModel.WeiXinCode;
			_param[2].Value=_tb_App_User_StatisticsModel.CurrentCount;
			_param[3].Value=_tb_App_User_StatisticsModel.AddCount;
			_param[4].Value=_tb_App_User_StatisticsModel.SubCount;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_App_User_Statistics更新一条记录。
		/// </summary>
		/// <param name="_tb_App_User_StatisticsModel">_tb_App_User_StatisticsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_App_User_StatisticsEntity _tb_App_User_StatisticsModel)
		{
            string sqlStr="update tb_App_User_Statistics set [Date]=@Date,[WeiXinCode]=@WeiXinCode,[CurrentCount]=@CurrentCount,[AddCount]=@AddCount,[SubCount]=@SubCount where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@Date",SqlDbType.DateTime),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@CurrentCount",SqlDbType.Int),
				new SqlParameter("@AddCount",SqlDbType.Int),
				new SqlParameter("@SubCount",SqlDbType.Int)
				};				
				_param[0].Value=_tb_App_User_StatisticsModel.Id;
				_param[1].Value=_tb_App_User_StatisticsModel.Date;
				_param[2].Value=_tb_App_User_StatisticsModel.WeiXinCode;
				_param[3].Value=_tb_App_User_StatisticsModel.CurrentCount;
				_param[4].Value=_tb_App_User_StatisticsModel.AddCount;
				_param[5].Value=_tb_App_User_StatisticsModel.SubCount;
                return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW, CommandType.Text, sqlStr, _param);
		}
		/// <summary>
		/// 向数据表tb_App_User_Statistics更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_App_User_StatisticsModel">_tb_App_User_StatisticsModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_App_User_StatisticsEntity _tb_App_User_StatisticsModel)
		{
            string sqlStr="update tb_App_User_Statistics set [Date]=@Date,[WeiXinCode]=@WeiXinCode,[CurrentCount]=@CurrentCount,[AddCount]=@AddCount,[SubCount]=@SubCount where Id=@Id";
			SqlParameter[] _param={				
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@Date",SqlDbType.DateTime),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@CurrentCount",SqlDbType.Int),
				new SqlParameter("@AddCount",SqlDbType.Int),
				new SqlParameter("@SubCount",SqlDbType.Int)
				};				
				_param[0].Value=_tb_App_User_StatisticsModel.Id;
				_param[1].Value=_tb_App_User_StatisticsModel.Date;
				_param[2].Value=_tb_App_User_StatisticsModel.WeiXinCode;
				_param[3].Value=_tb_App_User_StatisticsModel.CurrentCount;
				_param[4].Value=_tb_App_User_StatisticsModel.AddCount;
				_param[5].Value=_tb_App_User_StatisticsModel.SubCount;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_App_User_Statistics中的一条记录
		/// </summary>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(int Id)
		{
			string sqlStr="delete from tb_App_User_Statistics where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
            return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW, CommandType.Text, sqlStr, _param);
		}
		
		/// <summary>
		/// 删除数据表tb_App_User_Statistics中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="Id">id</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int Id)
		{
			string sqlStr="delete from tb_App_User_Statistics where [Id]=@Id";
			SqlParameter[] _param={			
			new SqlParameter("@Id",SqlDbType.Int),
			
			};			
			_param[0].Value=Id;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_app_user_statistics 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_app_user_statistics 数据实体</returns>
		public tb_App_User_StatisticsEntity Populate_tb_App_User_StatisticsEntity_FromDr(DataRow row)
		{
			tb_App_User_StatisticsEntity Obj = new tb_App_User_StatisticsEntity();
			if(row!=null)
			{
				Obj.Id = (( row["Id"])==DBNull.Value)?0:Convert.ToInt32( row["Id"]);
				Obj.Date = (( row["Date"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["Date"]);
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.CurrentCount = (( row["CurrentCount"])==DBNull.Value)?0:Convert.ToInt32( row["CurrentCount"]);
				Obj.AddCount = (( row["AddCount"])==DBNull.Value)?0:Convert.ToInt32( row["AddCount"]);
				Obj.SubCount = (( row["SubCount"])==DBNull.Value)?0:Convert.ToInt32( row["SubCount"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_app_user_statistics 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_app_user_statistics 数据实体</returns>
		public tb_App_User_StatisticsEntity Populate_tb_App_User_StatisticsEntity_FromDr(IDataReader dr)
		{
			tb_App_User_StatisticsEntity Obj = new tb_App_User_StatisticsEntity();
			
				Obj.Id = (( dr["Id"])==DBNull.Value)?0:Convert.ToInt32( dr["Id"]);
				Obj.Date = (( dr["Date"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["Date"]);
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.CurrentCount = (( dr["CurrentCount"])==DBNull.Value)?0:Convert.ToInt32( dr["CurrentCount"]);
				Obj.AddCount = (( dr["AddCount"])==DBNull.Value)?0:Convert.ToInt32( dr["AddCount"]);
				Obj.SubCount = (( dr["SubCount"])==DBNull.Value)?0:Convert.ToInt32( dr["SubCount"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_App_User_Statistics对象
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>tb_App_User_Statistics对象</returns>
		public tb_App_User_StatisticsEntity Get_tb_App_User_StatisticsEntity (int id)
		{
			tb_App_User_StatisticsEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@Id",SqlDbType.Int)
			};
			_param[0].Value=id;
			string sqlStr="select * from tb_App_User_Statistics with(nolock) where Id=@Id";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr, _param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_App_User_StatisticsEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_App_User_Statistics所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_App_User_StatisticsEntity> Get_tb_App_User_StatisticsAll()
		{
			IList< tb_App_User_StatisticsEntity> Obj=new List< tb_App_User_StatisticsEntity>();
			string sqlStr="select * from tb_App_User_Statistics";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(WebConfig.weixinRW, CommandType.Text, sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_App_User_StatisticsEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_App_User_Statistics(int id)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@id",SqlDbType.Int)
                                  };
            _param[0].Value=id;
            string sqlStr="select Count(*) from tb_App_User_Statistics where Id=@id";
            int a = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW, CommandType.Text, sqlStr, _param));
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
