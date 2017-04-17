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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model 
{
	/// <summary>
	///tb_Subscription数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_SubscriptionEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _userID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _weiXinCode = String.Empty;
		///<summary>
		///
		///</summary>
		private int _materialID;
		///<summary>
		///
		///</summary>
		private DateTime _addTime;
		///<summary>
		///
		///</summary>
		private DateTime _updateTime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_SubscriptionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_SubscriptionEntity
		(
			int iD,
			string userID,
			string weiXinCode,
			int materialID,
			DateTime addTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_userID     = userID;
			_weiXinCode = weiXinCode;
			_materialID = materialID;
			_addTime    = addTime;
			_updateTime = updateTime;
			
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
		public string UserID
		{
			get {return _userID;}
			set {_userID = value;}
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
		public int MaterialID
		{
			get {return _materialID;}
			set {_materialID = value;}
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

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
	
		#endregion
		
	}
}
