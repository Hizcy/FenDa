<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="company_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="图片上传" id="btn_upload" /><br />
        <input type="button" value="图片上传到微信" id="btn_uploadImage" /><br />
        <input type="button" value="开始录音" id="btn_startRecord" /><br />
        <input type="button" value="停止录音" id="btn_stopRecord" /><br />
        <input type="button" value="播放录音" id="btn_playRecord" /><br />
        <input type="button" value="上传语音" id="btn_uploadRecord" /><br />
        <input type="button" value="下载语音" id="btn_downloadVoice" /><br />
        <input type="button" value="播放" id="btn_test" /><br />

        <audio>
            <source src="weixin://resourceid/81b45d6f0906ffcb2a430a23c9a8be41" type="audio/ogg" /> 
        </audio>

        <audio src="weixin://resourceid/81b45d6f0906ffcb2a430a23c9a8be41">播放</audio>


        <label id="lab1"></label>
        <label id="lab2"></label>
        <label id="lab3"></label>
        <label id="lab4"></label>

    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script>
        var dataForWeixin = {
            appId: "<%=appid %>",
            timestamp: '<%=timestamp %>',
            nonceStr: '<%=nonce %>',
            signature: '<%=signature %>',
            jsApiList: ['chooseImage', 'stopRecord', 'playVoice', 'uploadVoice', 'downloadVoice','uploadImage']
        };
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: dataForWeixin.appId, // 必填，公众号的唯一标识
            timestamp: dataForWeixin.timestamp, // 必填，生成签名的时间戳
            nonceStr: dataForWeixin.nonceStr, // 必填，生成签名的随机串
            signature: dataForWeixin.signature,// 必填，签名，见附录1
            jsApiList: dataForWeixin.jsApiList  // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });
        var upImgbtn = document.getElementById('btn_upload');
        var uploadImage = document.getElementById("btn_uploadImage");
        var startRecord = document.getElementById("btn_startRecord");
        var stopRecord = document.getElementById("btn_stopRecord");
        var playRecord = document.getElementById("btn_playRecord");
        var uploadRecord = document.getElementById("btn_uploadRecord");
        var downloadVoice = document.getElementById("btn_downloadVoice");
        var test = document.getElementById("btn_test");
        wx.ready(function () {

            var request;
            if (window.XMLHttpRequest) {//判断浏览器是否支持XMLHttpRequest
                request = new XMLHttpRequest();//IE7+,Firefox,Chrome,Opera,Safari....
            } else {
                request = new ActiveXObject();//IE6 IE5支持
            }
            var imgserverid;
            upImgbtn.onclick = function () {
                wx.chooseImage({
                    count: 2, // 默认9
                    sizeType: ['original', 'compressed'], // 可以指定是原图还是压缩图，默认二者都有
                    sourceType: ['album', 'camera'], // 可以指定来源是相册还是相机，默认二者都有
                    success: function (res) {
                        var localIds = res.localIds; // 返回选定照片的本地ID列表，localId可以作为img标签的src属性显示图片  
                        //document.getElementById("show_img").src = localIds;
                       // document.getElementById("lab1").innerHTML = localIds;
                        imgserverid = localIds;
                    }
                });
            };
            uploadImage.onclick = function () { 
                wx.uploadImage({
                    localId: imgserverid, // 需要上传的图片的本地ID，由chooseImage接口获得  
                    isShowProgressTips: 1, // 默认为1，显示进度提示  
                    success: function (res) {
                        var mediaId = res.serverId; // 返回图片的服务器端ID  
                        alert(1);
                        document.getElementById("lab1").innerHTML = mediaId;
                    },
                    fail: function (error) { 
                        alert(Json.stringify(error)); 
                    } 
                });
            }
            //开始录音
            startRecord.onclick = function () {
                wx.startRecord();
                //监听录音自动停止
                wx.onVoiceRecordEnd({
                    // 录音时间超过一分钟没有停止的时候会执行 complete 回调
                    complete: function (res) {
                        var localId = res.localId;
                        document.getElementById("lab2").innerHTML = localId;
                    }
                });
            };
            var locationPath = "";// 需要播放的音频的本地ID，由stopRecord接口获得
            var serverPath = "";// 需要下载的音频的服务器端ID，由uploadVoice接口获得
            //停止录音
            stopRecord.onclick = function () {
                wx.stopRecord({
                    success: function (res) {
                        var localId = res.localId;
                        locationPath = localId;
                        document.getElementById("lab2").innerHTML = localId;
                    }
                });
            };
            playRecord.onclick = function () {
                wx.playVoice({
                    localId: locationPath // 需要播放的音频的本地ID，由stopRecord接口获得
                });
            };
            uploadRecord.onclick = function () {
                wx.uploadVoice({
                    localId: locationPath, // 需要上传的音频的本地ID，由stopRecord接口获得
                    isShowProgressTips: 1, // 默认为1，显示进度提示
                    success: function (res) {
                        var serverId = res.serverId; // 返回音频的服务器端ID
                        document.write(serverId);
                        serverPath = serverId;
                        document.getElementById("lab3").innerHTML = localId;
                        $.getJSON("../data/uploadArm.ashx", { json:JSON.stringify(res) }, function () {
                            alert("成功");
                        })

                        //request.open("GET", "../test.ashx", true);
                        //request.send("Content-type", "application/x-www-form-urlencoded");
                        //request.send("url");
                    }
                });
            };
            downloadVoice.onclick = function () {
                wx.downloadVoice({
                    serverId: serverPath, // 需要下载的音频的服务器端ID，由uploadVoice接口获得
                    isShowProgressTips: 1, // 默认为1，显示进度提示
                    success: function (res) {
                        var localId = res.localId; // 返回音频的本地ID
                        document.getElementById("lab4").innerHTML = localId;

                    }
                });
            }

            test.onclick = function () {
                wx.playVoice({
                    localId: 'weixin://resourceid/81b45d6f0906ffcb2a430a23c9a8be41' // 需要播放的音频的本地ID，由stopRecord接口获得
                });
            }
        })
    </script>
</body>
</html>


