using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_WDList : BasePage//System.Web.UI.Page// 
{
    public string headImg = String.Empty;//头像
    public string name = String.Empty;//公司名
    public string wxCode = String.Empty;//微信号
    public string codeImg = String.Empty;//二维码
    public string description = String.Empty;//简介
    public int solutionNumber = 0;//回答问题数 
    public int companyId = 0;
    public string openid = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //openid = "oiY2Vwv2WH3xo2dKJzfGzp_Dow3o";
        ////获取公司信息
        //DataSet tmpds = FenDa.BLL.tb_CompanyBLL.GetInstance().GetCompanyModelByOpenId("wxea1095264126e8c4");
        //if (tmpds != null && tmpds.Tables.Count > 0 && tmpds.Tables[0] != null && tmpds.Tables[0].Rows.Count > 0)
        //{
        //    companyId = Convert.ToInt32(tmpds.Tables[0].Rows[0]["Id"]);
        //    headImg = tmpds.Tables[0].Rows[0]["HeadImg"].ToString();
        //    name = tmpds.Tables[0].Rows[0]["RealName"].ToString();
        //    wxCode = tmpds.Tables[0].Rows[0]["WeiXinCode"].ToString();
        //    codeImg = tmpds.Tables[0].Rows[0]["CodeImg"].ToString();
        //    description = tmpds.Tables[0].Rows[0]["Description"].ToString();
        //    //获取当前公司的所有回答过的问题
        //    DataSet ds = FenDa.BLL.tb_SolutionBLL.GetInstance().GetSolutionListByCompanyId(1);
        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        repSolutionlist.DataSource = ds.Tables;
        //        repSolutionlist.DataBind();
        //        solutionNumber = ds.Tables[0].Rows.Count;
        //    }
        //}
    }

    protected override void BasePage_Load(Jnwf.Model.tb_OpenID_UserEntity user)
    {
        if (!IsPostBack)
        {
            if (user != null)
            {
                openid = user.OpenID;
                //获取公司信息
                DataSet tmpds = FenDa.BLL.tb_CompanyBLL.GetInstance().GetCompanyModelByOpenId(appid);
                if (tmpds != null && tmpds.Tables.Count > 0 && tmpds.Tables[0] != null && tmpds.Tables[0].Rows.Count > 0)
                {
                    companyId = Convert.ToInt32(tmpds.Tables[0].Rows[0]["Id"]); 
                    headImg = tmpds.Tables[0].Rows[0]["HeadImg"].ToString();
                    name = tmpds.Tables[0].Rows[0]["RealName"].ToString();
                    wxCode = tmpds.Tables[0].Rows[0]["WeiXinCode"].ToString();
                    codeImg = tmpds.Tables[0].Rows[0]["CodeImg"].ToString();
                    description = tmpds.Tables[0].Rows[0]["Description"].ToString();
                    //获取当前公司的所有回答过的问题
                    DataSet ds = FenDa.BLL.tb_SolutionBLL.GetInstance().GetSolutionListByCompanyId(companyId);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        repSolutionlist.DataSource = ds.Tables[0];
                        repSolutionlist.DataBind();
                        solutionNumber = ds.Tables[0].Rows.Count;
                    }
                }
            }
        }
    } 
}