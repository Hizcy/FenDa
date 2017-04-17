<%@ WebHandler Language="C#" Class="upload" %>

using System;
using System.Web;
using System.IO;

public class upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8"; 
        string serveUrl = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("url") + "upimg/";
        try
        { 
            var files = context.Request.Files; 
            if (files.Count <= 0)
            {
                return;
            }
            HttpPostedFile file = files[0];
            if (file == null)
            {
                context.Response.Write(-1);
                return;
            }
            else
            {
                if (file.ContentType.Split('/')[0] != "image")
                {
                    context.Response.Write(-1);
                    return;
                }
                //存储图片的文件夹（绝对路径）可配置
                string path = context.Server.MapPath("~/upimg/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //获取文件名称（名字.png） 
                string originalFileName = file.FileName;
                //获取文件类型
                string fileExtension = originalFileName.Substring(originalFileName.LastIndexOf('.'), originalFileName.Length - originalFileName.LastIndexOf('.'));
                //文件重命名
                string currentFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;  //文件名中不要带中文，否则会出错 
                //生成文件路径（绝对路径）
                string imagePath = path + currentFileName; 
                string simagePath = path +"s_"+ currentFileName; 
                //保存文件
                file.SaveAs(imagePath);
                Thumbnail.MakeThumbnail(imagePath, simagePath, 0, 65, "H");
                string imgUrl = serveUrl + "s_" + currentFileName; 
                //返回图片url地址
                context.Response.Write(imgUrl);
                return; 
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data-upload.aspx:" + ex.Data + "|" + ex.Message);
            context.Response.Write(-1);
        } 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}