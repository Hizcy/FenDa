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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model 
{
	/// <summary>
	///tb_Tree数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_TreeEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _parentID;
		///<summary>
		///
		///</summary>
		private string _title = String.Empty;
		///<summary>
		///
		///</summary>
		private string _iconCls = String.Empty;
		///<summary>
		///
		///</summary>
		private int _orderNum;
		///<summary>
		///
		///</summary>
		private string _url = String.Empty;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_TreeEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_TreeEntity
		(
			int iD,
			int parentID,
			string title,
			string iconCls,
			int orderNum,
			string url
		)
		{
			_iD       = iD;
			_parentID = parentID;
			_title    = title;
			_iconCls  = iconCls;
			_orderNum = orderNum;
			_url      = url;
			
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
		public int ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
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
		public string IconCls
		{
			get {return _iconCls;}
			set {_iconCls = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Url
		{
			get {return _url;}
			set {_url = value;}
		}
	
		#endregion
		
	}
}
