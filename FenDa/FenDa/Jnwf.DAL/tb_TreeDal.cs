// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Tree.cs
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
    /// 数据层实例化接口类 dbo.tb_Tree.
    /// </summary>
    public partial class tb_TreeDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_TreeDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_TreeModel">tb_Tree实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_TreeEntity _tb_TreeModel)
		{
			string sqlStr="insert into tb_Tree([ParentID],[Title],[IconCls],[OrderNum],[Url]) values(@ParentID,@Title,@IconCls,@OrderNum,@Url) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@IconCls",SqlDbType.VarChar),
			new SqlParameter("@OrderNum",SqlDbType.Int),
			new SqlParameter("@Url",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_TreeModel.ParentID;
			_param[1].Value=_tb_TreeModel.Title;
			_param[2].Value=_tb_TreeModel.IconCls;
			_param[3].Value=_tb_TreeModel.OrderNum;
			_param[4].Value=_tb_TreeModel.Url;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_TreeModel">tb_Tree实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_TreeEntity _tb_TreeModel)
		{
			string sqlStr="insert into tb_Tree([ParentID],[Title],[IconCls],[OrderNum],[Url]) values(@ParentID,@Title,@IconCls,@OrderNum,@Url) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@ParentID",SqlDbType.Int),
			new SqlParameter("@Title",SqlDbType.VarChar),
			new SqlParameter("@IconCls",SqlDbType.VarChar),
			new SqlParameter("@OrderNum",SqlDbType.Int),
			new SqlParameter("@Url",SqlDbType.VarChar)
			};			
			_param[0].Value=_tb_TreeModel.ParentID;
			_param[1].Value=_tb_TreeModel.Title;
			_param[2].Value=_tb_TreeModel.IconCls;
			_param[3].Value=_tb_TreeModel.OrderNum;
			_param[4].Value=_tb_TreeModel.Url;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_Tree更新一条记录。
		/// </summary>
		/// <param name="_tb_TreeModel">_tb_TreeModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_TreeEntity _tb_TreeModel)
		{
            string sqlStr="update tb_Tree set [ParentID]=@ParentID,[Title]=@Title,[IconCls]=@IconCls,[OrderNum]=@OrderNum,[Url]=@Url where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@IconCls",SqlDbType.VarChar),
				new SqlParameter("@OrderNum",SqlDbType.Int),
				new SqlParameter("@Url",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_TreeModel.ID;
				_param[1].Value=_tb_TreeModel.ParentID;
				_param[2].Value=_tb_TreeModel.Title;
				_param[3].Value=_tb_TreeModel.IconCls;
				_param[4].Value=_tb_TreeModel.OrderNum;
				_param[5].Value=_tb_TreeModel.Url;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_Tree更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_TreeModel">_tb_TreeModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_TreeEntity _tb_TreeModel)
		{
            string sqlStr="update tb_Tree set [ParentID]=@ParentID,[Title]=@Title,[IconCls]=@IconCls,[OrderNum]=@OrderNum,[Url]=@Url where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@ParentID",SqlDbType.Int),
				new SqlParameter("@Title",SqlDbType.VarChar),
				new SqlParameter("@IconCls",SqlDbType.VarChar),
				new SqlParameter("@OrderNum",SqlDbType.Int),
				new SqlParameter("@Url",SqlDbType.VarChar)
				};				
				_param[0].Value=_tb_TreeModel.ID;
				_param[1].Value=_tb_TreeModel.ParentID;
				_param[2].Value=_tb_TreeModel.Title;
				_param[3].Value=_tb_TreeModel.IconCls;
				_param[4].Value=_tb_TreeModel.OrderNum;
				_param[5].Value=_tb_TreeModel.Url;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_Tree中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_Tree where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_Tree中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_Tree where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_tree 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_tree 数据实体</returns>
		public tb_TreeEntity Populate_tb_TreeEntity_FromDr(DataRow row)
		{
			tb_TreeEntity Obj = new tb_TreeEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.ParentID = (( row["ParentID"])==DBNull.Value)?0:Convert.ToInt32( row["ParentID"]);
				Obj.Title =  row["Title"].ToString();
				Obj.IconCls =  row["IconCls"].ToString();
				Obj.OrderNum = (( row["OrderNum"])==DBNull.Value)?0:Convert.ToInt32( row["OrderNum"]);
				Obj.Url =  row["Url"].ToString();
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_tree 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_tree 数据实体</returns>
		public tb_TreeEntity Populate_tb_TreeEntity_FromDr(IDataReader dr)
		{
			tb_TreeEntity Obj = new tb_TreeEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.ParentID = (( dr["ParentID"])==DBNull.Value)?0:Convert.ToInt32( dr["ParentID"]);
				Obj.Title =  dr["Title"].ToString();
				Obj.IconCls =  dr["IconCls"].ToString();
				Obj.OrderNum = (( dr["OrderNum"])==DBNull.Value)?0:Convert.ToInt32( dr["OrderNum"]);
				Obj.Url =  dr["Url"].ToString();
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_Tree对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_Tree对象</returns>
		public tb_TreeEntity Get_tb_TreeEntity (int iD)
		{
			tb_TreeEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_Tree with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_TreeEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_Tree所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_TreeEntity> Get_tb_TreeAll()
		{
			IList< tb_TreeEntity> Obj=new List< tb_TreeEntity>();
			string sqlStr="select * from tb_Tree";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_TreeEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_Tree(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_Tree where ID=@iD";
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
