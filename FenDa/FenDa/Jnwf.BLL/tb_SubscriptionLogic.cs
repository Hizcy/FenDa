// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_Subscription.cs
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
    public partial class tb_SubscriptionBLL : BaseBLL< tb_SubscriptionBLL>

    {
        tb_SubscriptionDataAccessLayer tb_Subscriptiondal;
        public tb_SubscriptionBLL()
        {
            tb_Subscriptiondal = new tb_SubscriptionDataAccessLayer();
        }

        public int Insert(tb_SubscriptionEntity tb_SubscriptionEntity)
        {
            return tb_Subscriptiondal.Insert(tb_SubscriptionEntity);            
        }

        public void Update(tb_SubscriptionEntity tb_SubscriptionEntity)
        {
            tb_Subscriptiondal.Update(tb_SubscriptionEntity);
        }

        public tb_SubscriptionEntity GetAdminSingle(int iD)
        {
           return tb_Subscriptiondal.Get_tb_SubscriptionEntity(iD);
        }

        public IList<tb_SubscriptionEntity> Gettb_SubscriptionList()
        {
            IList<tb_SubscriptionEntity> tb_SubscriptionList = new List<tb_SubscriptionEntity>();
            tb_SubscriptionList=tb_Subscriptiondal.Get_tb_SubscriptionAll();
            return tb_SubscriptionList;
        }

        public tb_SubscriptionEntity GetModelByWeiXinCode(string weixincode)
        {
            return tb_Subscriptiondal.GetModelByWeiXinCode(weixincode);
        }

        public int Save(Jnwf.Model.tb_MaterialEntity material, Jnwf.Model.tb_MaterialContentEntity content)
        {
            return tb_Subscriptiondal.Save(material,content);
        }

        public tb_MaterialExtEntity GetMaterialExtEntityByWeiXinCode(string weixincode)
        {
            return tb_Subscriptiondal.GetMaterialExtEntityByWeiXinCode(weixincode);
        }
    }
}
