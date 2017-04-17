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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model 
{
	/// <summary>
	///tb_User数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_UserEntity
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
		private string _pWD = String.Empty;
		///<summary>
		///
		///</summary>
		private string _realName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _status;
		///<summary>
		///
		///</summary>
		private string _weiXinCode = String.Empty;
		///<summary>
		///
		///</summary>
		private string _interface = String.Empty;
		///<summary>
		///
		///</summary>
		private string _token = String.Empty;
		///<summary>
		///
		///</summary>
		private string _appID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _appSecret = String.Empty;
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
		public tb_UserEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_UserEntity
		(
			int iD,
			string userID,
			string pWD,
			string realName,
			int status,
			string weiXinCode,
			string __interface,
			string token,
			string appID,
			string appSecret,
			DateTime addTime,
			DateTime updateTime
		)
		{
			_iD         = iD;
			_userID     = userID;
			_pWD        = pWD;
			_realName   = realName;
			_status     = status;
			_weiXinCode = weiXinCode;
			_interface  = __interface;
			_token      = token;
			_appID      = appID;
			_appSecret  = appSecret;
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
		public string PWD
		{
			get {return _pWD;}
			set {_pWD = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string RealName
		{
			get {return _realName;}
			set {_realName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Status
		{
			get {return _status;}
			set {_status = value;}
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
		public string Interface
		{
			get {return _interface;}
			set {_interface = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Token
		{
			get {return _token;}
			set {_token = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string AppID
		{
			get {return _appID;}
			set {_appID = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string AppSecret
		{
			get {return _appSecret;}
			set {_appSecret = value;}
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
