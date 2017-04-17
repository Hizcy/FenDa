// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_AccessToken.cs
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
	///tb_AccessToken数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_AccessTokenEntity
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
		private string _accessToken = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _addTime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_AccessTokenEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_AccessTokenEntity
		(
			int iD,
			string userID,
			string weiXinCode,
			string accessToken,
			DateTime addTime
		)
		{
			_iD          = iD;
			_userID      = userID;
			_weiXinCode  = weiXinCode;
			_accessToken = accessToken;
			_addTime     = addTime;
			
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
		public string AccessToken
		{
			get {return _accessToken;}
			set {_accessToken = value;}
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
