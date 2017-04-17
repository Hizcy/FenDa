// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_App_User.cs
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
	///tb_App_User数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_App_UserEntity
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
		private string _openID = String.Empty;
		///<summary>
		///
		///</summary>
		private int _status;
		///<summary>
		///
		///</summary>
		private DateTime _addTime;
		///<summary>
		///
		///</summary>
		private DateTime _updateTime;

        private string _recommend;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_App_UserEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_App_UserEntity
		(
			int iD,
			string weiXinCode,
			string openID,
			int status,
			DateTime addTime,
			DateTime updateTime,
            string recommend
		)
		{
			_iD         = iD;
			_weiXinCode = weiXinCode;
			_openID     = openID;
			_status     = status;
			_addTime    = addTime;
			_updateTime = updateTime;
            _recommend = recommend;
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
		public string OpenID
		{
			get {return _openID;}
			set {_openID = value;}
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

        [DataMember]
        public string Recommend
        {
            get { return _recommend; }
            set { _recommend = value; }
        }
		#endregion
		
	}
}
