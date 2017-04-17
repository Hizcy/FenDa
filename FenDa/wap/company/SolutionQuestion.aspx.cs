using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_SolutionQuestion : BasePage//System.Web.UI.Page//
{
    public string headImg = String.Empty;//头像
    public string name = String.Empty;//公司名
    public string wxCode = String.Empty;//微信号
    public string codeImg = String.Empty;//二维码
    public string description = String.Empty;//简介
    public int employeId = 0;
    public static string url = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("url");
    public static string qinuiUrl = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("QINUIURL");
    public int questionId
    {
        get
        {
            object obj = Request.QueryString["id"];
            if (obj == null)
            {
                return 0;
            }
            int i;
            int.TryParse(obj.ToString(), out i);
            return i;
        }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected override void BasePage_Load(Jnwf.Model.tb_OpenID_UserEntity user)
    {
        if (!IsPostBack)
        {
            FenDa.Model.tb_EmployeEntity model = FenDa.BLL.tb_EmployeBLL.GetInstance().GetEmployeEntityByOpenId(user.OpenID);
            if (model != null)
            {
                employeId = model.Id;
            }
            //获取问题详情
            DataSet ds = FenDa.BLL.tb_QuestionBLL.GetInstance().GetQuestionListByOpenIdAndId(appid, questionId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                headImg = ds.Tables[0].Rows[0]["companyImg"].ToString();
                name = ds.Tables[0].Rows[0]["companyName"].ToString();
                wxCode = ds.Tables[0].Rows[0]["WxCode"].ToString();
                codeImg = ds.Tables[0].Rows[0]["CodeImg"].ToString();
                description = ds.Tables[0].Rows[0]["Description"].ToString();
                repQuestion.DataSource = ds.Tables[0];
                repQuestion.DataBind();
            }
        }
    }

}