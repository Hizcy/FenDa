using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_Index : BasePage//System.Web.UI.Page//
{
    public int id = 0;
    public string headImg = String.Empty;//头像
    public string name = String.Empty;//医生姓名
    public string titles = String.Empty;//职称
    public string clever = String.Empty;//擅长
    public string abteilung = String.Empty;//科室
    public string description = String.Empty;//简介
    public int solutionNumber = 0;//回答问题数 
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
                id = model.Id;
                headImg = model.HeadImg;
                name = model.Name;
                titles = model.Titles;
                abteilung = model.Abteilung;
                description = model.Description;
                clever = model.Clever;
                BindInfor();
            }
        }
    }
    public void BindInfor()
    {
        DataSet ds = FenDa.BLL.tb_QuestionBLL.GetInstance().GetSoultionByOpenIdAndEmployerId(appid, id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            rptSoultionlist.DataSource = ds.Tables[0];
            rptSoultionlist.DataBind();
            solutionNumber = ds.Tables[0].Rows.Count;
        }
    }
}