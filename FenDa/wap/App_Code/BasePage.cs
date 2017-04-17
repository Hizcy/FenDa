using Jnwf.Model;
using FenDa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;


/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{

    public delegate void WxUsersEntity(tb_OpenID_UserEntity user);
    public event WxUsersEntity OnBasePageLoad;  
    public BasePage()  
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        this.OnBasePageLoad += new WxUsersEntity(BasePage_Load);
    }
    public int shopid = 0;
    public string appid = "";
    public string secret = "";
    public string weixincode = "";
    public string sitepath = "";
    public string jinru = "";
    public string timestamp = String.Empty;
    public string nonce = String.Empty;
    public string signature = String.Empty;
    public string Code
    {
        get
        {
            object obj = Request.QueryString["code"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    protected virtual void BasePage_Load(tb_OpenID_UserEntity user)
    {
    }
    protected override void OnInit(EventArgs e)
    {

        shopid = int.Parse(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("CompanyId"));
        appid = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("appid");
        secret = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("secret");
        weixincode = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("weixincode");
        sitepath = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("sitepath");

        WXJSSDK sdk = new WXJSSDK(appid, secret, weixincode);
        Hashtable h = sdk.getSignPackage();
        timestamp = h["timestamp"].ToString();
        nonce = h["nonceStr"].ToString();
        signature = h["signature"].ToString();

        tb_OpenID_UserEntity user = null;
        Jnwf.Model.tb_App_UserEntity app_user = null;
        //检查cookie
        string ticket = "";
        string disney = CookieHelper.GetCookieValue("disney");

        if (!string.IsNullOrEmpty(disney))
        {
            jinru = "cookie";
            //Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage,jinru:" + jinru);
            ticket = Jnwf.Utils.Helper.DESEncrypt.Decrypt(disney);
            //Jnwf.Utils.Log.Logger.Log4Net.Error("basepage,cookie:" + ticket);
            user =  Jnwf.BLL.tb_OpenID_UserBLL.GetInstance().GetModelByOpenId(ticket);
            app_user = Jnwf.BLL.tb_App_UserBLL.GetInstance().GetModelByOpenId(ticket);
            if (app_user == null)
            {
                try
                { 
                    Response.Redirect("http://mp.weixin.qq.com/s?__biz=MzI4MzE0ODM1Nw==&mid=402172802&idx=1&sn=c66fe86ffd6b8c8cb73bd3033c1d2903#rd");
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:"+jinru+"|" + ex.Data+"|"+ex.Message);
                }
            }
            else if (user == null)
            {
                try
                {
                    Response.Redirect(sitepath + "user/wdlist.aspx");
                }
                catch (System.Threading.ThreadAbortException ex)
                {
                    Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:" + jinru + "|" + ex.Data + "|" + ex.Message);
                }
            }
            else
            {
                //Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:" + jinru + "|" + user);
                this.OnBasePageLoad(user);
            }
            this.OnBasePageLoad(user);
        }
        else if (!string.IsNullOrEmpty(Code))
        {
            jinru = "code";
            //Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage,jinru:" + jinru);
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + secret + "&code=" + Code + "&grant_type=authorization_code";
            string json = Jnwf.Utils.Helper.HttpHelper.LoadPageContent(url);

            if (json.IndexOf("errcode") >= 0)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("Results.aspx:" + json);
            }
            else
            {

                wx_OpenInfoEntity info = Jnwf.Utils.Json.JsonHelper.DeserializeJson<wx_OpenInfoEntity>(json);

                string str = info.openid;
                //Jnwf.Utils.Log.Logger.Log4Net.Error("basepage,code:" + str);
                CookieHelper.SetCookie("disney", Jnwf.Utils.Helper.DESEncrypt.Encrypt(str));

                user = Jnwf.BLL.tb_OpenID_UserBLL.GetInstance().GetModelByOpenId(info.openid);
                app_user = Jnwf.BLL.tb_App_UserBLL.GetInstance().GetModelByOpenId(info.openid);
                if (app_user == null)
                {
                    try
                    {
                        Response.Redirect("http://mp.weixin.qq.com/s?__biz=MzI4MzE0ODM1Nw==&mid=402172802&idx=1&sn=c66fe86ffd6b8c8cb73bd3033c1d2903#rd");
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                        Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:" + jinru + "|" + ex.Data + "|" + ex.Message);
                    }
                }
                else if (user == null)
                {
                    try
                    {
                        Response.Redirect(sitepath + "Registered.aspx");
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                        Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:" + jinru + "|" + ex.Data + "|" + ex.Message);
                    }
                }
                else
                {
                   // Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage:" + jinru + "|" + user);
                    this.OnBasePageLoad(user);
                } 
            }
        }
        else
        {
            jinru = "url";
            //Jnwf.Utils.Log.Logger.Log4Net.Error("BasePage,jinru:" + jinru);
            //string host = this.Request.Url.Host;
            //string path = this.Request.Path;

            //string redirect_uri = HttpUtility.UrlEncode("http://" + host + path);
            string redirect_uri = HttpUtility.UrlEncode(this.Request.Url.ToString());
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("appid", appid);
            data.Add("redirect_uri", redirect_uri);
            data.Add("response_type", "code");
            data.Add("scope", "snsapi_base");

            string temp_url = "https://open.weixin.qq.com/connect/oauth2/authorize?";

            foreach (var dic in data)
            {
                temp_url += dic.Key + "=" + dic.Value + "&";
            }
            //Jnwf.Utils.Log.Logger.Log4Net.Error("detail:" + temp_url);
            try
            {
                //触发微信返回code码         
                this.Response.Redirect(temp_url.TrimEnd('&'));//Redirect函数会抛出ThreadAbortException异常，不用处理这个异常
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("App_Code-Basepage：" + ex.Message + "|" + ex.Data);
            }
        }
        base.OnInit(e);
    }
}
