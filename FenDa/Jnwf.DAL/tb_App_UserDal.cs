// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_App_User.cs
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
    /// 数据层实例化接口类 dbo.tb_App_User.
    /// </summary>
    public partial class tb_App_UserDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_App_UserDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_App_UserModel">tb_App_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_App_UserEntity _tb_App_UserModel)
		{
            string sqlStr = "insert into tb_App_User([WeiXinCode],[OpenID],[Status],[AddTime],[UpdateTime],[Recommend]) values(@WeiXinCode,@OpenID,@Status,@AddTime,@UpdateTime,@Recommend) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@OpenID",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime),
			new SqlParameter("@Recommend",SqlDbType.VarChar)
            };			
			_param[0].Value=_tb_App_UserModel.WeiXinCode;
			_param[1].Value=_tb_App_UserModel.OpenID;
			_param[2].Value=_tb_App_UserModel.Status;
			_param[3].Value=_tb_App_UserModel.AddTime;
			_param[4].Value=_tb_App_UserModel.UpdateTime;
            _param[5].Value = _tb_App_UserModel.Recommend;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_App_UserModel">tb_App_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_App_UserEntity _tb_App_UserModel)
		{
            string sqlStr = "insert into tb_App_User([WeiXinCode],[OpenID],[Status],[AddTime],[UpdateTime],[Recommend]) values(@WeiXinCode,@OpenID,@Status,@AddTime,@UpdateTime,@Recommend) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@OpenID",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@Recommend",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_App_UserModel.WeiXinCode;
			_param[1].Value=_tb_App_UserModel.OpenID;
			_param[2].Value=_tb_App_UserModel.Status;
			_param[3].Value=_tb_App_UserModel.AddTime;
			_param[4].Value=_tb_App_UserModel.UpdateTime;
            _param[5].Value = _tb_App_UserModel.Recommend;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_App_User更新一条记录。
		/// </summary>
		/// <param name="_tb_App_UserModel">_tb_App_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_App_UserEntity _tb_App_UserModel)
		{
            string sqlStr = "update tb_App_User set [WeiXinCode]=@WeiXinCode,[OpenID]=@OpenID,[Status]=@Status,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime,[Recommend]=@Recommend where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@OpenID",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@Recommend",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_App_UserModel.ID;
				_param[1].Value=_tb_App_UserModel.WeiXinCode;
				_param[2].Value=_tb_App_UserModel.OpenID;
				_param[3].Value=_tb_App_UserModel.Status;
				_param[4].Value=_tb_App_UserModel.AddTime;
				_param[5].Value=_tb_App_UserModel.UpdateTime;
                _param[6].Value = _tb_App_UserModel.Recommend;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_App_User更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_App_UserModel">_tb_App_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_App_UserEntity _tb_App_UserModel)
		{
            string sqlStr = "update tb_App_User set [WeiXinCode]=@WeiXinCode,[OpenID]=@OpenID,[Status]=@Status,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime,[Recommend]=@Recommend where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@OpenID",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@Recommend",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_App_UserModel.ID;
				_param[1].Value=_tb_App_UserModel.WeiXinCode;
				_param[2].Value=_tb_App_UserModel.OpenID;
				_param[3].Value=_tb_App_UserModel.Status;
				_param[4].Value=_tb_App_UserModel.AddTime;
				_param[5].Value=_tb_App_UserModel.UpdateTime;
                _param[6].Value = _tb_App_UserModel.Recommend;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_App_User中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_App_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_App_User中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_App_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_app_user 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_app_user 数据实体</returns>
		public tb_App_UserEntity Populate_tb_App_UserEntity_FromDr(DataRow row)
		{
			tb_App_UserEntity Obj = new tb_App_UserEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.OpenID =  row["OpenID"].ToString();
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.AddTime = (( row["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["AddTime"]);
				Obj.UpdateTime = (( row["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["UpdateTime"]);
                Obj.Recommend = row["Recommend"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_app_user 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_app_user 数据实体</returns>
		public tb_App_UserEntity Populate_tb_App_UserEntity_FromDr(IDataReader dr)
		{
			tb_App_UserEntity Obj = new tb_App_UserEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.OpenID =  dr["OpenID"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
                Obj.Recommend = dr["Recommend"].ToString();

			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_App_User对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_App_User对象</returns>
		public tb_App_UserEntity Get_tb_App_UserEntity (int iD)
		{
			tb_App_UserEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_App_User with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_App_UserEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_App_User所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_App_UserEntity> Get_tb_App_UserAll()
		{
			IList< tb_App_UserEntity> Obj=new List< tb_App_UserEntity>();
			string sqlStr="select * from tb_App_User";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_App_UserEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_App_User(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_App_User where ID=@iD";
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
