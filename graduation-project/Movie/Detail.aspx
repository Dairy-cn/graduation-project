<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Detail.aspx.cs" Inherits="Movie_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Resource/css/gray/ui-page.css" rel="stylesheet" type="text/css" />
    <link href="../Resource/css/Info.css" rel="stylesheet" type="text/css" />

   
    <script type="text/javascript" src="./js/jquery-1.4.2.min.js"></script>
     <script language="javascript" type="text/javascript">
       
         var flag = true;
         var KaoQin = '<%=id %>';
         var StrCard = document.getElementById("ReadCardActiveX");
        $(function () {
      
            $('#btn_link').click(function (){

                if (isConnect = false) {

                    Connect();
                }
                
                
                
                
            });
            $('#btn_closeCard').click(function (){
           
                Close();
                
                
            });

            $('#btn_read').click(function () {
                ReadCard();
                
               
              
             	
            });

            $('#btn_submit').click(function () {

                ajax_post();

            });

            //返回
            $("#BtnBack").click(function () {
                window.location.href = "../KeChengList.aspx";
            });
            
        });

        //提交后台
        function ajax_post() {
            try {

                
                var CardStr = document.getElementById("<%=this.txtmusername.ClientID%>").value;
                var ClassId = document.getElementById("<%=HidClassId.ClientID%>").value;
              
                if (CardStr != "") {
                    $.ajax({
                        url: 'ajax.aspx',
                        type: 'POST',
                        dataType: 'json',
                        data: { "CardStrNum": CardStr, "KaoQinId": KaoQin, "Class": ClassId },
                        error: function () {
                            alert("数据提交失败");

                        },
                        success: callbackfun

                    });
                } else {
                    alert("先读卡才能签到哦！");


                }
                }
            catch (e) {
                alert('检查浏览器是否支付控件！');
            }
            
        }

        function callbackfun(data) {
            var obj = data;
            if (obj.success == "true" || obj.success == true) {
                alert(obj.msg);
               
            }
            else {
                alert(obj.msg);
            }
        }
    </script>


    </asp:Content>
   

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="cap_form" method="post" runat="server">
        <div class="item">
        <input type="hidden" value="0" runat="server" id="HidClassId" />
        <div class="title">
            打卡签到
        </div>
        </div>
        <div class="datagrid-pager">
            <table>
                <tr>
                    <td class="td-header">
                        班级:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddllist" Height="23px" Width="112px" OnSelectedIndexChanged="ddllist_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp; &nbsp;
                    </td>
                    <td>
                        统计:
                    </td>
                    <td>
                        班级总人数:
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        签到人数:
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        签到率:
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="datagrid-pager">
            <input type="hidden" id="picData" name="picData" />
            <table style="width: 100%">
                <tr>
                    <td align="right" style="width: 50%">
                        <br />
                        <br />        <input type="button" align="right"  value="返回" id="BtnBack" style="height: 24px" />
                        <div class="qiandaojiemian">
                     
                      
                         
                     
                       
                         <font face="宋体">
                                <asp:TextBox id="txtmusername"  runat="server" DESIGNTIMEDRAGDROP="98"
                                    Width="232px" Text="" style="display:none" ></asp:TextBox></font>

                       
                    
                             <input type="button" value="刷新" id="btn_link" style="height: 24px" />
                              <input type="button" value="读卡" id="btn_read" style="height: 24px" />
                              <input type="button" value="签到" id="btn_submit" style="height: 24px" />
                            
                           <input type="button" value="关闭读卡器" id="btn_closeCard" style="height: 24px" />

                            </div>
                  
                        <br />
                        <br />
                
                    
                    </td>
                </tr>
               
            </table>
        </div>
 
    </form>
     <p align="center"><textarea rows="20" id="TxtArea" cols="111"></textarea></p>
 
 
<p align="center">
     <object id="ReadCardActiveX" classid="clsid:A4933801-4419-4DCF-9090-8CC2A1A8DA86" codebase="ReadCardSetup.CAB#version=1.0.0" style="display: none;"></object>

    <script type="text/javascript" language="javascript">
        var activeX = document.getElementById("ReadCardActiveX");
        var msg = document.getElementById('TxtArea');
        var ReadCardF;

        var isConnect;
        window.onload=Connect();


     



        function Connect() {
            var ConnectF = "";
            isConnect = activeX.InitialcomCard();
            if (isConnect != -1) {



                ConnectF = "读卡器初始化成功，欢迎使用IC卡签到系统！"
                msg.value = msg.value + "" + ConnectF + "\n";


            }
            else {

                ConnectF = "读卡器初始化失败，请确认您的读卡器与电脑的连接是否正常后点击刷新按钮！";
                msg.value = msg.value + "" + ConnectF + "\n";
                

            }
        }
      

        function Close() {
            var CloseF;

            if (!activeX.CloseCard()) {

                CloseF = "读卡器关闭成功，谢谢您的使用！";
                msg.value = msg.value + "" + CloseF+"\n";


            } else {

                CloseF = "读卡器关闭异常，请重新关闭！";
                msg.value = msg.value + "" + CloseF + "\n";



            }


        }

        function ReadCard() {


            var ReadCardF;
            var ERROR;
            var f = activeX.ReadercardStr();

            if (f != "") {

                if (f != "false") {
                    ReadCardF = f;
                    msg.value = msg.value + "卡号为：" + ReadCardF + "的同学，请点击签到进行签到。" + "\n";

                    document.getElementById("<%=this.txtmusername.ClientID%>").value = ReadCardF;
                } else {
                    ERROR = "获取卡号失败，请确认您的卡的放置位置是否正确！"
                    msg.value = msg.value + "" + ERROR + "\n";
                    document.getElementById("<%=this.txtmusername.ClientID%>").value = ""

                }



            }else {

                ERROR="获取卡号失败，请确认您的卡的放置位置是否正确！"
                msg.value = msg.value + "" + ERROR + "\n";
                document.getElementById("<%=this.txtmusername.ClientID%>").value=""


            }




        }


        //WriteCardData(int Block, int Mode, string Data, int SecNum) 
        //Block 为块地址 Mode为密码模式 其中A密码用0代表，B密码用4代表；
        //Data为需要输入的数据，数据为16为字节；
        //SecNum为扇区
        //卡内有0~63共64个地址块，0-15共16个扇区；
        //每个扇区4块，第一扇区用于存放厂商代码，已被固话，不能更改
        //每个扇区0~2块为数据块，用于存储数据，其中，块0只能读，块1和块2用于存储数据，块3为控制块，用于存放密码
        //密码A可
       

    </script>


</p>

    

</asp:Content>


       
         

    
