<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //Thumbnail.uploadQinui("JD7XqOKgCx1qNB79RR8ndC6L2lehoKsknodpgaxTLj_jQT8SO1AZWCgIeSNEN-vh.amr", "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=DxBKrVs2L9bVMQL6idw-t66GsQNkRfI-KA2INdkTxsRqKXN20EzGvfaG2isXELGKXMyy6YlGXG0uFugyzFdAWg-5Jt4rRsugBV3f0gzNpmU3ETiq2JnNv5SS0hzi9TnaFBVjAAAUQK&media_id=JD7XqOKgCx1qNB79RR8ndC6L2lehoKsknodpgaxTLj_jQT8SO1AZWCgIeSNEN-vh");
       //context.Response.Redirect("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=DxBKrVs2L9bVMQL6idw-t66GsQNkRfI-KA2INdkTxsRqKXN20EzGvfaG2isXELGKXMyy6YlGXG0uFugyzFdAWg-5Jt4rRsugBV3f0gzNpmU3ETiq2JnNv5SS0hzi9TnaFBVjAAAUQK&media_id=JD7XqOKgCx1qNB79RR8ndC6L2lehoKsknodpgaxTLj_jQT8SO1AZWCgIeSNEN-vh");

        string serverUrl = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("url");
        string appid = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("appid");
        string secret = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("secret");
        string name = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".mp3";
        serverUrl = Path.Combine(serverUrl, "amr/" +name);
        string urlToken = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret + "";
        Token token = Jnwf.Utils.Json.JsonHelper.DeserializeJson<Token>(Jnwf.Utils.Helper.HttpHelper.LoadPageContent(urlToken));
        string url = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=S0IIdUTIn2Iym4RAfWrSSb1d_9LaMPwSwVYSvezg1ANrNeXm-FCcddIf954-5AKwkNneyoKwcDgKUv5Ku7flN-WO092HlVTSN_PruDkvz2ZeGMD7EuiqcD1KHl38Ek2mUWUcADAFHF&media_id=u6MRxj8hEhzWWMUGoXJ3lv14IwGy8BB2sZyvMIZIXlTCZLMz7kju3JccBEn9QXBh";

        //为指定的URL创建新的实例
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        // request.ContentType = "";
        request.ContentType = "text/html/*;charset=UTF-8";  
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();

        BinaryReader br = new BinaryReader(myResponseStream);

        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/amr/"), FileMode.Create, FileAccess.Write);

        const int buffsize = 1024;
        byte[] bytes = new byte[buffsize];
        int totalread = 0;

        int numread = buffsize;
        while (numread != 0)
        {
            // read from source  
            numread = br.Read(bytes, 0, buffsize);
            totalread += numread;

            // write to disk  
            fs.Write(bytes, 0, numread);
        }

        br.Close();
        fs.Close();

        response.Close();
        
        
        
        
        
        
        
        
        //StreamReader myStreamReader = new StreamReader(myResponseStream); 
        //string retString = myStreamReader.ReadLine();
        //string path = context.Server.MapPath("~/arm/");  
        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);
        //}  
        //using (StreamWriter sw = new StreamWriter(path+name))
        //{
        //    sw.Write(retString);
        //    sw.Close();
        //}
    }
    
    /// <summary>
    /// 从指定的URL下载页面内容(使用WebClient)
    /// </summary>
    /// <param name="url">指定URL</param>
    /// <returns></returns>
    public static string LoadPageContent(string url)
    {
        return LoadPageContent(url, "utf-8"); 
    } 
    
    /// <summary>
    /// 从指定的URL下载页面内容(使用WebClient)
    /// </summary>
    /// <param name="url"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string LoadPageContent(string url, string encoding)
    {
        WebClient wc = new WebClient();
        wc.Credentials = CredentialCache.DefaultCredentials;
        byte[] pageData = wc.DownloadData(url);

        return (Encoding.GetEncoding(encoding).GetString(pageData)); 
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}
public class Token
{
    public string access_token { get; set; }
    public string expires_in { get; set; }
}
public class Result
{
    public string serverId { get; set; }
    public string errMsg { get; set; }
}