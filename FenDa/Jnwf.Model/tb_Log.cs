// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Log.cs
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
	///tb_Log数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_LogEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private string _typeID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _title = String.Empty;
		///<summary>
		///
		///</summary>
		private string _logContent = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _addTime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_LogEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_LogEntity
		(
			int iD,
			string typeID,
			string title,
			string logContent,
			DateTime addTime
		)
		{
			_iD         = iD;
			_typeID     = typeID;
			_title      = title;
			_logContent = logContent;
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
		public string TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Title
		{
			get {return _title;}
			set {_title = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LogContent
		{
			get {return _logContent;}
			set {_logContent = value;}
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
