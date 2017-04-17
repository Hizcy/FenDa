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
using Jnwf.Utils.Data;
using Jnwf.Model;



namespace Jnwf.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_Subscription.
    /// </summary>
    public partial class tb_SubscriptionDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_SubscriptionDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_SubscriptionModel">tb_Subscription实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_SubscriptionEntity _tb_SubscriptionModel)
		{
			string sqlStr="insert into tb_Subscription([UserID],[WeiXinCode],[MaterialID],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@MaterialID,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_SubscriptionModel.UserID;
			_param[1].Value=_tb_SubscriptionModel.WeiXinCode;
			_param[2].Value=_tb_SubscriptionModel.MaterialID;
			_param[3].Value=_tb_SubscriptionModel.AddTime;
			_param[4].Value=_tb_SubscriptionModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_SubscriptionModel">tb_Subscription实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_SubscriptionEntity _tb_SubscriptionModel)
		{
			string sqlStr="insert into tb_Subscription([UserID],[WeiXinCode],[MaterialID],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@MaterialID,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@MaterialID",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_SubscriptionModel.UserID;
			_param[1].Value=_tb_SubscriptionModel.WeiXinCode;
			_param[2].Value=_tb_SubscriptionModel.MaterialID;
			_param[3].Value=_tb_SubscriptionModel.AddTime;
			_param[4].Value=_tb_SubscriptionModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Subscription更新一条记录。
		/// </summary>
		/// <param name="_tb_SubscriptionModel">_tb_SubscriptionModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_SubscriptionEntity _tb_SubscriptionModel)
		{
            string sqlStr="update tb_Subscription set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[MaterialID]=@MaterialID,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_SubscriptionModel.ID;
				_param[1].Value=_tb_SubscriptionModel.UserID;
				_param[2].Value=_tb_SubscriptionModel.WeiXinCode;
				_param[3].Value=_tb_SubscriptionModel.MaterialID;
				_param[4].Value=_tb_SubscriptionModel.AddTime;
				_param[5].Value=_tb_SubscriptionModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Subscription更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_SubscriptionModel">_tb_SubscriptionModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_SubscriptionEntity _tb_SubscriptionModel)
		{
            string sqlStr="update tb_Subscription set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[MaterialID]=@MaterialID,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@MaterialID",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_SubscriptionModel.ID;
				_param[1].Value=_tb_SubscriptionModel.UserID;
				_param[2].Value=_tb_SubscriptionModel.WeiXinCode;
				_param[3].Value=_tb_SubscriptionModel.MaterialID;
				_param[4].Value=_tb_SubscriptionModel.AddTime;
				_param[5].Value=_tb_SubscriptionModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Subscription中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_Subscription where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Subscription中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_Subscription where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_subscription 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_subscription 数据实体</returns>
		public tb_SubscriptionEntity Populate_tb_SubscriptionEntity_FromDr(DataRow row)
		{
			tb_SubscriptionEntity Obj = new tb_SubscriptionEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID =  row["UserID"].ToString();
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
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
		/// 得到  tb_subscription 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_subscription 数据实体</returns>
		public tb_SubscriptionEntity Populate_tb_SubscriptionEntity_FromDr(IDataReader dr)
		{
			tb_SubscriptionEntity Obj = new tb_SubscriptionEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID =  dr["UserID"].ToString();
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.MaterialID = (( dr["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( dr["MaterialID"]);
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Subscription对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_Subscription对象</returns>
		public tb_SubscriptionEntity Get_tb_SubscriptionEntity (int iD)
		{
			tb_SubscriptionEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_Subscription with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_SubscriptionEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Subscription所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_SubscriptionEntity> Get_tb_SubscriptionAll()
		{
			IList< tb_SubscriptionEntity> Obj=new List< tb_SubscriptionEntity>();
			string sqlStr="select * from tb_Subscription";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_SubscriptionEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Subscription(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_Subscription where ID=@iD";
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
