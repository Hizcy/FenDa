using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Jnwf.Model
{
    [Serializable]
    [DataContract]
    public class tb_MaterialAllEntity
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
		private int _typeID;
		///<summary>
		///
		///</summary>
		private int _status;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _addTime;
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
		public tb_MaterialAllEntity()
		{
		}
		///<summary>
		///
		///</summary>
        public tb_MaterialAllEntity
		(
			int iD,
			string userID,
			string weiXinCode,
			int typeID,
			int status,
            DateTime addTime,

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
			_iD         = iD;
			_userID     = userID;
			_weiXinCode = weiXinCode;
			_typeID     = typeID;
			_status     = status;
            _addTime    = addTime;

            _materialID = materialID;
            _title = title;
            _author = author;
            _description = description;
            _imageUrl = imageUrl;
            _textContent = textContent;
            _url = url;
            _orderBy = orderBy;
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
		public int TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
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
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }
        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public int MaterialID
        {
            get { return _materialID; }
            set { _materialID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string TextContent
        {
            get { return _textContent; }
            set { _textContent = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        ///<summary>
        ///
        ///</summary>
        [DataMember]
        public int OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }
		#endregion
    }
}
