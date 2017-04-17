<%@ WebHandler Language="C#" Class="test2" %>

using System;
using System.Web;
using System.Net;
using System.Net.Security;
using System.IO;

public class test2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        GetWxPic("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=S0IIdUTIn2Iym4RAfWrSSb1d_9LaMPwSwVYSvezg1ANrNeXm-FCcddIf954-5AKwkNneyoKwcDgKUv5Ku7flN-WO092HlVTSN_PruDkvz2ZeGMD7EuiqcD1KHl38Ek2mUWUcADAFHF&media_id=u6MRxj8hEhzWWMUGoXJ3lv14IwGy8BB2sZyvMIZIXlTCZLMz7kju3JccBEn9QXBh", "");
    }  
    public static string GetWxPic(string url, string data)
    {
        string path = ""; 
        try
        {
            //ServicePointManager.Expect100Continue = false;
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (data == "" ? "" : "?" + data));
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //string fileName = Common.RightStr(response.Headers["Content-disposition"], "filename=", false).Replace("\"", "");
                    path = "/arm/u6MRxj8hEhzWWMUGoXJ3lv14IwGy8BB2sZyvMIZIXlTCZLMz7kju3JccBEn9QXBh.amr";
                    //if(!File.Exists(HttpContext.Current.Server.MapPath("~/arm/u6MRxj8hEhzWWMUGoXJ3lv14IwGy8BB2sZyvMIZIXlTCZLMz7kju3JccBEn9QXBh.amr")))
                    //{
                    //    File.Create(HttpContext.Current.Server.MapPath("~/arm/u6MRxj8hEhzWWMUGoXJ3lv14IwGy8BB2sZyvMIZIXlTCZLMz7kju3JccBEn9QXBh.amr"));
                        
                    //}
                    Stream responseStream = response.GetResponseStream();
                    BinaryReader br = new BinaryReader(responseStream);

                    FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(path), FileMode.Create, FileAccess.Write);

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

                }
                else
                {
                    response.Close();
                    path = "";
                }

            }
        }
        catch (Exception)
        {
            path = "";
        }
        return path;
    }  
    
    public bool IsReusable {
        get {
            return false;
        }
    }
    /// <summary>
    /// 验证证书
    /// </summary>
    private static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors errors)
    {
        if (errors == SslPolicyErrors.None)
            return true;
        return false;
    }  
}