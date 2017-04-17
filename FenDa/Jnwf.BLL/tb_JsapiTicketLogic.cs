// =================================================================== 
// 项目说明
//====================================================================
// 苗志国。@Copy Right 2014
// 文件： tb_JsapiTicket.cs
// 项目名称：买车网
// 创建时间：2015/4/19
// 负责人：
// ===================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Jnwf.DAL;
using Jnwf.Model;

namespace Jnwf.BLL
{
    public partial class tb_JsapiTicketBLL : BaseBLL< tb_JsapiTicketBLL>

    {
        tb_JsapiTicketDataAccessLayer tb_JsapiTicketdal;
        public tb_JsapiTicketBLL()
        {
            tb_JsapiTicketdal = new tb_JsapiTicketDataAccessLayer();
        }

        public int Insert(tb_JsapiTicketEntity tb_JsapiTicketEntity)
        {
            return tb_JsapiTicketdal.Insert(tb_JsapiTicketEntity);            
        }

        public void Update(tb_JsapiTicketEntity tb_JsapiTicketEntity)
        {
            tb_JsapiTicketdal.Update(tb_JsapiTicketEntity);
        }

        public tb_JsapiTicketEntity GetAdminSingle(int iD)
        {
           return tb_JsapiTicketdal.Get_tb_JsapiTicketEntity(iD);
        }

        public IList<tb_JsapiTicketEntity> Gettb_JsapiTicketList()
        {
            IList<tb_JsapiTicketEntity> tb_JsapiTicketList = new List<tb_JsapiTicketEntity>();
            tb_JsapiTicketList=tb_JsapiTicketdal.Get_tb_JsapiTicketAll();
            return tb_JsapiTicketList;
        }

        public tb_JsapiTicketEntity GetModel(string weixincode)
        {
            return tb_JsapiTicketdal.GetModel(weixincode);
        }
    }
}
