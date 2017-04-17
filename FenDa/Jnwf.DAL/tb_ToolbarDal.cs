// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Toolbar.cs
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
    /// 数据层实例化接口类 dbo.tb_Toolbar.
    /// </summary>
    public partial class tb_ToolbarDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_ToolbarDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_ToolbarModel">tb_Toolbar实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_ToolbarEntity _tb_ToolbarModel)
		{
			string sqlStr="insert into tb_Toolbar([UserID],[WeiXinCode],[ParentID],[ToolLevel],[ToolName],[TypeID],[Params],[MaterialID]) values(@UserID,@WeiXinCode,@ParentID,@ToolLevel,@ToolName,@TypeID,@Params,@MaterialID) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@ToolLevel",SqlDbType.Int),
			new SqlParameter("@ToolName",SqlDbType.VarChar),
			new SqlParameter("@TypeID",SqlDbType.Int),
			new SqlParameter("@Params",SqlDbType.VarChar),
			new SqlParameter("@MaterialID",SqlDbType.Int)
			};			
			_param[0].Value=_tb_ToolbarModel.UserID;
			_param[1].Value=_tb_ToolbarModel.WeiXinCode;
			_param[2].Value=_tb_ToolbarModel.ParentID;
			_param[3].Value=_tb_ToolbarModel.ToolLevel;
			_param[4].Value=_tb_ToolbarModel.ToolName;
			_param[5].Value=_tb_ToolbarModel.TypeID;
			_param[6].Value=_tb_ToolbarModel.Params;
			_param[7].Value=_tb_ToolbarModel.MaterialID;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ToolbarModel">tb_Toolbar实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_ToolbarEntity _tb_ToolbarModel)
		{
			string sqlStr="insert into tb_Toolbar([UserID],[WeiXinCode],[ParentID],[ToolLevel],[ToolName],[TypeID],[Params],[MaterialID]) values(@UserID,@WeiXinCode,@ParentID,@ToolLevel,@ToolName,@TypeID,@Params,@MaterialID) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@UserID",SqlDbType.VarChar),
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@ToolLevel",SqlDbType.Int),
			new SqlParameter("@ToolName",SqlDbType.VarChar),
			new SqlParameter("@TypeID",SqlDbType.Int),
			new SqlParameter("@Params",SqlDbType.VarChar),
			new SqlParameter("@MaterialID",SqlDbType.Int)
			};			
			_param[0].Value=_tb_ToolbarModel.UserID;
			_param[1].Value=_tb_ToolbarModel.WeiXinCode;
			_param[2].Value=_tb_ToolbarModel.ParentID;
			_param[3].Value=_tb_ToolbarModel.ToolLevel;
			_param[4].Value=_tb_ToolbarModel.ToolName;
			_param[5].Value=_tb_ToolbarModel.TypeID;
			_param[6].Value=_tb_ToolbarModel.Params;
			_param[7].Value=_tb_ToolbarModel.MaterialID;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Toolbar更新一条记录。
		/// </summary>
		/// <param name="_tb_ToolbarModel">_tb_ToolbarModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_ToolbarEntity _tb_ToolbarModel)
		{
            string sqlStr="update tb_Toolbar set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[ParentID]=@ParentID,[ToolLevel]=@ToolLevel,[ToolName]=@ToolName,[TypeID]=@TypeID,[Params]=@Params,[MaterialID]=@MaterialID where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@ToolLevel",SqlDbType.Int),
				new SqlParameter("@ToolName",SqlDbType.VarChar),
				new SqlParameter("@TypeID",SqlDbType.Int),
				new SqlParameter("@Params",SqlDbType.VarChar),
				new SqlParameter("@MaterialID",SqlDbType.Int)
				};				
				_param[0].Value=_tb_ToolbarModel.ID;
				_param[1].Value=_tb_ToolbarModel.UserID;
				_param[2].Value=_tb_ToolbarModel.WeiXinCode;
				_param[3].Value=_tb_ToolbarModel.ParentID;
				_param[4].Value=_tb_ToolbarModel.ToolLevel;
				_param[5].Value=_tb_ToolbarModel.ToolName;
				_param[6].Value=_tb_ToolbarModel.TypeID;
				_param[7].Value=_tb_ToolbarModel.Params;
				_param[8].Value=_tb_ToolbarModel.MaterialID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Toolbar更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_ToolbarModel">_tb_ToolbarModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_ToolbarEntity _tb_ToolbarModel)
		{
            string sqlStr="update tb_Toolbar set [UserID]=@UserID,[WeiXinCode]=@WeiXinCode,[ParentID]=@ParentID,[ToolLevel]=@ToolLevel,[ToolName]=@ToolName,[TypeID]=@TypeID,[Params]=@Params,[MaterialID]=@MaterialID where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@UserID",SqlDbType.VarChar),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@ToolLevel",SqlDbType.Int),
				new SqlParameter("@ToolName",SqlDbType.VarChar),
				new SqlParameter("@TypeID",SqlDbType.Int),
				new SqlParameter("@Params",SqlDbType.VarChar),
				new SqlParameter("@MaterialID",SqlDbType.Int)
				};				
				_param[0].Value=_tb_ToolbarModel.ID;
				_param[1].Value=_tb_ToolbarModel.UserID;
				_param[2].Value=_tb_ToolbarModel.WeiXinCode;
				_param[3].Value=_tb_ToolbarModel.ParentID;
				_param[4].Value=_tb_ToolbarModel.ToolLevel;
				_param[5].Value=_tb_ToolbarModel.ToolName;
				_param[6].Value=_tb_ToolbarModel.TypeID;
				_param[7].Value=_tb_ToolbarModel.Params;
				_param[8].Value=_tb_ToolbarModel.MaterialID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Toolbar中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_Toolbar where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Toolbar中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_Toolbar where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_toolbar 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_toolbar 数据实体</returns>
		public tb_ToolbarEntity Populate_tb_ToolbarEntity_FromDr(DataRow row)
		{
			tb_ToolbarEntity Obj = new tb_ToolbarEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.UserID =  row["UserID"].ToString();
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.ParentID = (( row["ParentID"])==DBNull.Value)?0:Convert.ToInt32( row["ParentID"]);
				Obj.ToolLevel = (( row["ToolLevel"])==DBNull.Value)?0:Convert.ToInt32( row["ToolLevel"]);
				Obj.ToolName =  row["ToolName"].ToString();
				Obj.TypeID = (( row["TypeID"])==DBNull.Value)?0:Convert.ToInt32( row["TypeID"]);
				Obj.Params =  row["Params"].ToString();
				Obj.MaterialID = (( row["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( row["MaterialID"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_toolbar 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_toolbar 数据实体</returns>
		public tb_ToolbarEntity Populate_tb_ToolbarEntity_FromDr(IDataReader dr)
		{
			tb_ToolbarEntity Obj = new tb_ToolbarEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.UserID =  dr["UserID"].ToString();
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.ParentID = (( dr["ParentID"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentID"]);
				Obj.ToolLevel = (( dr["ToolLevel"])==DBNull.Value)?0:Convert.ToInt32( dr["ToolLevel"]);
				Obj.ToolName =  dr["ToolName"].ToString();
				Obj.TypeID = (( dr["TypeID"])==DBNull.Value)?0:Convert.ToInt32( dr["TypeID"]);
				Obj.Params =  dr["Params"].ToString();
				Obj.MaterialID = (( dr["MaterialID"])==DBNull.Value)?0:Convert.ToInt32( dr["MaterialID"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Toolbar对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_Toolbar对象</returns>
		public tb_ToolbarEntity Get_tb_ToolbarEntity (int iD)
		{
			tb_ToolbarEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_Toolbar with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_ToolbarEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Toolbar所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_ToolbarEntity> Get_tb_ToolbarAll()
		{
			IList< tb_ToolbarEntity> Obj=new List< tb_ToolbarEntity>();
			string sqlStr="select * from tb_Toolbar";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_ToolbarEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Toolbar(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_Toolbar where ID=@iD";
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
