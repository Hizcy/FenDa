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
using System.Collections.Generic;

namespace Jnwf.Model
{
    [Serializable]
    [DataContract]
    public class tb_MaterialExtEntity : tb_MaterialEntity
    {
        public IList<tb_MaterialContentEntity> list = null;

        public tb_MaterialExtEntity()
        {
            list = new List<tb_MaterialContentEntity>();
        }
    }
}
