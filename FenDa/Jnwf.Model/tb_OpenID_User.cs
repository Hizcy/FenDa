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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model 
{
	/// <summary>
	///tb_OpenID_User数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_OpenID_UserEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _openID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _nickName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sex;
		///<summary>
		///
		///</summary>
		private string _city = String.Empty;
		///<summary>
		///
		///</summary>
		private string _country = String.Empty;
		///<summary>
		///
		///</summary>
		private string _province = String.Empty;
		///<summary>
		///
		///</summary>
		private string _language = String.Empty;
		///<summary>
		///
		///</summary>
		private string _headImgurl = String.Empty;
		///<summary>
		///
		///</summary>
		private string _loginName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _loginPwd = String.Empty;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_OpenID_UserEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_OpenID_UserEntity
		(
			int iD,
			string openID,
			string nickName,
			int sex,
			string city,
			string country,
			string province,
			string language,
			string headImgurl,
			string loginName,
			string loginPwd
		)
		{
			_iD         = iD;
			_openID     = openID;
			_nickName   = nickName;
			_sex        = sex;
			_city       = city;
			_country    = country;
			_province   = province;
			_language   = language;
			_headImgurl = headImgurl;
			_loginName  = loginName;
			_loginPwd   = loginPwd;
			
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
		public string OpenID
		{
			get {return _openID;}
			set {_openID = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string NickName
		{
			get {return _nickName;}
			set {_nickName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Sex
		{
			get {return _sex;}
			set {_sex = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string City
		{
			get {return _city;}
			set {_city = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Country
		{
			get {return _country;}
			set {_country = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Province
		{
			get {return _province;}
			set {_province = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Language
		{
			get {return _language;}
			set {_language = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string HeadImgurl
		{
			get {return _headImgurl;}
			set {_headImgurl = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LoginName
		{
			get {return _loginName;}
			set {_loginName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LoginPwd
		{
			get {return _loginPwd;}
			set {_loginPwd = value;}
		}
	
		#endregion
		
	}
}
