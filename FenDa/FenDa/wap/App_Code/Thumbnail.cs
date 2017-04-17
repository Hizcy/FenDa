using Qiniu.IO;
using Qiniu.RS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web; 


/// <summary>
/// Thumbnail 的摘要说明
/// </summary>
public class Thumbnail
{
    public static string serveUrl = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("url") + "upimg/";
    public static string qinuiUrl = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("QINUIURL");
    static string AK = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("AK");
    static string SK = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("SK");
    static string NAME = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("NAME");
    //static 
	public Thumbnail()
	{ 
	}
    /// 〈summary> 
    /// 生成缩略图 
    /// 〈/summary> 
    /// 〈param name="originalImagePath">源图路径（物理路径）〈/param> 
    /// 〈param name="thumbnailPath">缩略图路径（物理路径）〈/param> 
    /// 〈param name="width">缩略图宽度〈/param> 
    /// 〈param name="height">缩略图高度〈/param> 
    /// 〈param name="mode">生成缩略图的方式〈/param>   
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）            
                break;
            case "W"://指定宽，高按比例                 
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例 
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）            
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板 
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充 
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分 
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        { 
            //以jpg格式保存缩略图 
            bitmap.Save(thumbnailPath);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /**/
    /// 〈summary> 
    /// 在图片上增加文字水印 
    /// 〈/summary> 
    /// 〈param name="Path">原服务器图片路径〈/param> 
    /// 〈param name="Path_sy">生成的带文字水印的图片路径〈/param> 
    protected void AddWater(string Path, string Path_sy)
    {
        string addText = "www.tzwhx.com";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 10);    //字体位置为左空10 
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 14, 14);    //字体大小为14X14 
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }

    /**/
    /// 〈summary> 
    /// 在图片上生成图片水印 
    /// 〈/summary> 
    /// 〈param name="Path">原服务器图片路径〈/param> 
    /// 〈param name="Path_syp">生成的带图片水印的图片路径〈/param> 
    /// 〈param name="Path_sypf">水印图片路径〈/param> 
    protected void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();

        image.Save(Path_syp);
        image.Dispose();
    }
    /// <summary>
    /// 上传七牛图片
    /// </summary>
    /// <param name="ak">AK</param>
    /// <param name="sk">SK</param>
    /// <param name="kname">上传的空间</param>
    /// <param name="imgkey">图片名称</param>
    /// <param name="imgPath">图片路径</param>
    public static void uploadQinui(string ak, string sk, string kname, string imgkey, string imgPath)
    {
        try
        {
            //设置账号的AK和SK
            Qiniu.Conf.Config.ACCESS_KEY = ak;
            Qiniu.Conf.Config.SECRET_KEY = sk;
            IOClient target = new IOClient();
            PutExtra extra = new PutExtra();
            //设置上传的空间
            String bucket = kname;
            //设置上传的文件的key值
            String key = imgkey;

            //普通上传,只需要设置上传的空间名就可以了,第二个参数可以设定token过期时间
            PutPolicy put = new PutPolicy(bucket, 3600);

            //调用Token()方法生成上传的Token
            string upToken = put.Token();
            //上传文件的路径
            String filePath = imgPath;
            Jnwf.Utils.Log.Logger.Log4Net.Error("uploadQinui2:" + filePath + "");
            //调用PutFile()方法上传
            PutRet ret = target.PutFile(upToken, key, filePath, extra);
            Jnwf.Utils.Log.Logger.Log4Net.Error("uploadQinui1:" + ret + "");
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("error:uploadQinui:" + ex.Message + "|" + ex.InnerException);
        }
    }
    /// <summary>
    /// 上传七牛图片
    /// </summary>
    /// <param name="imgkey">图片名称</param>
    /// <param name="imgPath">图片路径</param>
    public static void uploadQinui(string imgkey,string imgPath)
    {
        try
        {
            //设置账号的AK和SK
            Qiniu.Conf.Config.ACCESS_KEY = AK;
            Qiniu.Conf.Config.SECRET_KEY = SK;
            IOClient target = new IOClient();
            PutExtra extra = new PutExtra();
            //设置上传的空间
            String bucket = NAME;
            //设置上传的文件的key值
            String key = imgkey;

            //普通上传,只需要设置上传的空间名就可以了,第二个参数可以设定token过期时间
            PutPolicy put = new PutPolicy(bucket, 3600);

            //调用Token()方法生成上传的Token
            string upToken = put.Token(); 
            //调用PutFile()方法上传
            PutRet ret = target.PutFile(upToken, key, imgPath, extra);
            if (!ret.OK)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("error:uploadQinui:" + ret.OK + "|" + ret.Exception);
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("error:uploadQinui:" + ex.Message + "|" + ex.InnerException);
        } 
    }
}