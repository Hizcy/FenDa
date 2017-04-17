<%@ WebHandler Language="C#" Class="uploadAmr" %>

using System;
using System.Web;
using System.IO;
using System.Net;                                                  

public class uploadAmr : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

} 