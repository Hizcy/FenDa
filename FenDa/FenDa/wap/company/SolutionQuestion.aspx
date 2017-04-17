<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolutionQuestion.aspx.cs" Inherits="company_SolutionQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title>回答问题</title>
    <link href="../css/userquestion.css" rel="stylesheet" />
    <link href="../css/weiui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="div_showImg" style="width: 100%; height: 100%; position: fixed; z-index: 9999; background-color: #000; top: 0px; text-align: center; display: none">
        </div>
        <!------------------------------------录音-------------------------------------------------->
        <div style="position: fixed; width: 100px; height: 90px; top: 50%; left: 50%; margin-left: -50px; margin-top: -45px; background-color: #808080; text-align: center;display:none" id="voiceicon">
            <img src="../images/voice.png" /><br />
            <span style="color: #ffffff">上滑动取消</span>
        </div>
        <!---------------------------------weiui--------------------------------------------------->
        <%-- 提示 --%>
        <div id="toast" style="opacity: 1; display: none;">
            <div class="weui-mask_transparent"></div>
            <div class="weui-toast">
                <i class="weui-icon-success-no-circle weui-icon_toast"></i>
                <p class="weui-toast__content">已完成</p>
            </div>
        </div>
        <div class="js_dialog" id="iosDialog2" style="opacity: 1; display: none">
            <div class="weui-mask"></div>
            <div class="weui-dialog">
                <div class="weui-dialog__bd"></div>
                <div class="weui-dialog__ft">
                    <a href="javascript:;" class="weui-dialog__btn weui-dialog__btn_primary">知道了</a>
                </div>
            </div>
        </div>
        <!----------------------------------END-------------------------------------------------->
        <%-- 遮罩层 --%>
        <div id="showceng" style="display: none">
            <div id="div_ceng">
            </div>
            <div id="div_cneirong">
                <ul class="ul_c">
                    <li>
                        <img src="<%=headImg %>" class="img_head" />
                        <div class="div_miaoshu">
                            <%=name %>
                            <p class="p_wcode">微信号：<%=wxCode %></p>
                        </div>
                    </li>
                    <li style="text-align: center">
                        <img src="<%=codeImg %>" style="width: 100%; max-height: 100%; margin-top: 30px;" />
                    </li>
                    <li class="li_biaozhu">扫描二维码关注微信公众号
                    </li>
                </ul>
            </div>
        </div>
        <%-- 头部 --%>
        <ul class="ul_head">
            <li>
                <a onclick="showCode()">
                    <img src="<%=headImg %>" class="img_head" />
                    <div class="div_miaoshus">
                        <%=name %>
                        <p class="p_wcode">微信号：<%=wxCode %></p>
                    </div>
                    <i id="rightbiao" style="right: 10px;" class="img_weiimg"></i>
                </a>
                <div class="div_jianjie">简介：<%=description %> </div>
            </li>
        </ul>
        <%-- 问答 --%>
        <div class="div_wenda">
            <asp:Repeater ID="repQuestion" runat="server">
                <ItemTemplate>
                    <ul class="show_Question" style="margin-top: 0px;">
                        <li>
                            <div class="div_sanjiaos">
                            </div>
                            <img class="img_heads" src="<%#Eval("HeadImgurl") %>">
                            <div class="div_muis">
                                <div class="div_name"><%#Eval("NickName") %></div>
                                <div class="div_question">
                                    <%#Eval("Question") %>
                                    <table style="width: 100%;" id="tb_img">
                                        <tr>
                                            <td class="td_img">
                                                <%#Eval("SymptomImg1")!=""?"<img src=\""+Eval("SymptomImg1")+"\" class=\"img_show\" data-num=\"1\" />":"" %> 
                                            </td>
                                            <td class="td_img">
                                                <%#Eval("SymptomImg2")!=""?"<img src=\""+Eval("SymptomImg2")+"\" class=\"img_show\" data-num=\"2\" />":"" %> 
                                            </td>
                                            <td class="td_img">
                                                <%#Eval("SymptomImg3")!=""?"<img src=\""+Eval("SymptomImg3")+"\" class=\"img_show\"  data-num=\"3\"/>":"" %> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="td_img">
                                                <%#Eval("SymptomImg4")!=""?"<img src=\""+Eval("SymptomImg4")+"\" class=\"img_show\"  data-num=\"4\"/>":"" %> 
                                            </td>
                                            <td class="td_img">
                                                <%#Eval("SymptomImg5")!=""?"<img src=\""+Eval("SymptomImg5")+"\" class=\"img_show\"  data-num=\"5\"/>":"" %> 
                                            </td>
                                            <td class="td_img"></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
            <div class="div_my">
                <ul style="width: 100%; text-align: center; color: #808080" id="li_Record">
                    <li >按住 说话</li>
                </ul>
            </div>
            <div style="height: 100%; position: fixed; background-color: #efeff4; width: 100%; z-index: -1; color: #ffffff"></div>
        </div>

    </form>
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        var dataForWeixin = {
            appId: "<%=appid %>",
            timestamp: '<%=timestamp %>',
            nonceStr: '<%=nonce %>',
            signature: '<%=signature %>',
            jsApiList: ['startRecord', 'stopRecord', 'onVoiceRecordEnd', 'uploadVoice']
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
            //当手指触摸屏幕时候触发
            document.getElementById("li_Record").addEventListener('touchstart', function () {
                //event.preventDefault();//阻止触摸时浏览器的缩放、滚动条滚动
                document.getElementById("voiceicon").style.display = "block";
                init.sx = event.targetTouches[0].pageX;
                init.sy = event.targetTouches[0].pageY;
                init.ex = init.sx;
                init.ey = init.sy;
                START = new Date().getTime();
                //要防止用户误操作（如：反复点击、误触摸）导致的无效录音。
                recordTimer = setTimeout(function () {
                    wx.startRecord({
                        success: function () {
                            localStorage.rainAllowRecord = 'true';
                        },
                        cancel: function () {
                            alert('用户拒绝授权录音');
                        }
                    });
                }, 300);

                document.getElementById("li_Record").addEventListener("touchmove", function () {
                    event.preventDefault();//阻止触摸时浏览器的缩放、滚动条滚动  
                    init.ex = event.targetTouches[0].pageX;
                    init.ey = event.targetTouches[0].pageY;
                    var changeX = init.sx - init.ex;
                    var changeY = init.sy - init.ey;
                    if (Math.abs(changeY) > Math.abs(changeX)) {
                        //上事件 
                        if (changeY > 3) {
                            clearTimeout(recordTimer);
                            document.getElementById("voiceicon").style.display = "block"; 
                        }
                    }
                })
            });
            //松手结束录音
            document.getElementById("li_Record").addEventListener("touchend", function () {
                event.preventDefault();//阻止触摸时浏览器的缩放、滚动条滚动
                document.getElementById("voiceicon").style.display = "block";
                END = new Date().getTime();
                if ((END - START) < 300) {
                    END = 0;
                    START = 0;
                    //小于300ms,不录音
                    clearTimeout(recordTimer);
                    $(".weui-dialog__bd").html("小于3秒不被记录！");
                    $("#iosDialog2").show();
                } else {
                    wx.stopRecord({
                        success: function (res) {
                            uploadVoice(res.localId);
                        },
                        fail: function (res) {
                            alert(JSON.stringify(res));
                        }
                    });
                }
            });
        });
        //上传录音
        function uploadVoice(localIds) {
            //调用微信的上传录音接口把本地录音先上传到微信的服务器
            //不过，微信只保留3天，而我们需要长期保存，我们需要把资源从微信服务器下载到自己的服务器
            wx.uploadVoice({
                localId: localIds, // 需要上传的音频的本地ID，由stopRecord接口获得
                isShowProgressTips: 1, // 默认为1，显示进度提示
                success: function (res) {
                    //把录音在微信服务器上的id（res.serverId）发送到自己的服务器供下载。
                    $.ajax({
                        url: '后端处理上传录音的接口',
                        type: 'post',
                        data: JSON.stringify(res),
                        dataType: "json",
                        success: function (data) {
                            alert('文件已经保存到七牛的服务器');//这回，我使用七牛存储
                        },
                        error: function (xhr, errorType, error) {
                            console.log(error);
                        }
                    });
                }
            });
        }
        $(function () {
            //微信二维码隐藏弹出层
            $("#showceng").click(function () {
                $(this).hide();
            });

            //动态显示当前输入字数
            document.getElementById('appealcount').onkeydown = function () {
                document.getElementById("nubmerin").innerText = $(this).val().length;
                if ($(this).val().length > 4) {
                    $(".a_tiwens").css("background-color", "#0ca141").attr("data-flag", "1");
                }
                else {
                    $(".a_tiwens").css("background-color", "#b4b2b0").attr("data-flag", "0");
                }

            }
            document.getElementById('appealcount').onkeyup = function () {
                document.getElementById("nubmerin").innerText = $(this).val().length;
                if ($(this).val().length > 4) {
                    $(".a_tiwens").css("background-color", "#0ca141").attr("data-flag", "1");
                }
                else {
                    $(".a_tiwens").css("background-color", "#b4b2b0").attr("data-flag", "0");
                }
            }
            //回答问题
            $(".a_tiwens").click(function () {
                var flag = $(this).attr("data-flag");
                if (flag == 1) {
                    if ($.trim($("#appealcount").val()) == "") {
                        $(".weui-dialog__bd").html("请填写内容！");
                        $("#iosDialog2").show();
                        return false;
                    }
                    $.post("../data/data.aspx", { type: "SolutionQuestion", employerid: '<%=employeId %>', questionid: '<%=questionId %>', tmptype: 1, solution: $.trim($("#appealcount").val()) }, function (result) {
                        if (result == 1) {
                            $("#toast").show();
                            setTimeout(function () {
                                window.location.href = "Index.aspx";
                            }, 1000);
                        } else if (result == -1) {
                            $(".weui-dialog__bd").html("提交失败，请重新提交！");
                            $("#iosDialog2").show();
                        } else if (result == -2) {
                            $(".weui-dialog__bd").html("已经有人抢答了！");
                            $("#iosDialog2").show();
                        }
                    })
                } else {
                    return false;
                }
            })
            $("#iosDialog2").click(function () {
                $(this).hide();
            });
            //显示原图
            $("#tb_img").on("click", "img", function () {
                var oldUrl = $(this).prop("src");
                var url = "<%=url %>upimg/s_";
                //http://oihgwpgwk.bkt.clouddn.com/P61221-141828.jpg?imageView2/2/w/320
                var newUrl = oldUrl.replace(url, "<%=qinuiUrl%>") + "?imageView2/2/w/320";
                $("#div_showImg").html("<img src='" + newUrl + "' style='max-width:100%;'/>");
                $("#div_showImg").show();
            });
            $("#div_showImg").click(function () {
                $(this).hide();
            })
        })
        //弹出微信二维码
        function showCode() {
            $("#showceng").show();
        }
    </script>
</body>
</html>
