<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WDList.aspx.cs" Inherits="user_WDList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title>问答页</title>
    <link href="../css/userquestion.css?v=1" rel="stylesheet" />
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/weiui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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

        <div id="loadingToast" style="display: none;">
            <div class="weui-mask_transparent"></div>
            <div class="weui-toast">
                <i class="weui-loading weui-icon_toast"></i>
                <p class="weui-toast__content">上传中</p>
            </div>
        </div>
        <!----------------------------------END-------------------------------------------------->
        <%-- 二维码遮罩层 --%>
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
        <%-- 头部信息 --%>
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
            <li>
                <textarea class="txt_wenti" maxlength="200" placeholder="请输入你的问题……" id="appealcount"></textarea>
                <div class="weui_textarea_counter" style="color: #b2b2b2; text-align: right;">
                    <span id="nubmerin">0</span>/200
                </div>
            </li>
            <li>
                <%-- 上传图片 --%>
                <ul class="ul_img">
                    <li class="li_showimg">
                        <i class="wangeditor-menu-img-upload img_size" id="upload_but"></i>
                    </li>
                </ul>
            </li>
            <li>
                <input type="button" value="确认提交" class="btn_sument" />
            </li>
        </ul>
        <%-- 问答 --%>
        <div class="div_wenda">
            <div style="padding: 10px 0px 10px 10px;">全部回答(<%=solutionNumber %>)</div>
            <div class='div_tishi' style='<%=solutionNumber>0?"display:none": "" %>'>暂无数据</div>
            <asp:Repeater ID="repSolutionlist" runat="server">
                <ItemTemplate>
                    <ul class="show_Question">
                        <li>
                            <a class="a_xiangqing" href="QuestionInfor.aspx?Id=<%#Eval("questionId") %>&companyId=<%=companyId %>">
                                <div class="div_sanjiao">
                                </div>
                                <img class="img_heads" src="<%#Eval("HeadImgurl") %>">
                                <div class="div_mui">
                                    <div class="div_name"><%#Eval("NickName") %></div>
                                    <div class="div_question">
                                        <%#Eval("Question") %>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="td_img">
                                                    <%#Eval("SymptomImg1")!=""?"<img src=\""+Eval("SymptomImg1")+"\" class=\"img_show\" />":"" %> 
                                                </td>
                                                <td class="td_img">
                                                    <%#Eval("SymptomImg2")!=""?"<img src=\""+Eval("SymptomImg2")+"\" class=\"img_show\" />":"" %> 
                                                </td>
                                                <td class="td_img">
                                                    <%#Eval("SymptomImg3")!=""?"<img src=\""+Eval("SymptomImg3")+"\" class=\"img_show\" />":"" %> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="td_img">
                                                    <%#Eval("SymptomImg4")!=""?"<img src=\""+Eval("SymptomImg4")+"\" class=\"img_show\" />":"" %> 
                                                </td>
                                                <td class="td_img">
                                                    <%#Eval("SymptomImg5")!=""?"<img src=\""+Eval("SymptomImg5")+"\" class=\"img_show\" />":"" %> 
                                                </td>
                                                <td class="td_img"></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="div_daan">
                                </div>
                            </a>
                            <div style="margin-top: 20px">
                                <img class="img_heads" src="<%#Eval("HeadImg")%>">
                                <div class="div_mui">
                                    <div class="div_name"><%#Eval("name") %></div>
                                    <div class="div_question">
                                        <%#Eval("Solution") %>
                                    </div>
                                </div>
                                <%--<div class="div_body">
                                    <div class="div_answer">
                                        <img src="../images/AS.png" class="img_answer" />
                                        <div class="div_bofang">点击播放</div>
                                        <div class="div_bofang" style="display: none">播放中...</div>
                                    </div>
                                </div>
                                <div class="div_time">45``</div>--%>
                            </div>
                            <div class="div_count">
                                <img src="../images/clock.png" width="10" />
                                <%#Eval("Addtime") %>
                                <div class="div_number"><%#Eval("listeninNum") %>人收听</div>
                            </div>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
            <div style="text-align: center; margin-bottom: 15px;" id="div_loadingListenInlist" class='<%=solutionNumber<10?"hide":"" %>'>继续加载</div>
        </div>
        <%-- 选项卡 --%>
        <div class="div_my">
            <ul class="ul_qihuan">
                <a href="WDList.aspx">
                    <li class="li_1 pihuan_color">问答</li>
                </a>
                <a href="MyInfor.aspx">
                    <li class="li_2 pihuan_colors">我的</li>
                </a>
            </ul>
        </div>
    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../plupload/plupload.full.min.js"></script>
    <script>
        //存储所有图片的url地址
        var imgUrls = ",";
        //上传图片
        var uploader = new plupload.Uploader({ //实例化一个plupload上传对象
            browse_button: 'upload_but',
            url: '../data/upload.ashx',
            flash_swf_url: '../plupload/Moxie.swf',
            silverlight_xap_url: '../plupload/Moxie.xap',
            filters: {
                mime_types: [ //只允许上传图片文件
                  { title: "图片文件", extensions: "jpg,png,jpeg,mp3" }
                ]
            }
        });
        uploader.init(); //初始化 
        //绑定文件添加到队列的事件
        uploader.bind('FilesAdded', function (uploader, files) {
            if (files[0].size > 3145728) {
                uploader.files.length--;
                $(".weui-dialog__bd").html("图片大小不能超过3M！");
                $("#iosDialog2").show();
                return false;
            }
            if (uploader.files.length === 5) {
                $("#upload_but").hide();
            }
            // 文件添加之后，开始执行上传
            uploader.start();
        });
        //单个文件上传之后
        uploader.bind('FileUploaded', function (uploader, file, responseObject) {
            //注意，要从服务器返回图片的url地址，否则上传的图片无法显示在编辑器中http://
            var url = responseObject.response;
            //先将url地址存储来，待所有图片都上传完了，再统一处理 
            if (url != -1) {
                imgUrls += "" + url + ",";
                $(".ul_img").prepend("<li class=\"li_showimg\"><img src=\"" + url + "\" class=\"img_size\"/><i class=\"wangeditor-menu-img-cancel i_delete\" onclick=\"deleteimg(this)\"></i>");
            } else {
                uploader.files.length--;
                $(".weui-dialog__bd").html("图片上传失败！");
                $("#iosDialog2").show();
            }
        });


        //页面dome元素及其附带文件在完毕执行
        $(function () {
            //微信二维码隐藏弹出层
            $("#showceng").click(function () {
                $(this).hide();
            });

            function htmlEncode(str) {
                var s = "";
                if (str.length == 0) return "";
                s = str.replace(/&/g, "&amp;");
                s = s.replace(/</g, "&lt;");
                s = s.replace(/>/g, "&gt;");
                s = s.replace(/'/g, "&apos;");
                s = s.replace(/"/g, "&quot;");
                return s;
            };
            //提交
            $(".btn_sument").click(function () {
                if ($.trim($("#appealcount").val()).length === 0) {
                    $(".weui-dialog__bd").html("请填写内容！");
                    $("#iosDialog2").show();
                    return false;
                }
                $("#loadingToast").show();
                $.post("../data/data.aspx",
                    { type: "AddQuestion", openid: "<%=openid %>", question: htmlEncode($.trim($(".txt_wenti").val())), symptomimg: imgUrls, leixing: 1, companyId: "<%=companyId %>" },
                    function (result) {
                        $("#loadingToast").hide();
                        if (result == 1) {
                            $("#toast").show();
                            setTimeout(function () {
                                $("#toast").hide();
                            }, 1020);
                            //清空数据
                            $(".txt_wenti").val("");
                            uploader.files.length = 0;
                            imgUrls = ",";
                            $("#upload_but").show().parent().siblings().remove(); 
                            document.getElementById("nubmerin").innerText = 0;
                        }
                        else {
                            $(".weui-dialog__bd").html("添加失败！");
                            $("#iosDialog2").show();
                        }
                    });
            });
            //关闭弹出层
            $(".weui-dialog__btn").click(function () {
                $("#iosDialog2").hide();
            })
            //动态显示字数
            document.getElementById('appealcount').onkeydown = function () {
                document.getElementById("nubmerin").innerText = $(this).val().length;
            }
            document.getElementById('appealcount').onkeyup = function () {
                document.getElementById("nubmerin").innerText = $(this).val().length;
            }
        })

            //弹出微信二维码
            function showCode() {
                $("#showceng").show();
            }

            //删除上传图片
            function deleteimg(obj) {
                var objNum = $(".ul_img").children().length;
                if (objNum === 6) {
                    $("#upload_but").show();
                }
                uploader.files.length--;
                var url = $(obj).siblings().prop("src"); 
                $.post("../data/data.aspx", { type: "deleteImg", url: url });
                imgUrls = imgUrls.replace("" + url + ",", "");
                $(obj).parent().remove();
            }

            //继续加载
            $("#div_loadingListenInlist").click(function () {
                var id = $(this).prev().find("input").last().val();
                var companyId = "<%=companyId %>";
            $.post("../data/data.aspx", { type: "loadinglist", companyid: companyId, id: id }, function (result) {
                console.log(result);
                var json = JSON.parse(result);
                if (json.MessageBox === "OK") {
                    $("#div_loadingListenInlist").before(json.data);
                    if (parseInt(json.number) < 10) {
                        $("#div_loadingListenInlist").unbind().html("已是全部数据");
                    }
                }
                else {
                    $("#div_loadingListenInlist").unbind().html("已是全部数据");
                }
            })
        });
    </script>
</body>
</html>
