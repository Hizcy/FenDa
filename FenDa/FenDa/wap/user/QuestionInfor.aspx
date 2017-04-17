<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionInfor.aspx.cs" Inherits="user_QuestionInfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title>问答详情</title>
    <link href="../css/userquestion.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
                    <img src="<%=headImg %>" class="img_head">
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
                    <ul class="show_Question" style="margin-top: 0px; border-bottom: 1px solid #bec1c1">
                        <li>
                            <div class="div_daans">
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
                             <%#Eval("name").ToString()!="0"?"<div class=\"div_daan\"></div><div style=\"margin-top: 20px\"><img class=\"img_heads\" src=\""+Eval("HeadImg")+"\"><div class=\"div_mui\"><div class=\"div_name\">"+Eval("name")+"</div><div class=\"div_question\">"+Eval("Solution")+"</div></div></div><div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" />"+Eval("solutionTime")+"<div class=\"div_number\">"+Eval("listeninNum")+"人收听</div></div>":"<div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\"> 还未回答<div class=\"div_number\">0人收听</div></div>" %>
                           <%-- <%#Eval("name").ToString() !="0"?"<div class=\"div_daans\"></div><div style=\"margin-top: 20px\"><img class=\"img_heads\" src=\""+Eval("HeadImg")+"\"><div class=\"div_body\"><div class=\"div_answer\"><img src=\"../images/AS.png\" class=\"img_answer\" /><div class=\"div_bofang\">点击播放</div><div class=\"div_bofang\" style=\"display: none\">播放中...</div></div></div><div class=\"div_time\">45``</div></div><div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" />"+Eval("Addtime")+"<div class=\"div_number\">"+Eval("listeninNum")+"人收听</div></div>":"<div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" /> 还未回答<div class=\"div_number\">0人收听</div></div>" %>--%>
                        </li>
                        <li style="width: 80%; margin: auto;">
                            <a href="WDList.aspx" class="a_tiwen">我要问医生</a>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        $(function () {
            $("#showceng").click(function () {
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
