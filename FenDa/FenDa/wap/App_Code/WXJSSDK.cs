using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// WXJSSDK 的摘要说明
/// </summary>
public class WXJSSDK
{
    private string appId;
    private string appSecret;
    private string weixincode;

    public WXJSSDK(string appId, string appSecret,string weixinCode)
    {
        this.appId = appId;
        this.appSecret = appSecret;
        this.weixincode = weixinCode;

    }

    //得到数据包，返回使用页面  
    public System.Collections.Hashtable getSignPackage()
    {
        try
        {

            //string guid = System.Guid.NewGuid().ToString(); 
            string jsapiTicket = getJsApiTicket();
            //Jnwf.Utils.Log.Logger.Log4Net.Error("wxjssdk,jsapiTicket:" + jsapiTicket);
            string url = HttpContext.Current.Request.Url.ToString();
            //Jnwf.Utils.Log.Logger.Log4Net.Error("wxjssdk,url:" + url);
            string timestamp = Convert.ToString(ConvertDateTimeInt(DateTime.Now));
            //Jnwf.Utils.Log.Logger.Log4Net.Error("wxjssdk,timestamp:" + timestamp);
            string nonceStr = createNonceStr();
            //Jnwf.Utils.Log.Logger.Log4Net.Error("wxjssdk,nonceStr:" + nonceStr);
            // 这里参数的顺序要按照 key 值 ASCII 码升序排序  
            string rawstring = "jsapi_ticket=" + jsapiTicket + "&noncestr=" + nonceStr + "&timestamp=" + timestamp + "&url=" + url + "";

            string signature = SHA1_Hash(rawstring);

            System.Collections.Hashtable signPackage = new System.Collections.Hashtable();
            signPackage.Add("appId", appId);
            signPackage.Add("nonceStr", nonceStr);
            signPackage.Add("timestamp", timestamp);
            signPackage.Add("url", url);
            //signPackage.Add("guid", guid);
            signPackage.Add("signature", signature);
            signPackage.Add("rawString", rawstring);

            return signPackage;
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("wxjssdk,ex:" + ex.Message + "|" + ex.StackTrace);
        }
        return null;
    }
    //创建随机字符串  
    public string createNonceStr()
    {
        int length = 16;
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string str = "";
        Random rad = new Random();
        for (int i = 0; i < length; i++)
        {
            str += chars.Substring(rad.Next(0, chars.Length - 1), 1);
        }
        return str;
    }
    //得到ticket 如果文件里时间 超时则重新获取  
    private string getJsApiTicket()
    {
        string accessToken = "";
        string url = "";
        Jsapi api = null;

        Jnwf.Model.tb_JsapiTicketEntity model = Jnwf.BLL.tb_JsapiTicketBLL.GetInstance().GetModel(weixincode);
        if (model != null)
        {
            if (model.AddTime.AddHours(1) <= DateTime.Now)
            {
                accessToken = getAccessToken();
                url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
                api = JsonConvert.DeserializeObject<Jsapi>(httpGet(url));

                model.Ticket = api.ticket;
                model.AddTime = DateTime.Now;
                Jnwf.BLL.tb_JsapiTicketBLL.GetInstance().Update(model);
            }
            return model.Ticket;
        }
        else
        {
            accessToken = getAccessToken();
            url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token=" + accessToken + "";
            string json = httpGet(url);
            //Jnwf.Utils.Log.Logger.Log4Net.Info("getJsApiTicket:insert:" + json);
            api = JsonConvert.DeserializeObject<Jsapi>(json);

            model = new Jnwf.Model.tb_JsapiTicketEntity() { 
                 WeiXinCode = weixincode,
                 Ticket = api.ticket,
                 AddTime = DateTime.Now
            };
            Jnwf.BLL.tb_JsapiTicketBLL.GetInstance().Insert(model);
            return model.Ticket;
        }
        
    }
    public string GetCurrentAccessToken(string m_appid, string m_secret)
    {
        string m_AcessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential";

        WebClient webClient = new WebClient();

        Byte[] bytes = webClient.DownloadData(string.Format("{0}&appid={1}&secret={2}", m_AcessTokenUrl, m_appid, m_secret));
        string result = Encoding.GetEncoding("utf-8").GetString(bytes);
        string[] temp = result.Split(',');
        string[] tp = temp[0].Split(':');
        return tp[1].ToString().Replace('"', ' ').Trim().ToString();

    }
    //得到accesstoken 如果文件里时间 超时则重新获取  
    private string getAccessToken()
    {
        // access_token 应该全局存储与更新，以下代码以写入到文件中做示例
        string access_token = "";
        Jnwf.Model.tb_AccessTokenEntity model = Jnwf.BLL.tb_AccessTokenBLL.GetInstance().GetModel(weixincode);
        if (model != null)
        {
            if (model.AddTime.AddHours(1) <= DateTime.Now)
            {
                access_token = GetCurrentAccessToken(appId, appSecret);

                model.AccessToken = access_token;
                model.AddTime = DateTime.Now;

                Jnwf.BLL.tb_AccessTokenBLL.GetInstance().Update(model);
            }
            else
            {
                access_token = model.AccessToken;
            }
        }

        
        return access_token;
    }
    //发起一个http请球，返回值  
    private string httpGet(string url)
    {
        try
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
            Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据  
            string pageHtml = System.Text.Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句              

            return pageHtml;
        }
        catch (WebException webEx)
        {
            Console.WriteLine(webEx.Message.ToString());
            return null;
        }
    }
    //SHA1哈希加密算法  
    public string SHA1_Hash(string str_sha1_in)
    {
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        byte[] bytes_sha1_in = System.Text.UTF8Encoding.Default.GetBytes(str_sha1_in);
        byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
        string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
        str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
        return str_sha1_out;
    }


    /// <summary>  
    /// StreamWriter写入文件方法  
    /// </summary>  
    //private void StreamWriterMetod(string str, string patch)
    //{
    //    try
    //    {
    //        FileStream fsFile = new FileStream(patch, FileMode.OpenOrCreate);
    //        StreamWriter swWriter = new StreamWriter(fsFile);
    //        swWriter.WriteLine(str);
    //        swWriter.Close();
    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }
    //}
    /// <summary>  
    /// 将c# DateTime时间格式转换为Unix时间戳格式  
    /// </summary>  
    /// <param name="time">时间</param>  
    /// <returns>double</returns>  
    public int ConvertDateTimeInt(System.DateTime time)
    {
        int intResult = 0;
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        intResult = Convert.ToInt32((time - startTime).TotalSeconds);
        return intResult;
    }
}

//创建Json序列化 及反序列化类目  
#region
//创建JSon类 保存文件 jsapi_ticket.json  
public class JSTicket
{

    public string jsapi_ticket { get; set; }

    public double expire_time { get; set; }
}
//创建 JSon类 保存文件 access_token.json  

public class AccToken
{

    public string access_token { get; set; }

    public double expires_in { get; set; }
}


//创建从微信返回结果的一个类 用于获取ticket  

public class Jsapi
{

    public int errcode { get; set; }

    public string errmsg { get; set; }

    public string ticket { get; set; }

    public string expires_in { get; set; }
}
#endregion  