using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;

namespace Jnwf.Model
{
    [Serializable]
    [DataContract]
    public class tb_App_UserExtEntity
    {
        public tb_App_UserEntity user = null;

        public tb_OpenID_UserEntity ext = null;

        public tb_App_UserExtEntity()
        {
            user = new tb_App_UserEntity();
            ext = new tb_OpenID_UserEntity();
        }
    }
}
