// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_App_User_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/6/26
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model
{
	/// <summary>
	///tb_App_User_Statistics数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_App_User_StatisticsEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _id;
		///<summary>
		///
		///</summary>
		private DateTime _date;
		///<summary>
		///
		///</summary>
		private string _weiXinCode = String.Empty;
		///<summary>
		///
		///</summary>
		private int _currentCount;
		///<summary>
		///
		///</summary>
		private int _addCount;
		///<summary>
		///
		///</summary>
		private int _subCount;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_App_User_StatisticsEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_App_User_StatisticsEntity
		(
			int id,
			DateTime date,
			string weiXinCode,
			int currentCount,
			int addCount,
			int subCount
		)
		{
			_id           = id;
			_date         = date;
			_weiXinCode   = weiXinCode;
			_currentCount = currentCount;
			_addCount     = addCount;
			_subCount     = subCount;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime Date
		{
			get {return _date;}
			set {_date = value;}
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
		public int CurrentCount
		{
			get {return _currentCount;}
			set {_currentCount = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int AddCount
		{
			get {return _addCount;}
			set {_addCount = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int SubCount
		{
			get {return _subCount;}
			set {_subCount = value;}
		}
	
		#endregion
		
	}
}
