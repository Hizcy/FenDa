<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionLlist.aspx.cs" Inherits="company_QuestionLlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title>问答列表</title>
    <link href="../css/userquestion.css" rel="stylesheet" />
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/weiui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server"> 
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
        <div class="div_shide" style="margin-bottom: 45px;background-color: #efeff4" >
            <asp:Repeater ID="rptQuestionlist" runat="server">
                <ItemTemplate>
                    <a class="a_xiangqing" href="SolutionQuestion.aspx?id=<%#Eval("Id") %>">
                        <ul class="show_Question">
                            <li>
                                <div class="div_sanjiaos">
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
                                                <td class="td_img">
                                                    <input type="hidden" value="<%#Eval("id") %>" class="hid" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="div_count">
                                    <img src="../images/clock.png" width="10" />
                                    <%#Eval("Addtime") %>
                                    <div class="div_number">等待回答</div>
                                </div>
                            </li>
                        </ul> 
                    </a> 
                </ItemTemplate>
            </asp:Repeater>
            <div style="text-align: center; margin-bottom: 15px; display: none" id="div_loadingListenInlist">继续加载</div>
        </div>
        <%-- 选项卡 --%>
        <div class="div_my">
            <ul class="ul_qihuan">
                <a href="QuestionLlist.aspx">
                    <li class="li_1 pihuan_color">最新提问</li>
                </a>
                <a href="Index.aspx">
                    <li class="li_2 pihuan_colors">我的信息</li>
                </a>
            </ul>
        </div>
    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        $(function () {
            //微信二维码隐藏弹出层
            $("#showceng").click(function () {
                $(this).hide();
            });
        })
        //弹出微信二维码
        function showCode() {
            $("#showceng").show();
        }
    </script>
</body>
</html>
