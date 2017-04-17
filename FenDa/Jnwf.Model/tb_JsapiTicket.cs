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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model
{
	/// <summary>
	///tb_JsapiTicket数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_JsapiTicketEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _weiXinCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _ticket = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _addTime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_JsapiTicketEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_JsapiTicketEntity
		(
			int iD,
			string weiXinCode,
			string ticket,
			DateTime addTime
		)
		{
			_iD         = iD;
			_weiXinCode = weiXinCode;
			_ticket     = ticket;
			_addTime    = addTime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int ID
		{
			get {return _iD;}
			set {_iD = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string WeiXinCode
		{
			get {return _weiXinCode;}
			set {_weiXinCode = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Ticket
		{
			get {return _ticket;}
			set {_ticket = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime AddTime
		{
			get {return _addTime;}
			set {_addTime = value;}
		}
	
		#endregion
		
	}
}
