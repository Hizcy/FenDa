<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyInfor.aspx.cs" Inherits="user_MyInfor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no" />
    <title>我的</title>
    <link href="../css/userquestion.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-bottom: 5px;">
            <img src="../images/beijing.jpg" style="width: 100%;" />
            <img src="<%=headImg %>" class="div_imghead" />
            <div class="div_gname"><%=nickName %></div>
        </div>
        <%-- 问答 --%>
        <div class="div_wenda">
            <div class="div_qiehuan">
                <div id="div_xx" style="text-align: center; font-size: 14px;">
                    <span class="sp_piehuan2" style="border-bottom-left-radius: 5px; border-top-left-radius: 5px;">我提问的</span><span class="sp_piehuan" style="border-bottom-right-radius: 5px; border-top-right-radius: 5px;">我听过的</span>
                </div>
            </div>
            <div class="div_tishi <%=linstenInNum>0?"hide":"" %>">暂无数据</div>
            <div class="div_shide hide">
                <asp:Repeater ID="rptQuestionlist" runat="server">
                    <ItemTemplate>
                        <ul class="show_Question">
                            <li>
                                 <a class="a_xiangqing" href="QuestionInfor.aspx?Id=<%#Eval("id") %>&companyId=<%=companyId %>">
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
                                                    <td class="td_img">
                                                        <input type="hidden" value="<%#Eval("id") %>" class="hid" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </a>
                                  <%#Eval("name").ToString()!="0"?"<div class=\"div_daan\"></div><div style=\"margin-top: 20px\"><img class=\"img_heads\" src=\""+Eval("HeadImg")+"\"><div class=\"div_mui\"><div class=\"div_name\">"+Eval("name")+"</div><div class=\"div_question\">"+Eval("Solution")+"</div></div></div><div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" />"+Eval("solutionTime")+"<div class=\"div_number\">"+Eval("listeninNum")+"人收听</div></div>":"<div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\"> 还未回答<div class=\"div_number\">0人收听</div></div>" %>
                              <%--  <%#Eval("name").ToString()!="0"?"<div class=\"div_daan\"></div><div style=\"margin-top: 20px\"><img class=\"img_heads\" src=\""+Eval("HeadImg")+"\"><div class=\"div_body\"><div class=\"div_answer\"><img src=\"../images/AS.png\" class=\"img_answer\" /><div class=\"div_bofang\">点击播放</div><div class=\"div_bofang\" style=\"display: none\">播放中...</div></div></div><div class=\"div_time\">45``</div></div><div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" />"+Eval("solutionTime")+"<div class=\"div_number\">"+Eval("listeninNum")+"人收听</div></div>":"<div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\"> 还未回答<div class=\"div_number\">0人收听</div></div>" %>--%>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="text-align: center; margin-bottom: 15px;" id="div_loadingQuestionlist" class="<%=questionNum<10?"hide":"" %>">继续加载</div>
            </div>
            <div class="div_shide">
                <asp:Repeater ID="rptListenInlist" runat="server">
                    <ItemTemplate>
                        <ul class="show_Question">
                            <li>
                                <a class="a_xiangqing" href="QuestionInfor.aspx?id=<%#Eval("Id") %>">
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
                                                    <td class="td_img">
                                                        <input type="hidden" value="<%#Eval("id") %>" class="hid" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="div_daan">
                                    </div>
                                </a>
                                <div style="margin-top: 20px">
                                    <img class="img_heads" src="<%#Eval("HeadImg")%>">
                                    <div class="div_body">
                                        <div class="div_answer">
                                            <img src="../images/AS.png" class="img_answer" />
                                            <div class="div_bofang">点击播放</div>
                                            <div class="div_bofang" style="display: none">播放中...</div>
                                        </div>
                                    </div>
                                    <div class="div_time">45``</div>
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
                <div style="text-align: center; margin-bottom: 15px;" id="div_loadingListenInlist" class='<%=linstenInNum<10?"hide":"" %>'>继续加载</div>
            </div>
        </div>
        <div style="position: fixed; background-color: #efeff4; height: 100%; width: 100%">
        </div>
        <%-- 选项卡 --%>
        <div class="div_my">
            <ul class="ul_qihuan">
                <a href="WDList.aspx">
                    <li class="li_1 pihuan_colors">问答</li>
                </a>
                <a href="MyInfor.aspx">
                    <li class="li_2 pihuan_color">我的</li>
                </a>
            </ul>
        </div>
    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        $(function () {

            //选项卡
            $("#div_xx").on("click", "span", function () {
                var index = $(this).index();
                if (index === 0) {
                    $(".div_wenda").children().eq(2).removeClass("hide").next().addClass("hide");
                    var questionNum = '<%=questionNum %>';
                    if (parseInt(questionNum) > 0) {
                        $(".div_tishi").addClass("hide");
                    }
                    else {
                        $(".div_tishi").removeClass("hide");
                    }
                }
                else if (index === 1) {
                    $(".div_wenda").children().eq(3).removeClass("hide").prev().addClass("hide");
                    var linstenInNum = '<%=linstenInNum %>';
                    if (parseInt(linstenInNum) > 0) {
                        $(".div_tishi").addClass("hide");
                    }
                    else {
                        $(".div_tishi").removeClass("hide");
                    }
                }
                $(this).removeClass("sp_piehuan2").addClass("sp_piehuan").siblings().removeClass("sp_piehuan").addClass("sp_piehuan2");
            })

            //继续加载
            $("#div_loadingQuestionlist").click(function () {
                var id = $(this).prev().find("input").last().val(); 
                var openId = "<%=openId %>";
                var companyId = "<%=companyId %>"; 
                console.log(id + "|" + openId + "|" + companyId);
                $.post("../data/data.aspx", { type: "loadingQuestionlist", openid: openId, companyid: companyId, id: id }, function (result) {
                    console.log(result);
                    var json = JSON.parse(result);
                    if (json.MessageBox === "OK") {
                        $("#div_loadingQuestionlist").before(json.data);
                        if (parseInt(json.number) < 10) {
                            $("#div_loadingQuestionlist").unbind().html("已是全部数据");
                        }
                    }
                    else {
                        $("#div_loadingQuestionlist").unbind().html("已是全部数据");
                    }
                })
            });
            $("#div_loadingListenInlist").click(function () {
                var id = $(this).prev().find("input .hid:last").val();
                var openId = "<%=openId %>";
                var companyId = "<%=companyId %>";
                $.post("../data/data.aspx", { type: "loadingListenInlist", openid: openId, companyid: companyId, id: id }, function (result) {
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
            })
        })
    </script>
</body>
</html>
