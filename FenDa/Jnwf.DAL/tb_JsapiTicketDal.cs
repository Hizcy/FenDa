// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_JsapiTicket.cs
// 项目名称：买车网
// 创建时间：2015/4/19
// 负责人：
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
    /// 数据层实例化接口类 dbo.tb_JsapiTicket.
    /// </summary>
    public partial class tb_JsapiTicketDataAccessLayer 
    {
		#region 构造函数


		/// <summary>
		/// 
		/// </summary>
		public tb_JsapiTicketDataAccessLayer()
		{
		}
		#endregion

        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="_tb_JsapiTicketModel">tb_JsapiTicket实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(tb_JsapiTicketEntity _tb_JsapiTicketModel)
		{
			string sqlStr="insert into tb_JsapiTicket([WeiXinCode],[Ticket],[AddTime]) values(@WeiXinCode,@Ticket,@AddTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Ticket",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_JsapiTicketModel.WeiXinCode;
			_param[1].Value=_tb_JsapiTicketModel.Ticket;
			_param[2].Value=_tb_JsapiTicketModel.AddTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(WebConfig.weixinRW,CommandType.Text,sqlStr,_param));
			return res;
		}
		/// <summary>
		/// 向数据库中插入一条新记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_JsapiTicketModel">tb_JsapiTicket实体</param>
		/// <returns>新插入记录的编号</returns>
		public int Insert(SqlTransaction sp,tb_JsapiTicketEntity _tb_JsapiTicketModel)
		{
			string sqlStr="insert into tb_JsapiTicket([WeiXinCode],[Ticket],[AddTime]) values(@WeiXinCode,@Ticket,@AddTime) select @@identity";
			int res;
			SqlParameter[] _param={
			new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
			new SqlParameter("@Ticket",SqlDbType.VarChar),
			new SqlParameter("@AddTime",SqlDbType.DateTime)
			};			
			_param[0].Value=_tb_JsapiTicketModel.WeiXinCode;
			_param[1].Value=_tb_JsapiTicketModel.Ticket;
			_param[2].Value=_tb_JsapiTicketModel.AddTime;
			res = Convert.ToInt32(SqlHelper.ExecuteScalar(sp,CommandType.Text,sqlStr,_param));
			return res;
		}


		/// <summary>
		/// 向数据表tb_JsapiTicket更新一条记录。
		/// </summary>
		/// <param name="_tb_JsapiTicketModel">_tb_JsapiTicketModel</param>
		/// <returns>影响的行数</returns>
		public int Update(tb_JsapiTicketEntity _tb_JsapiTicketModel)
		{
            string sqlStr="update tb_JsapiTicket set [WeiXinCode]=@WeiXinCode,[Ticket]=@Ticket,[AddTime]=@AddTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Ticket",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_JsapiTicketModel.ID;
				_param[1].Value=_tb_JsapiTicketModel.WeiXinCode;
				_param[2].Value=_tb_JsapiTicketModel.Ticket;
				_param[3].Value=_tb_JsapiTicketModel.AddTime;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		/// <summary>
		/// 向数据表tb_JsapiTicket更新一条记录。带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
		/// <param name="_tb_JsapiTicketModel">_tb_JsapiTicketModel</param>
		/// <returns>影响的行数</returns>
		public int Update(SqlTransaction sp,tb_JsapiTicketEntity _tb_JsapiTicketModel)
		{
            string sqlStr="update tb_JsapiTicket set [WeiXinCode]=@WeiXinCode,[Ticket]=@Ticket,[AddTime]=@AddTime where ID=@ID";
			SqlParameter[] _param={				
				new SqlParameter("@ID",SqlDbType.Int),
				new SqlParameter("@WeiXinCode",SqlDbType.VarChar),
				new SqlParameter("@Ticket",SqlDbType.VarChar),
				new SqlParameter("@AddTime",SqlDbType.DateTime)
				};				
				_param[0].Value=_tb_JsapiTicketModel.ID;
				_param[1].Value=_tb_JsapiTicketModel.WeiXinCode;
				_param[2].Value=_tb_JsapiTicketModel.Ticket;
				_param[3].Value=_tb_JsapiTicketModel.AddTime;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}		
		
		
		/// <summary>
		/// 删除数据表tb_JsapiTicket中的一条记录
		/// </summary>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(int ID)
		{
			string sqlStr="delete from tb_JsapiTicket where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(WebConfig.weixinRW,CommandType.Text,sqlStr,_param);
		}
		
		/// <summary>
		/// 删除数据表tb_JsapiTicket中的一条记录,带事务
		/// </summary>
		/// <param name="sp">事务对象</param>
	    /// <param name="ID">iD</param>
		/// <returns>影响的行数</returns>
		public int Delete(SqlTransaction sp,int ID)
		{
			string sqlStr="delete from tb_JsapiTicket where [ID]=@ID";
			SqlParameter[] _param={			
			new SqlParameter("@ID",SqlDbType.Int),
			
			};			
			_param[0].Value=ID;
			return SqlHelper.ExecuteNonQuery(sp,CommandType.Text,sqlStr,_param);
		}
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  tb_jsapiticket 数据实体
		/// </summary>
		/// <param name="row">row</param>
		/// <returns>tb_jsapiticket 数据实体</returns>
		public tb_JsapiTicketEntity Populate_tb_JsapiTicketEntity_FromDr(DataRow row)
		{
			tb_JsapiTicketEntity Obj = new tb_JsapiTicketEntity();
			if(row!=null)
			{
				Obj.ID = (( row["ID"])==DBNull.Value)?0:Convert.ToInt32( row["ID"]);
				Obj.WeiXinCode =  row["WeiXinCode"].ToString();
				Obj.Ticket =  row["Ticket"].ToString();
				Obj.AddTime = (( row["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( row["AddTime"]);
			}
			else
			{
				return null;
			}
			return Obj;
		}
		
        /// <summary>
		/// 得到  tb_jsapiticket 数据实体
		/// </summary>
		/// <param name="dr">dr</param>
		/// <returns>tb_jsapiticket 数据实体</returns>
		public tb_JsapiTicketEntity Populate_tb_JsapiTicketEntity_FromDr(IDataReader dr)
		{
			tb_JsapiTicketEntity Obj = new tb_JsapiTicketEntity();
			
				Obj.ID = (( dr["ID"])==DBNull.Value)?0:Convert.ToInt32( dr["ID"]);
				Obj.WeiXinCode =  dr["WeiXinCode"].ToString();
				Obj.Ticket =  dr["Ticket"].ToString();
				Obj.AddTime = (( dr["AddTime"])==DBNull.Value)?Convert.ToDateTime("1900-1-1"):Convert.ToDateTime( dr["AddTime"]);
			
			return Obj;
		}
		#endregion
		
		/// <summary>
		/// 根据ID,返回一个tb_JsapiTicket对象
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>tb_JsapiTicket对象</returns>
		public tb_JsapiTicketEntity Get_tb_JsapiTicketEntity (int iD)
		{
			tb_JsapiTicketEntity _obj=null;
			SqlParameter[] _param={
			new SqlParameter("@ID",SqlDbType.Int)
			};
			_param[0].Value=iD;
			string sqlStr="select * from tb_JsapiTicket with(nolock) where ID=@ID";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr,_param))
			{
				while(dr.Read())
				{
            		_obj=Populate_tb_JsapiTicketEntity_FromDr(dr);
				}
			}
			return _obj;
		}
		/// <summary>
		/// 得到数据表tb_JsapiTicket所有记录
		/// </summary>
		/// <returns>数据集</returns>
		public IList< tb_JsapiTicketEntity> Get_tb_JsapiTicketAll()
		{
			IList< tb_JsapiTicketEntity> Obj=new List< tb_JsapiTicketEntity>();
			string sqlStr="select * from tb_JsapiTicket";
			using(SqlDataReader dr=SqlHelper.ExecuteReader(WebConfig.weixinRW,CommandType.Text,sqlStr))
			{
				while(dr.Read())
				{
					Obj.Add(Populate_tb_JsapiTicketEntity_FromDr(dr));
				}
			}
			return Obj;
		}
		/// <summary>
        /// 检测是否存在根据主键
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>是/否</returns>
		public bool IsExisttb_JsapiTicket(int iD)
		{
			SqlParameter[] _param={
                                      new SqlParameter("@iD",SqlDbType.Int)
                                  };
            _param[0].Value=iD;
            string sqlStr="select Count(*) from tb_JsapiTicket where ID=@iD";
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
