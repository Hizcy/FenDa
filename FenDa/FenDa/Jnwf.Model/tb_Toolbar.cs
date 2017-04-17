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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model 
{
	/// <summary>
	///tb_Toolbar数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ToolbarEntity
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
		private int _parentID;
		///<summary>
		///
		///</summary>
		private int _toolLevel;
		///<summary>
		///
		///</summary>
		private string _toolName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _typeID;
		///<summary>
		///
		///</summary>
		private string _params = String.Empty;
		///<summary>
		///
		///</summary>
		private int _materialID;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_ToolbarEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ToolbarEntity
		(
			int iD,
			string userID,
			string weiXinCode,
			int parentID,
			int toolLevel,
			string toolName,
			int typeID,
			string __params,
			int materialID
		)
		{
			_iD         = iD;
			_userID     = userID;
			_weiXinCode = weiXinCode;
			_parentID   = parentID;
			_toolLevel  = toolLevel;
			_toolName   = toolName;
			_typeID     = typeID;
			_params     = __params;
			_materialID = materialID;
			
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
		public int ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int ToolLevel
		{
			get {return _toolLevel;}
			set {_toolLevel = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string ToolName
		{
			get {return _toolName;}
			set {_toolName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Params
		{
			get {return _params;}
			set {_params = value;}
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
	
		#endregion
		
	}
}
