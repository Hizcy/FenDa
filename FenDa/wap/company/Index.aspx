<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="company_Index" %>

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
        <%-- 头部 --%>
        <ul class="ul_head">
            <li>
                <img src="<%=headImg %>" class="img_head" style="border-radius: 50%" />
                <div class="div_miaoshus">
                    <%=name %>
                    <p class="p_wcode"><%=abteilung %> | <%=titles %></p>
                </div>
                <i id="rightbiao" style="right: 10px;" class="img_weiimg"></i> 
                <div class="div_jianjie"><span style="font-weight: bold">简介</span>：<%=description %> </div>
                <div class="div_jianjie"><span style="font-weight: bold">擅长</span>：<%=clever %> </div>
            </li>
        </ul>
        <%-- 问答 --%>
        <div class="div_wenda">
            <%--<div class="div_qiehuan">
                <div id="div_xx" style="text-align: center; font-size: 14px;">
                    <span class="sp_piehuan" style="border-bottom-left-radius: 5px; border-top-left-radius: 5px;">我回答的</span><span class="sp_piehuan" style="border-bottom-right-radius: 5px; border-top-right-radius: 5px;">我听过的</span>
                </div>
            </div>--%>
            <div style="padding: 10px 0px 10px 10px;">全部回答(<%=solutionNumber %>)</div>
             <%-- <div class="div_tishi">暂无数据</div>--%>
            <div class="div_shide hide">
                <asp:Repeater ID="rptQuestionList" runat="server">
                    <ItemTemplate>
                        <ul class="show_Question">
                            <li>
                                <a class="a_xiangqing" href="QuestionInfor.aspx?Id=<%#Eval("Id") %>">
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
                                <%#int.Parse(Eval("listeninNum").ToString())>0?"<div class=\"div_daan\"></div><div style=\"margin-top: 20px\"><img class=\"img_heads\" src=\""+Eval("HeadImg")+"\"><div class=\"div_body\"><div class=\"div_answer\"><img src=\"../images/AS.png\" class=\"img_answer\" /><div class=\"div_bofang\">点击播放</div><div class=\"div_bofang\" style=\"display: none\">播放中...</div></div></div><div class=\"div_time\">45``</div></div><div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\" />"+Eval("Addtime")+"<div class=\"div_number\">"+Eval("listeninNum")+"人收听</div></div>":"<div class=\"div_count\"><img src=\"../images/clock.png\" width=\"10\"> 还未回答<div class=\"div_number\">0人收听</div></div>" %>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="text-align: center; margin-bottom: 15px;color:#808080;font-size:14px;" id="div_loadingQuestionlist">继续加载</div>
            </div>
            <div class="div_shide"> 
                <asp:Repeater ID="rptSoultionlist" runat="server">
                    <ItemTemplate>
                        <ul class="show_Question">
                            <li>
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
                                <div style="width: 100%; height: 20px"></div>
                                <div class="div_daans">
                                </div>
                                <img class="img_heads" src="<%=headImg %>">
                                <div class="div_mui">
                                    <div class="div_name"><%=name %></div>
                                    <div class="div_question">
                                        <%#Eval("Solution") %>
                                    </div>
                                </div>
                                <%--<div style="margin-top: 20px">
                                    <img class="img_heads" src="<%=headImg %>">
                                    <div class="div_body">
                                        <div class="div_answer">
                                            <img src="../images/AS.png" class="img_answer" />
                                            <div class="div_bofang">点击播放</div>
                                            <div class="div_bofang" style="display: none">播放中...</div>
                                        </div>
                                    </div>
                                    <div class="div_time">45``</div>
                                </div>--%>
                                <div class="div_count">
                                    <img src="../images/clock.png" width="10" />
                                    <%#Eval("solutionAddtime") %>
                                    <div class="div_number"><%#Eval("listeninNum") %>人收听</div>
                                </div>
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="text-align: center; margin-bottom: 15px;" id="div_loadingListenInlist">继续加载</div>
            </div>
        </div>
        <div style="position: fixed; background-color: #efeff4; height: 100%; width: 100%">
        </div>
        <%-- 选项卡 --%>
        <div class="div_my">
            <ul class="ul_qihuan">
                <a href="QuestionLlist.aspx">
                    <li class="li_1 pihuan_colors">最新提问</li>
                </a>
                <a href="Index.aspx">
                    <li class="li_2 pihuan_color">我的信息</li>
                </a>
            </ul>
        </div>
    </form>
</body>
</html>
