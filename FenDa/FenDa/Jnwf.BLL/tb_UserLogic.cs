// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_User.cs
// 项目名称：微信平台
// 创建时间：2015/3/30
// 负责人：杨晓光
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Jnwf.DAL;
using Jnwf.Model;

namespace Jnwf.BLL 
{
    public partial class tb_UserBLL : BaseBLL< tb_UserBLL>

    {
        tb_UserDataAccessLayer tb_Userdal;
        public tb_UserBLL()
        {
            tb_Userdal = new tb_UserDataAccessLayer();
        }

        public int Insert(tb_UserEntity tb_UserEntity)
        {
            return tb_Userdal.Insert(tb_UserEntity);            
        }

        public void Update(tb_UserEntity tb_UserEntity)
        {
            tb_Userdal.Update(tb_UserEntity);
        }

        public tb_UserEntity GetAdminSingle(int iD)
        {
           return tb_Userdal.Get_tb_UserEntity(iD);
        }

        public IList<tb_UserEntity> Gettb_UserList()
        {
            IList<tb_UserEntity> tb_UserList = new List<tb_UserEntity>();
            tb_UserList=tb_Userdal.Get_tb_UserAll();
            return tb_UserList;
        }

        public tb_UserEntity GetModelByNameAndPwd(string name, string pwd)
        {
            return tb_Userdal.Get_tb_UserEntity(name,pwd);
        }

        public tb_UserEntity GetModelByName(string name)
        {
            return tb_Userdal.Get_tb_UserEntity(name);
        }
        public tb_UserEntity GetModelByWeiXin(string weixin)
        {
            return tb_Userdal.GetModelByWeiXin(weixin);
        }
    }
}
