// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_MaterialContent.cs
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
	///tb_MaterialContent数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_MaterialContentEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _iD;
		///<summary>
		///
		///</summary>
		private int _materialID;
		///<summary>
		///
		///</summary>
		private string _title = String.Empty;
		///<summary>
		///
		///</summary>
		private string _author = String.Empty;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
		///<summary>
		///
		///</summary>
		private string _imageUrl = String.Empty;
		///<summary>
		///
		///</summary>
		private string _textContent = String.Empty;
		///<summary>
		///
		///</summary>
		private string _url = String.Empty;
		///<summary>
		///
		///</summary>
		private int _orderBy;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_MaterialContentEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_MaterialContentEntity
		(
			int iD,
			int materialID,
			string title,
			string author,
			string description,
			string imageUrl,
			string textContent,
			string url,
			int orderBy
		)
		{
			_iD          = iD;
			_materialID  = materialID;
			_title       = title;
			_author      = author;
			_description = description;
			_imageUrl    = imageUrl;
			_textContent = textContent;
			_url         = url;
			_orderBy     = orderBy;
			
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
		public int MaterialID
		{
			get {return _materialID;}
			set {_materialID = value;}
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
		public string Author
		{
			get {return _author;}
			set {_author = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string ImageUrl
		{
			get {return _imageUrl;}
			set {_imageUrl = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string TextContent
		{
			get {return _textContent;}
			set {_textContent = value;}
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

		///<summary>
		///
		///</summary>
		[DataMember]
		public int OrderBy
		{
			get {return _orderBy;}
			set {_orderBy = value;}
		}
	
		#endregion
		
	}
}
