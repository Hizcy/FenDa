// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_User.cs
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
    /// 数据层实例化接口类 dbo.tb_User.
    /// </summary>
    public partial class tb_UserDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_UserDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_UserModel">tb_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_UserEntity _tb_UserModel)
		{
			string sqlStr="insert into tb_User([UserID],[PWD],[RealName],[Status],[WeiXinCode],[Interface],[Token],[AppID],[AppSecret],[AddTime],[UpdateTime]) values(@UserID,@PWD,@RealName,@Status,@WeiXinCode,@Interface,@Token,@AppID,@AppSecret,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@PWD",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Interface",SqlDbType.VarChar),
			new SqlParameter("@Token",SqlDbType.VarChar),
			new SqlParameter("@AppID",SqlDbType.VarChar),
			new SqlParameter("@AppSecret",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_UserModel.UserID;
			_param[1].Value=_tb_UserModel.PWD;
			_param[2].Value=_tb_UserModel.RealName;
			_param[3].Value=_tb_UserModel.Status;
			_param[4].Value=_tb_UserModel.WeiXinCode;
			_param[5].Value=_tb_UserModel.Interface;
			_param[6].Value=_tb_UserModel.Token;
			_param[7].Value=_tb_UserModel.AppID;
			_param[8].Value=_tb_UserModel.AppSecret;
			_param[9].Value=_tb_UserModel.AddTime;
			_param[10].Value=_tb_UserModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_UserModel">tb_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_UserEntity _tb_UserModel)
		{
			string sqlStr="insert into tb_User([UserID],[PWD],[RealName],[Status],[WeiXinCode],[Interface],[Token],[AppID],[AppSecret],[AddTime],[UpdateTime]) values(@UserID,@PWD,@RealName,@Status,@WeiXinCode,@Interface,@Token,@AppID,@AppSecret,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@PWD",SqlDbType.VarChar),
			new SqlParameter("@RealName",SqlDbType.VarChar),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Interface",SqlDbType.VarChar),
			new SqlParameter("@Token",SqlDbType.VarChar),
			new SqlParameter("@AppID",SqlDbType.VarChar),
			new SqlParameter("@AppSecret",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_UserModel.UserID;
			_param[1].Value=_tb_UserModel.PWD;
			_param[2].Value=_tb_UserModel.RealName;
			_param[3].Value=_tb_UserModel.Status;
			_param[4].Value=_tb_UserModel.WeiXinCode;
			_param[5].Value=_tb_UserModel.Interface;
			_param[6].Value=_tb_UserModel.Token;
			_param[7].Value=_tb_UserModel.AppID;
			_param[8].Value=_tb_UserModel.AppSecret;
			_param[9].Value=_tb_UserModel.AddTime;
			_param[10].Value=_tb_UserModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_User更新一条记录。
		/// </summary>
		/// <param name="_tb_UserModel">_tb_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_UserEntity _tb_UserModel)
		{
            string sqlStr="update tb_User set [UserID]=@UserID,[PWD]=@PWD,[RealName]=@RealName,[Status]=@Status,[WeiXinCode]=@WeiXinCode,[Interface]=@Interface,[Token]=@Token,[AppID]=@AppID,[AppSecret]=@AppSecret,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@PWD",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Interface",SqlDbType.VarChar),
				new SqlParameter("@Token",SqlDbType.VarChar),
				new SqlParameter("@AppID",SqlDbType.VarChar),
				new SqlParameter("@AppSecret",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_UserModel.ID;
				_param[1].Value=_tb_UserModel.UserID;
				_param[2].Value=_tb_UserModel.PWD;
				_param[3].Value=_tb_UserModel.RealName;
				_param[4].Value=_tb_UserModel.Status;
				_param[5].Value=_tb_UserModel.WeiXinCode;
				_param[6].Value=_tb_UserModel.Interface;
				_param[7].Value=_tb_UserModel.Token;
				_param[8].Value=_tb_UserModel.AppID;
				_param[9].Value=_tb_UserModel.AppSecret;
				_param[10].Value=_tb_UserModel.AddTime;
				_param[11].Value=_tb_UserModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_User更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_UserModel">_tb_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_UserEntity _tb_UserModel)
		{
            string sqlStr="update tb_User set [UserID]=@UserID,[PWD]=@PWD,[RealName]=@RealName,[Status]=@Status,[WeiXinCode]=@WeiXinCode,[Interface]=@Interface,[Token]=@Token,[AppID]=@AppID,[AppSecret]=@AppSecret,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@PWD",SqlDbType.VarChar),
				new SqlParameter("@RealName",SqlDbType.VarChar),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Interface",SqlDbType.VarChar),
				new SqlParameter("@Token",SqlDbType.VarChar),
				new SqlParameter("@AppID",SqlDbType.VarChar),
				new SqlParameter("@AppSecret",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_UserModel.ID;
				_param[1].Value=_tb_UserModel.UserID;
				_param[2].Value=_tb_UserModel.PWD;
				_param[3].Value=_tb_UserModel.RealName;
				_param[4].Value=_tb_UserModel.Status;
				_param[5].Value=_tb_UserModel.WeiXinCode;
				_param[6].Value=_tb_UserModel.Interface;
				_param[7].Value=_tb_UserModel.Token;
				_param[8].Value=_tb_UserModel.AppID;
				_param[9].Value=_tb_UserModel.AppSecret;
				_param[10].Value=_tb_UserModel.AddTime;
				_param[11].Value=_tb_UserModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_User中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_User中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_user 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_user 数据实体</returns>
		public tb_UserEntity Populate_tb_UserEntity_FromDr(DataRow row)
		{
			tb_UserEntity Obj = new tb_UserEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID =  row["UserID"].ToString();
				Obj.PWD =  row["PWD"].ToString();
				Obj.RealName =  row["RealName"].ToString();
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.Interface =  row["Interface"].ToString();
				Obj.Token =  row["Token"].ToString();
				Obj.AppID =  row["AppID"].ToString();
				Obj.AppSecret =  row["AppSecret"].ToString();
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
		/// 得到  tb_user 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_user 数据实体</returns>
		public tb_UserEntity Populate_tb_UserEntity_FromDr(IDataReader dr)
		{
			tb_UserEntity Obj = new tb_UserEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID =  dr["UserID"].ToString();
				Obj.PWD =  dr["PWD"].ToString();
				Obj.RealName =  dr["RealName"].ToString();
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.Interface =  dr["Interface"].ToString();
				Obj.Token =  dr["Token"].ToString();
				Obj.AppID =  dr["AppID"].ToString();
				Obj.AppSecret =  dr["AppSecret"].ToString();
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_User对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_User对象</returns>
		public tb_UserEntity Get_tb_UserEntity (int iD)
		{
			tb_UserEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_User with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_UserEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_User所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_UserEntity> Get_tb_UserAll()
		{
			IList< tb_UserEntity> Obj=new List< tb_UserEntity>();
			string sqlStr="select * from tb_User";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_UserEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_User(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_User where ID=@iD";
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
