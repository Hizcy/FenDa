<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="company_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="拍照或从手机相册中选图接口" id="btn_chooseImage" /><br />
        <input type="button" value="上传图片接口" id="btn_uploadImage" /><br /> 
        <label id="lab1"></label>
        <label id="lab2"></label>
    </div>
    </form>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.1.0.js"></script>
    <script>
        var dataForWeixin = {
            appId: "<%=appid %>",
             timestamp: '<%=timestamp %>',
             nonceStr: '<%=nonce %>',
             signature: '<%=signature %>',
            jsApiList: ['chooseImage', 'uploadImage']
         };
         wx.config({
             debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
             appId: dataForWeixin.appId, // 必填，公众号的唯一标识
             timestamp: dataForWeixin.timestamp, // 必填，生成签名的时间戳
             nonceStr: dataForWeixin.nonceStr, // 必填，生成签名的随机串
             signature: dataForWeixin.signature,// 必填，签名，见附录1
             jsApiList: dataForWeixin.jsApiList  // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
         });
         wx.ready(function () {
             var chooseImage = document.getElementById('btn_chooseImage');
             var uploadImage = document.getElementById('btn_uploadImage'); 
             var chooseImageId;
             //拍照或从手机相册中选图接口
             chooseImage.onclick = function () {
                 wx.chooseImage({
                     count: 1, // 默认9
                     sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
                     sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
                     success: function (res) {
                         chooseImageId = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片
                     }
                 });
             };
             //上传图片接口
             uploadImage.onclick = function () {
                 wx.uploadImage({
                     localId: chooseImageId, // 需要上传的图片的本地ID，由chooseImage接口获得  
                     //isShowProgressTips: 1, // 默认为1，显示进度提示  
                     success: function (res) {
                         document.getElementById("lab1").innerHTML = res.serverId; // 返回图片的服务器端ID  
                         
                     },
                     fail: function (error) { 
                         alert(Json.stringify(error)); 
                     } 
                 });
                 document.getElementById("lab2").innerHTML =11; // 返回图片的服务器端ID  
             }; 
         })
    </script>
</body>
</html>
