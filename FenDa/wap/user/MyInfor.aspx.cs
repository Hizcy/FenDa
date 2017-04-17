using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_MyInfor : BasePage//System.Web.UI.Page//
{
    public int linstenInNum = 0;//收听数
    public int questionNum = 0;//问答数
    public string headImg = String.Empty;//头像
    public string nickName = String.Empty;//昵称
    public string openId = String.Empty;//当前登入者的唯一标识
    public int companyId = 0;//当前公司id

    protected void Page_Load(object sender, EventArgs e)
    {
        ////获取公司信息
        //DataSet tmpds = FenDa.BLL.tb_CompanyBLL.GetInstance().GetCompanyModelByOpenId("wxea1095264126e8c4");
        //if (tmpds != null && tmpds.Tables.Count > 0 && tmpds.Tables[0] != null && tmpds.Tables[0].Rows.Count > 0)
        //{
        //    companyId = Convert.ToInt32(tmpds.Tables[0].Rows[0]["Id"]);
        //}
        ////收听过的
        //DataSet ds = FenDa.BLL.tb_ListenInBLL.GetInstance().GetListenInListByappIdAndOpenId("wxea1095264126e8c4", "oiY2Vwlwew2UXdxID1VS3_TdtFl8");
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    rptListenInlist.DataSource = ds.Tables[0];
        //    rptListenInlist.DataBind();
        //    linstenInNum = ds.Tables[0].Rows.Count;
        //}
        ////我问过的问题
        //DataSet dss = FenDa.BLL.tb_QuestionBLL.GetInstance().GetQuestionListByCompanyOpenIdAndOpenId("wxea1095264126e8c4", "oiY2Vwlwew2UXdxID1VS3_TdtFl8");
        //if (dss != null && dss.Tables.Count > 0 && dss.Tables[0] != null && dss.Tables[0].Rows.Count > 0)
        //{
        //    rptQuestionlist.DataSource = dss.Tables[0];
        //    rptQuestionlist.DataBind();
        //    questionNum = dss.Tables[0].Rows.Count;
        //}
    }
    protected override void BasePage_Load(Jnwf.Model.tb_OpenID_UserEntity user)
    {
        if (!IsPostBack)
        {
            if (user != null)
            {
                //获取公司信息
                DataSet tmpds = FenDa.BLL.tb_CompanyBLL.GetInstance().GetCompanyModelByOpenId(appid);
                if (tmpds != null && tmpds.Tables.Count > 0 && tmpds.Tables[0] != null && tmpds.Tables[0].Rows.Count > 0)
                {
                    companyId = Convert.ToInt32(tmpds.Tables[0].Rows[0]["Id"]);
                }
                //收听过的
                DataSet ds = FenDa.BLL.tb_ListenInBLL.GetInstance().GetListenInListByappIdAndOpenId(appid, user.OpenID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptListenInlist.DataSource = ds.Tables[0];
                    rptListenInlist.DataBind();
                    linstenInNum = ds.Tables[0].Rows.Count;
                }
                //我问过的问题
                DataSet dss = FenDa.BLL.tb_QuestionBLL.GetInstance().GetQuestionListByCompanyOpenIdAndOpenId(appid, user.OpenID);
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0] != null && dss.Tables[0].Rows.Count > 0)
                {
                    rptQuestionlist.DataSource = dss.Tables[0];
                    rptQuestionlist.DataBind();
                    questionNum = dss.Tables[0].Rows.Count;
                }
                headImg = user.HeadImgurl;
                nickName = user.NickName;
                openId = user.OpenID;
            }
        }
    }
}