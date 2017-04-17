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
using Jnwf.Utils.Data;
using Jnwf.Model;



namespace Jnwf.DAL 
{
    /// <summary>
    /// 数据层实例化接口类 dbo.tb_Material.
    /// </summary>
    public partial class tb_MaterialDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_MaterialDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_MaterialModel">tb_Material实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_MaterialEntity _tb_MaterialModel)
		{
			string sqlStr="insert into tb_Material([UserID],[WeiXinCode],[TypeID],[Status],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@TypeID,@Status,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@TypeID",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_MaterialModel.UserID;
			_param[1].Value=_tb_MaterialModel.WeiXinCode;
			_param[2].Value=_tb_MaterialModel.TypeID;
			_param[3].Value=_tb_MaterialModel.Status;
			_param[4].Value=_tb_MaterialModel.AddTime;
			_param[5].Value=_tb_MaterialModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_MaterialModel">tb_Material实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_MaterialEntity _tb_MaterialModel)
		{
			string sqlStr="insert into tb_Material([UserID],[WeiXinCode],[TypeID],[Status],[AddTime],[UpdateTime]) values(@UserID,@WeiXinCode,@TypeID,@Status,@AddTime,@UpdateTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@TypeID",SqlDbType.Int),
			new SqlParameter("@Status",SqlDbType.Int),
			new SqlParameter("@AddTime",SqlDbType.DateTime),
			new SqlParameter("@UpdateTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_MaterialModel.UserID;
			_param[1].Value=_tb_MaterialModel.WeiXinCode;
			_param[2].Value=_tb_MaterialModel.TypeID;
			_param[3].Value=_tb_MaterialModel.Status;
			_param[4].Value=_tb_MaterialModel.AddTime;
			_param[5].Value=_tb_MaterialModel.UpdateTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Material更新一条记录。
		/// </summary>
		/// <param name="_tb_MaterialModel">_tb_MaterialModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_MaterialEntity _tb_MaterialModel)
		{
            string sqlStr="update tb_Material set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[TypeID]=@TypeID,[Status]=@Status,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@TypeID",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_MaterialModel.ID;
				_param[1].Value=_tb_MaterialModel.UserID;
				_param[2].Value=_tb_MaterialModel.WeiXinCode;
				_param[3].Value=_tb_MaterialModel.TypeID;
				_param[4].Value=_tb_MaterialModel.Status;
				_param[5].Value=_tb_MaterialModel.AddTime;
				_param[6].Value=_tb_MaterialModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Material更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_MaterialModel">_tb_MaterialModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_MaterialEntity _tb_MaterialModel)
		{
            string sqlStr="update tb_Material set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[TypeID]=@TypeID,[Status]=@Status,[AddTime]=@AddTime,[UpdateTime]=@UpdateTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@TypeID",SqlDbType.Int),
				new SqlParameter("@Status",SqlDbType.Int),
				new SqlParameter("@AddTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_MaterialModel.ID;
				_param[1].Value=_tb_MaterialModel.UserID;
				_param[2].Value=_tb_MaterialModel.WeiXinCode;
				_param[3].Value=_tb_MaterialModel.TypeID;
				_param[4].Value=_tb_MaterialModel.Status;
				_param[5].Value=_tb_MaterialModel.AddTime;
				_param[6].Value=_tb_MaterialModel.UpdateTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Material中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_Material where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Material中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_Material where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_material 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_material 数据实体</returns>
		public tb_MaterialEntity Populate_tb_MaterialEntity_FromDr(DataRow row)
		{
			tb_MaterialEntity Obj = new tb_MaterialEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID =  row["UserID"].ToString();
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.TypeID = (( row["TypeID"])==DBNull.Value)?0:Convert.ToInt32( row["TypeID"]);
				Obj.Status = (( row["Status"])==DBNull.Value)?0:Convert.ToInt32( row["Status"]);
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
		/// 得到  tb_material 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_material 数据实体</returns>
		public tb_MaterialEntity Populate_tb_MaterialEntity_FromDr(IDataReader dr)
		{
			tb_MaterialEntity Obj = new tb_MaterialEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID =  dr["UserID"].ToString();
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.TypeID = (( dr["TypeID"])==DBNull.Value)?0:Convert.ToInt32( dr["TypeID"]);
				Obj.Status = (( dr["Status"])==DBNull.Value)?0:Convert.ToInt32( dr["Status"]);
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
				Obj.UpdateTime = (( dr["UpdateTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["UpdateTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Material对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_Material对象</returns>
		public tb_MaterialEntity Get_tb_MaterialEntity (int iD)
		{
			tb_MaterialEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_Material with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_MaterialEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Material所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_MaterialEntity> Get_tb_MaterialAll()
		{
			IList< tb_MaterialEntity> Obj=new List< tb_MaterialEntity>();
			string sqlStr="select * from tb_Material";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_MaterialEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Material(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_Material where ID=@iD";
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
