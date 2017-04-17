// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_OpenID_User.cs
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
    /// 数据层实例化接口类 dbo.tb_OpenID_User.
    /// </summary>
    public partial class tb_OpenID_UserDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_OpenID_UserDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_OpenID_UserModel">tb_OpenID_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_OpenID_UserEntity _tb_OpenID_UserModel)
		{
			string sqlStr="insert into tb_OpenID_User([OpenID],[NickName],[Sex],[City],[Country],[Province],[Language],[HeadImgurl],[LoginName],[LoginPwd]) values(@OpenID,@NickName,@Sex,@City,@Country,@Province,@Language,@HeadImgurl,@LoginName,@LoginPwd) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@OpenID",SqlDbType.VarChar),
			new SqlParameter("@NickName",SqlDbType.VarChar),
			new SqlParameter("@Sex",SqlDbType.Int),
			new SqlParameter("@City",SqlDbType.VarChar),
			new SqlParameter("@Country",SqlDbType.VarChar),
			new SqlParameter("@Province",SqlDbType.VarChar),
			new SqlParameter("@Language",SqlDbType.VarChar),
			new SqlParameter("@HeadImgurl",SqlDbType.VarChar),
			new SqlParameter("@LoginName",SqlDbType.VarChar),
			new SqlParameter("@LoginPwd",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_OpenID_UserModel.OpenID;
			_param[1].Value=_tb_OpenID_UserModel.NickName;
			_param[2].Value=_tb_OpenID_UserModel.Sex;
			_param[3].Value=_tb_OpenID_UserModel.City;
			_param[4].Value=_tb_OpenID_UserModel.Country;
			_param[5].Value=_tb_OpenID_UserModel.Province;
			_param[6].Value=_tb_OpenID_UserModel.Language;
			_param[7].Value=_tb_OpenID_UserModel.HeadImgurl;
			_param[8].Value=_tb_OpenID_UserModel.LoginName;
			_param[9].Value=_tb_OpenID_UserModel.LoginPwd;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_OpenID_UserModel">tb_OpenID_User实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_OpenID_UserEntity _tb_OpenID_UserModel)
		{
			string sqlStr="insert into tb_OpenID_User([OpenID],[NickName],[Sex],[City],[Country],[Province],[Language],[HeadImgurl],[LoginName],[LoginPwd]) values(@OpenID,@NickName,@Sex,@City,@Country,@Province,@Language,@HeadImgurl,@LoginName,@LoginPwd) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@OpenID",SqlDbType.VarChar),
			new SqlParameter("@NickName",SqlDbType.VarChar),
			new SqlParameter("@Sex",SqlDbType.Int),
			new SqlParameter("@City",SqlDbType.VarChar),
			new SqlParameter("@Country",SqlDbType.VarChar),
			new SqlParameter("@Province",SqlDbType.VarChar),
			new SqlParameter("@Language",SqlDbType.VarChar),
			new SqlParameter("@HeadImgurl",SqlDbType.VarChar),
			new SqlParameter("@LoginName",SqlDbType.VarChar),
			new SqlParameter("@LoginPwd",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_OpenID_UserModel.OpenID;
			_param[1].Value=_tb_OpenID_UserModel.NickName;
			_param[2].Value=_tb_OpenID_UserModel.Sex;
			_param[3].Value=_tb_OpenID_UserModel.City;
			_param[4].Value=_tb_OpenID_UserModel.Country;
			_param[5].Value=_tb_OpenID_UserModel.Province;
			_param[6].Value=_tb_OpenID_UserModel.Language;
			_param[7].Value=_tb_OpenID_UserModel.HeadImgurl;
			_param[8].Value=_tb_OpenID_UserModel.LoginName;
			_param[9].Value=_tb_OpenID_UserModel.LoginPwd;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_OpenID_User更新一条记录。
		/// </summary>
		/// <param name="_tb_OpenID_UserModel">_tb_OpenID_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_OpenID_UserEntity _tb_OpenID_UserModel)
		{
            string sqlStr="update tb_OpenID_User set [OpenID]=@OpenID,[NickName]=@NickName,[Sex]=@Sex,[City]=@City,[Country]=@Country,[Province]=@Province,[Language]=@Language,[HeadImgurl]=@HeadImgurl,[LoginName]=@LoginName,[LoginPwd]=@LoginPwd where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@OpenID",SqlDbType.VarChar),
				new SqlParameter("@NickName",SqlDbType.VarChar),
				new SqlParameter("@Sex",SqlDbType.Int),
				new SqlParameter("@City",SqlDbType.VarChar),
				new SqlParameter("@Country",SqlDbType.VarChar),
				new SqlParameter("@Province",SqlDbType.VarChar),
				new SqlParameter("@Language",SqlDbType.VarChar),
				new SqlParameter("@HeadImgurl",SqlDbType.VarChar),
				new SqlParameter("@LoginName",SqlDbType.VarChar),
				new SqlParameter("@LoginPwd",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_OpenID_UserModel.ID;
				_param[1].Value=_tb_OpenID_UserModel.OpenID;
				_param[2].Value=_tb_OpenID_UserModel.NickName;
				_param[3].Value=_tb_OpenID_UserModel.Sex;
				_param[4].Value=_tb_OpenID_UserModel.City;
				_param[5].Value=_tb_OpenID_UserModel.Country;
				_param[6].Value=_tb_OpenID_UserModel.Province;
				_param[7].Value=_tb_OpenID_UserModel.Language;
				_param[8].Value=_tb_OpenID_UserModel.HeadImgurl;
				_param[9].Value=_tb_OpenID_UserModel.LoginName;
				_param[10].Value=_tb_OpenID_UserModel.LoginPwd;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_OpenID_User更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_OpenID_UserModel">_tb_OpenID_UserModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_OpenID_UserEntity _tb_OpenID_UserModel)
		{
            string sqlStr="update tb_OpenID_User set [OpenID]=@OpenID,[NickName]=@NickName,[Sex]=@Sex,[City]=@City,[Country]=@Country,[Province]=@Province,[Language]=@Language,[HeadImgurl]=@HeadImgurl,[LoginName]=@LoginName,[LoginPwd]=@LoginPwd where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@OpenID",SqlDbType.VarChar),
				new SqlParameter("@NickName",SqlDbType.VarChar),
				new SqlParameter("@Sex",SqlDbType.Int),
				new SqlParameter("@City",SqlDbType.VarChar),
				new SqlParameter("@Country",SqlDbType.VarChar),
				new SqlParameter("@Province",SqlDbType.VarChar),
				new SqlParameter("@Language",SqlDbType.VarChar),
				new SqlParameter("@HeadImgurl",SqlDbType.VarChar),
				new SqlParameter("@LoginName",SqlDbType.VarChar),
				new SqlParameter("@LoginPwd",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_OpenID_UserModel.ID;
				_param[1].Value=_tb_OpenID_UserModel.OpenID;
				_param[2].Value=_tb_OpenID_UserModel.NickName;
				_param[3].Value=_tb_OpenID_UserModel.Sex;
				_param[4].Value=_tb_OpenID_UserModel.City;
				_param[5].Value=_tb_OpenID_UserModel.Country;
				_param[6].Value=_tb_OpenID_UserModel.Province;
				_param[7].Value=_tb_OpenID_UserModel.Language;
				_param[8].Value=_tb_OpenID_UserModel.HeadImgurl;
				_param[9].Value=_tb_OpenID_UserModel.LoginName;
				_param[10].Value=_tb_OpenID_UserModel.LoginPwd;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_OpenID_User中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_OpenID_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_OpenID_User中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_OpenID_User where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_openid_user 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_openid_user 数据实体</returns>
		public tb_OpenID_UserEntity Populate_tb_OpenID_UserEntity_FromDr(DataRow row)
		{
			tb_OpenID_UserEntity Obj = new tb_OpenID_UserEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.OpenID =  row["OpenID"].ToString();
				Obj.NickName =  row["NickName"].ToString();
				Obj.Sex = (( row["Sex"])==DBNull.Value)?0:Convert.ToInt32( row["Sex"]);
				Obj.City =  row["City"].ToString();
				Obj.Country =  row["Country"].ToString();
				Obj.Province =  row["Province"].ToString();
				Obj.Language =  row["Language"].ToString();
				Obj.HeadImgurl =  row["HeadImgurl"].ToString();
				Obj.LoginName =  row["LoginName"].ToString();
				Obj.LoginPwd =  row["LoginPwd"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_openid_user 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_openid_user 数据实体</returns>
		public tb_OpenID_UserEntity Populate_tb_OpenID_UserEntity_FromDr(IDataReader dr)
		{
			tb_OpenID_UserEntity Obj = new tb_OpenID_UserEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.OpenID =  dr["OpenID"].ToString();
				Obj.NickName =  dr["NickName"].ToString();
				Obj.Sex = (( dr["Sex"])==DBNull.Value)?0:Convert.ToInt32( dr["Sex"]);
				Obj.City =  dr["City"].ToString();
				Obj.Country =  dr["Country"].ToString();
				Obj.Province =  dr["Province"].ToString();
				Obj.Language =  dr["Language"].ToString();
				Obj.HeadImgurl =  dr["HeadImgurl"].ToString();
				Obj.LoginName =  dr["LoginName"].ToString();
				Obj.LoginPwd =  dr["LoginPwd"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_OpenID_User对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_OpenID_User对象</returns>
		public tb_OpenID_UserEntity Get_tb_OpenID_UserEntity (int iD)
		{
			tb_OpenID_UserEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_OpenID_User with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_OpenID_UserEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_OpenID_User所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_OpenID_UserEntity> Get_tb_OpenID_UserAll()
		{
			IList< tb_OpenID_UserEntity> Obj=new List< tb_OpenID_UserEntity>();
			string sqlStr="select * from tb_OpenID_User";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_OpenID_UserEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_OpenID_User(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_OpenID_User where ID=@iD";
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
