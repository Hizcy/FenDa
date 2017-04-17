using FenDa.BLL;
using FenDa.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class data_data : HtmlHelper//System.Web.UI.Page
{
    public static int questionQd = 0;
    public string type
    {

        get
        {
            object obj = Request.Params["type"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (type)
        {
            case "AddQuestion": //提问问题
                AddQuestion(Request.Form["openid"], Request.Form["question"], Request.Form["symptomimg"], Convert.ToInt32(Request.Form["leixing"]), Convert.ToInt32(Request.Form["companyId"]));
                break;
            case "loadingQuestionlist":/// 继续加载自己提问的问题
                loadingQuestionlist(Request.Form["openid"].ToString(), Convert.ToInt32(Request.Form["companyid"]), Convert.ToInt32(Request.Form["id"]));
                break;
            case "loadingListenInlist": /// 加载收听过的问答 
                loadingListenInlist(Request.Form["openid"].ToString(), Convert.ToInt32(Request.Form["companyid"]), Convert.ToInt32(Request.Form["id"]));
                break;
            case "loadinglist":
                loadinglist(Convert.ToInt32(Request.Form["companyid"]), Convert.ToInt32(Request.Form["id"]));
                break;
            case "SolutionQuestion"://回答问题
                SolutionQuestion(Convert.ToInt32(Request.Form["employerid"]), Convert.ToInt32(Request.Form["questionid"]), Convert.ToInt32(Request.Form["tmptype"]), Request.Form["solution"]);
                break;
            case "deleteImg"://删除图片
                deleteImg(Request.Form["url"]);
                break;
        }
    }
    /// <summary>
    /// 提问问题
    /// </summary>
    /// <param name="openId">提问人</param>
    /// <param name="question">问题</param>
    /// <param name="symptomimg">症状图</param>
    /// <param name="type">追问还是第一次问</param>
    /// <param name="companyId">公司id</param>
    public void AddQuestion(string openId, string question, string symptomimg, int type, int companyId)
    {
        try
        {
            tb_QuestionEntity model = new tb_QuestionEntity();
            model.CompanyId = companyId;
            model.OpenId = openId;
            model.Question = question;
            string img = SqlInject(symptomimg.Trim().Trim(','));
            if (img.Length > 0)
            {
                UploadQinui(img);
                if (img.IndexOf(',') >= 0)
                {
                    string[] arr = img.Split(',');
                    if (arr.Length == 2)
                    {
                        model.SymptomImg1 = arr[0];
                        model.SymptomImg2 = arr[1];
                    }
                    else if (arr.Length == 3)
                    {
                        model.SymptomImg1 = arr[0];
                        model.SymptomImg2 = arr[1];
                        model.SymptomImg3 = arr[2];
                    }
                    else if (arr.Length == 4)
                    {
                        model.SymptomImg1 = arr[0];
                        model.SymptomImg2 = arr[1];
                        model.SymptomImg3 = arr[2];
                        model.SymptomImg4 = arr[3];
                    }
                    else if (arr.Length == 5)
                    {
                        model.SymptomImg1 = arr[0];
                        model.SymptomImg2 = arr[1];
                        model.SymptomImg3 = arr[2];
                        model.SymptomImg4 = arr[3];
                        model.SymptomImg5 = arr[4];
                    }
                }
                else
                {
                    model.SymptomImg1 = img;
                }
            }
            model.Type = type;
            model.Statuss = 1;
            model.Addtime = DateTime.Now;
            if (tb_QuestionBLL.GetInstance().Insert(model) > 0)
            {
                Response.Write(1);
            }
            else
            {
                Response.Write(-1);
            }
        }
        catch (Exception ex)
        {
            Response.Write(-1);
            Jnwf.Utils.Log.Logger.Log4Net.Error("data-AddQuestion:" + ex.Data + "|" + ex.Message);
        }
    }
    public void UploadQinui(string url)
    {
        string path = Server.MapPath("~/upimg/");
        if (url.IndexOf(',') >= 0)
        {
            var arr = url.Split(',');
            foreach (string tmp in arr)
            {
                string name = tmp.Substring(tmp.LastIndexOf('/') + 1);
                Thumbnail.uploadQinui(name.Replace("s_", ""), path + name.Replace("s_", ""));
                File.Delete(path + name.Replace("s_", ""));
            }
        }
        else
        {
            string name = url.Substring(url.LastIndexOf('/') + 1);
            Thumbnail.uploadQinui(name.Replace("s_", ""), path + name.Replace("s_", ""));
            File.Delete(path + name);
        }
    }
    /// <summary>
    /// 继续加载自己提问的问题
    /// </summary>
    /// <param name="openId">当前登入者唯一标识</param>
    /// <param name="companyId">当前关注公司id</param>
    /// <param name="id">最后的id</param> 
    public void loadingQuestionlist(string openId, int companyId, int id)
    {
        DataSet ds = tb_QuestionBLL.GetInstance().GetQuestionListByCompanyIdAndOpenIdAndId(companyId, openId, id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{\"MessageBox\":\"OK\",\"data\":\"");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.AppendFormat("<ul class='show_Question'><li><a class='a_xiangqing' href='QuestionInfor.aspx?Id={0}&companyId={4}'><div class='div_sanjiao'></div><img class='img_heads' src='{1}' ><div class='div_mui'><div class='div_name'>{2}</div><div class='div_question'>{3}<table style='width: 100%;'><tr><td class='td_img'>", dr["id"], dr["HeadImgurl"], dr["NickName"], dr["Question"], companyId);

                sb.Append("" + dr["SymptomImg1"].ToString() != "" ? "<img src='" + dr["SymptomImg1"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg2"].ToString() != "" ? "<img src='" + dr["SymptomImg2"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg3"].ToString() != "" ? "<img src='" + dr["SymptomImg3"] + "' class='img_show' /></td></tr><tr><td class='td_img'>" : "</tr><tr><td class='td_img'>");
                sb.Append("" + dr["SymptomImg4"].ToString() != "" ? "<img src='" + dr["SymptomImg4"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg5"].ToString() != "" ? "<img src='" + dr["SymptomImg5"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("<input type='hidden' value='" + dr["id"] + "' class='hid' /></td></tr></table></div></div></a>");
                if (dr["name"].ToString() != "0")
                {
                    sb.Append("<div class='div_daan'></div><div style='margin-top: 20px'><img class='img_heads' src='" + dr["HeadImg"] + "'><div class='div_mui'><div class='div_name'>" + dr["name"] + "</div><div class='div_question'>" + dr["Solution"] + "</div></div></div><div class='div_count'><img src='../images/clock.png' width='10' />" + dr["solutionTime"] + "<div class='div_number'>" + dr["listeninNum"] + "人收听</div></div>");
                    //sb.Append("<div style='margin-top: 20px'><img class='img_heads' src='" + dr["HeadImg"] + "'><div class='div_body'><div class='div_answer'><img src='../images/AS.png' class='img_answer' /><div class='div_bofang'>点击播放</div><div class='div_bofang' style='display: none'>播放中...</div></div></div><div class='div_time'>45``</div></div><div class='div_count'><img src='../images/clock.png' width='10' />" + dr["Addtime"] + "<div class='div_number'>" + dr["listeninNum"] + "人收听</div></div></li></ul>");
                }
                else
                {
                    sb.Append("<div class='div_count'><img src='../images/clock.png' width='10' /> 还未回答<div class='div_number'>0人收听</div></div></li></ul>");
                }
            }
            sb.Append("\",\"number\":\"" + ds.Tables[0].Rows.Count + "\"}");
            Response.Write(sb);
        }
        else
        {
            Response.Write("{\"MessageBox\":\"NO\"}");
        }
    }
    /// <summary>
    /// 加载收听过的问答
    /// </summary>
    /// <param name="openId"></param>
    /// <param name="companyId"></param>
    /// <param name="id"></param>
    public void loadingListenInlist(string openId, int companyId, int id)
    {
        DataSet ds = tb_ListenInBLL.GetInstance().GetListenInListByCompanyIdAndOpenIdAndId(companyId, openId, id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{\"MessageBox\":\"OK\",data:\"");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.AppendFormat("<ul class='show_Question'><li><a class='a_xiangqing' href='QuestionInfor.aspx?Id={0}&companyId={4}'><div class='div_sanjiao'></div><img class='img_heads' src='{1}' ><div class='div_mui'><div class='div_name'>{2}</div><div class='div_question'>{3}<table style='width: 100%;'><tr><td class='td_img'>", dr["id"], dr["HeadImgurl"], dr["NickName"], dr["Question"], companyId);

                sb.Append("" + dr["SymptomImg1"].ToString() != "" ? "<img src='" + dr["SymptomImg1"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg2"].ToString() != "" ? "<img src='" + dr["SymptomImg2"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg3"].ToString() != "" ? "<img src='" + dr["SymptomImg3"] + "' class='img_show' /></td></tr><tr><td class='td_img'>" : "</tr><tr><td class='td_img'>");
                sb.Append("" + dr["SymptomImg4"].ToString() != "" ? "<img src='" + dr["SymptomImg4"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg5"].ToString() != "" ? "<img src='" + dr["SymptomImg5"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("<input type='hidden' value='" + dr["id"] + "' class='hid' /></td></tr></table></div></div></a>");
                sb.Append("<div class='div_daan'></div><div style='margin-top: 20px'><img class='img_heads' src='" + dr["HeadImg"] + "'><div class='div_mui'><div class='div_name'>" + dr["name"] + "</div><div class='div_question'>" + dr["Solution"] + "</div></div></div><div class='div_count'><img src='../images/clock.png' width='10' />" + dr["solutionTime"] + "<div class='div_number'>" + dr["listeninNum"] + "人收听</div></div>");
                //sb.Append("<div style='margin-top: 20px'><img class='img_heads' src='" + dr["HeadImg"] + "'><div class='div_body'><div class='div_answer'><img src='../images/AS.png' class='img_answer' /><div class='div_bofang'>点击播放</div><div class='div_bofang' style='display: none'>播放中...</div></div></div><div class='div_time'>45``</div></div><div class='div_count'><img src='../images/clock.png' width='10' />" + dr["Addtime"] + "<div class='div_number'>" + dr["listeninNum"] + "人收听</div></div></li></ul>");
            }
            sb.Append("\",\"number\":\"" + ds.Tables[0].Rows.Count + "\"}");
            Response.Write(sb);
        }
        else
        {
            Response.Write("{\"MessageBox\":\"NO\"}");
        }
    }
    public void loadinglist(int companyid, int id)
    {
        DataSet ds = tb_SolutionBLL.GetInstance().GetSolutionListByCompanyIdAndId(companyid, id);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("{\"MessageBox\":\"OK\",data:\"");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sb.AppendFormat("<ul class='show_Question'><li><a class='a_xiangqing' href='QuestionInfor.aspx?Id={0}&companyid={4}'><div class='div_sanjiao'></div><img class='img_heads' src='{1}' ><div class='div_mui'><div class='div_name'>{2}</div><div class='div_question'>{3}<table style='width: 100%;'><tr><td class='td_img'>", dr["id"], dr["HeadImgurl"], dr["NickName"], dr["Question"], companyid);

                sb.Append("" + dr["SymptomImg1"].ToString() != "" ? "<img src='" + dr["SymptomImg1"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg2"].ToString() != "" ? "<img src='" + dr["SymptomImg2"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg3"].ToString() != "" ? "<img src='" + dr["SymptomImg3"] + "' class='img_show' /></td></tr><tr><td class='td_img'>" : "</tr><tr><td class='td_img'>");
                sb.Append("" + dr["SymptomImg4"].ToString() != "" ? "<img src='" + dr["SymptomImg4"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("" + dr["SymptomImg5"].ToString() != "" ? "<img src='" + dr["SymptomImg5"] + "' class='img_show' /></td><td class='td_img'>" : "</td><td class='td_img'>");
                sb.Append("<input type='hidden' value='" + dr["id"] + "' class='hid' /></td></tr></table></div></div></a>");
                sb.Append("<div style='margin-top: 20px'><img class='img_heads' src='" + dr["HeadImg"] + "'><div class='div_body'><div class='div_answer'><img src='../images/AS.png' class='img_answer' /><div class='div_bofang'>点击播放</div><div class='div_bofang' style='display: none'>播放中...</div></div></div><div class='div_time'>45``</div></div><div class='div_count'><img src='../images/clock.png' width='10' />" + dr["Addtime"] + "<div class='div_number'>" + dr["listeninNum"] + "人收听</div></div></li></ul>");
            }
            sb.Append("\",\"number\":\"" + ds.Tables[0].Rows.Count + "\"}");
            Response.Write(sb);
        }
        else
        {
            Response.Write("{\"MessageBox\":\"NO\"}");
        }
    }
    /// <summary>
    /// 回答问题
    /// </summary>
    /// <param name="employerid"></param>
    /// <param name="questionid"></param>
    /// <param name="type"></param>
    /// <param name="solution"></param>
    public void SolutionQuestion(int employerid, int questionid, int type, string solution)
    {
        try
        {
            if (questionQd != questionid)
            {
                questionQd = questionid;
                if (FenDa.BLL.tb_SolutionBLL.GetInstance().isSolution(questionid))
                {
                    Response.Write(-2);
                }
                else
                {
                    FenDa.Model.tb_SolutionEntity model = new tb_SolutionEntity();
                    model.EmployerId = employerid;
                    model.QuestionId = questionid;
                    model.Statuss = 1;
                    model.Type = type;
                    model.Addtime = DateTime.Now;
                    model.Solution = SqlInject(solution);
                    if (FenDa.BLL.tb_SolutionBLL.GetInstance().Insert(model) > 0)
                    {
                        Response.Write(1);
                    }
                    else
                    {
                        Response.Write(-2);
                    }
                }
            }
            else
            {
                Response.Write(-2);
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data_SolutionQuestion:" + ex.Message + "|" + ex.Data);
            Response.Write(-1);
        }
    }
    /// <summary>
    /// 删除图片
    /// </summary>
    /// <param name="url"></param>
    public void deleteImg(string url)
    {
        string path = Server.MapPath("~/upimg/");
        if (!string.IsNullOrEmpty(url))
        {
            string name = url.Substring(url.LastIndexOf('/') + 1);
            if (File.Exists(path + name))
            {
                File.Delete(path + name);
                File.Delete(path + name.Replace("s_", ""));
            }
        }
    }
}