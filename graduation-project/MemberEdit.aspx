<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MemberEdit.aspx.cs" Inherits="MemberEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .txtbox {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <div class="item">
            <div class="title">
                学生信息
            </div>
            <div class="ui-toolbar">
                <table id="Table1" cellspacing="1" class="Tab" width="728" align="center">
                    <tr class="tr">
                        <td align="right">班级：
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddllist" Height="23px" Width="132px"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr class="tr">
                        <td align="right" style="width: 100px">
                            <span style="color: Red">*</span>学号：
                        </td>
                        <td align="left">
                            <font face="宋体">
                                <asp:TextBox id="txtmusername" runat="server" DESIGNTIMEDRAGDROP="98"
                                    Width="232px" Text=""></asp:TextBox>(必填)</font>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="txtmusername_TextChanged"></asp:LinkButton>

                            <input type="button"  onclick="Findcard()" value="读卡" />
                            
                            


                        </td>
                    </tr>

                    <tr class="tr">
                        <td align="right">
                            <span style="color: Red">*</span>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码：
                        </td>
                        <td align="left">
                            <font face="宋体">
                                <asp:TextBox ID="txtmpass" runat="server" Width="232px" DESIGNTIMEDRAGDROP="98"
                                    TextMode="Password"></asp:TextBox>(必填)</font>
                        </td>
                    </tr>
                    <tr class="tr">
                        <td align="right">
                            <span style="color: Red">*</span>确认密码：
                        </td>
                        <td align="left">
                            <font face="宋体">
                                <asp:TextBox ID="txtpass2" runat="server" Width="232px"
                                    DESIGNTIMEDRAGDROP="98" TextMode="Password"></asp:TextBox>(必填)</font>
                        </td>
                    </tr>
                    <tr class="tr">
                        <td>
                            <div align="right">
                                <span style="color: Red">*</span>真实姓名：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmname" runat="server" Width="160px"></asp:TextBox>
                                <font face="宋体">(必填)</font>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                性别：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server"
                                    Height="21px" Width="76px">
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td class="yanzheng">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                邮箱：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmemail" runat="server" Width="160px"></asp:TextBox>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                身份证号码：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmcard" runat="server" Width="160px"></asp:TextBox>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                QQ：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmqq" runat="server" Width="160px"></asp:TextBox>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                手机：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmmbile" runat="server" Width="160px"></asp:TextBox>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>

                    <tr>
                        <td>
                            <div align="right">
                                联系地址：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmaddress" runat="server" Width="421px"></asp:TextBox>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                <span style="color: Red">*</span>密码问题选择：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>我的出生地在哪儿?</asp:ListItem>
                                    <asp:ListItem>我的手机后四位是多少?</asp:ListItem>
                                    <asp:ListItem>我的身份证后四位是多少?</asp:ListItem>
                                    <asp:ListItem>毕业于哪所初中?</asp:ListItem>
                                </asp:DropDownList>(必填)
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                <span style="color: Red">*</span>密保问题答案：
                            </div>
                        </td>
                        <td>
                            <div align="left">
                                <asp:TextBox ID="txtmanswer" runat="server" Width="160px"></asp:TextBox>(必填)</font>
                            </div>
                        </td>
                        <td class="yanzheng"></td>
                    </tr>
                    <tr class="tr" style="height: 50px">
                        <td></td>
                        <td align="left">
                            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Button1_Click"
                                Text="保存" Width="62px" />
                            <asp:Button ID="Button2" CssClass="button" runat="server" Text="返回" Width="62px"
                                OnClick="Button2_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>


    <div style="display: none">
        <p align="center">
            <textarea rows="2" cols="2"></textarea></p>


        <p align="center">
            <object classid="clsid:8B5A1D0B-4142-4EE1-B247-56DFD7C1CACA" id="obj_ie" width="6" height="14" align="left">
            </object>

        </p>

    </div>


    <script language="javascript" type="text/javascript">
        var Sys = {};
        var ua = navigator.userAgent.toLowerCase();
        var s;
        (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
        (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
        (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
        (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

        Sys.ie = isIE();

        if (Sys.ie) {
            var obj = document.getElementById('obj_ie');
        }
        if (Sys.firefox || Sys.chrome) {
            var obj = document.getElementById('obj_firefox_chrome');
        }
        if (Sys.opera) {
            document.write('Opera: ' + Sys.opera);
        }
        if (Sys.safari) {
            var obj = document.getElementById('obj_firefox_chrome');
            document.write('Safari: ' + Sys.safari);
        }
        var msg = document.getElementById('TxtArea');

        function isIE() {
            if (window.ActiveXObject || "ActiveXObject" in window) {
                return 1;
            }
            else {
                return 0;
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
        //Link Reader
        function Connect() {
            var iRet;
            try {
                if (isComOpen == false)          //if reader link failed
                {
                    var hdev = 1;
                    iRet = obj.initialcom(100, 115200);  //Link reader, 100 means USB port, 115200 is baud
                    if (iRet != -1) {

                        icdev = iRet;
                        var ncard = 0;
                        var data = "";

                        hdev = obj.beep(icdev, 20);   //do a beep


                        isComOpen = true;             //Set reader link status
                    }
                    else {
                        msg.value = "Link reader error\n";
                        isComOpen = false;           //Set reader link failed status
                    }
                }
            } catch (e) {  }

            return;
        }
       


        //Load key
        function LoadKey() {
            var iRet;
            var data;

            iRet = obj.loadkey(icdev, 0, gl_sector, "FFFFFFFFFFFf");      //Load key, 0: keyA, ffffffffffff:key

            if (iRet) {
                msg.value = msg.value + "Load key error\n";
            }
            else {
                msg.value = msg.value + "Load key ok\n";
            }

            return;

        }

        // Find card
        function Findcard() {
            var strcard = "";

            strcard = obj.findcardStr(icdev, 1);     //1: multy card mode

            
      
         
            if (strcard != "") {
                //msg.value = msg.value + "Find card ok\n";
                hasCard = true;
                //if(nRead<1)    //The first read
                //{

             
                alert("卡号：" + strcard);
            
                document.getElementById("<%=this.txtmusername.ClientID%>").value = strcard;
               
             
              
         
                //}	
            }
            else {
                alert("请把卡放到读卡器位置");
                document.getElementById("<%=this.txtmusername.ClientID%>").value = strcard;
                hasCard = false;        //Set no card status

                Connect();
            }
            

        }
        //Read card
        function Read() {
            var iRet;
            var data = " ";
            var besp;

            if (icdev == 0) {
                msg.value = msg.value + "ERROR";
                return;
            }
            var strcard = "";

            //hdev=obj.loadkey(icdev,0,gl_sector,"ffffffffffff");
            strcard = obj.findcardStr(icdev, 1);//1: multy card mode

            iRet = obj.authentication(icdev, 0, gl_sector);    //Verify card,0: verify mode(keyA)
            if (iRet) {
                msg.value = msg.value + "Verify key error\n";
            }
            else {
                msg.value = msg.value + "Verify key ok\n";
            }

            data = obj.read(icdev, gl_BinBlock);
            besp = obj.beep(icdev, 15);
            //data =obj.directRead(icdev,gl_BinBlock);        //Read data directly as binary

            if (data != "") {
                msg.value = msg.value + "Read ok, data: \n" + data + "\n";

            }
            else {
                msg.value = msg.value + "Read error\n";
            }
        }


        //Write card
        function Write() {
            var strcard = "";
            var data = " ";
            var iRet = 0;

            strcard = obj.findcardStr(icdev, 1);//1: find multy card mode
            if (strcard != "") {
                msg.value = msg.value + "Find card ok\n";
            }
            else {
                msg.value = msg.value + "Find card error\n" + iRet;
            }

            iRet = obj.authentication(icdev, 0, gl_sector);//0: Authen mode
            if (iRet) {
                msg.value = msg.value + "Verify key error\n";
            }
            else {
                msg.value = msg.value + "Verify key ok\n";
            }

            iRet = obj.write(icdev, gl_BinBlock, "11111111111111111111111111111111");
            //iRet = obj.directWrite(icdev,gl_BinBlock,"IC Card Reader  ");
            if (iRet == 0) {
                msg.value = msg.value + "Write card ok\n";
            }
            else {
                msg.value = msg.value + "Write card error\n";
            }

            return;

        }


        //Disconnect with reader
        function Disconnect() {
            var iRet;
            var data;
            iRet = obj.exit(icdev);
            if (iRet) {
                msg.value = msg.value + "断开失败\n";
            }
            else {
                msg.value = msg.value + "断开成功\n";

                isComOpen = false; //Set unlink status
            }

        }

        //Loop set card find status
        function SetCardStatue() {
            Findcard();
            //   if(hasCard==true&&nRead<1)   //Only one time find each card 
            // 	 Read();
        }

        //Value operation
        function ValOper() {

            var iRet = 1;
            var value = 1000;
            strcard = obj.findcardStr(icdev, 1);//multy card find mode
            if (strcard != "") {
                msg.value = msg.value + "Find card ok\n";
            }
            else {
                msg.value = msg.value + "Find card error\n" + iRet;
            }

            iRet = obj.authentication(icdev, 0, gl_sector);//Verify as keyA mode
            if (iRet) {
                msg.value = msg.value + "Verify key error\n";
            }
            else {
                msg.value = msg.value + "Verify key ok\n";
            }
            iRet = obj.initialval(icdev, gl_valBlock, value);
            iRet = obj.increment(icdev, gl_valBlock, 10);
            iRet = obj.transfer(icdev, gl_valBlock);
            iRet = obj.decrement(icdev, gl_valBlock, 10);
            iRet = obj.transfer(icdev, gl_valBlock);

            if (iRet) {
                msg.value = msg.value + "Value operate error\n";
            }
            else {
                msg.value = msg.value + "Value operate ok\n";
            }


            iRet = obj.readval(icdev, 9);

            msg.value = msg.value + "Current value: " + iRet + "\n";
        }

        function Changekey() {
            var iRet;
            var strcard = "";
            try {

                strcard = obj.findcardStr(icdev, 1);
                iRet = obj.authentication(icdev, 0, gl_sector);
                iRet = obj.changkey(icdev, gl_sector, "FFFFFFFFFFFf", "FF078069", 0, "FFFFFFFFFFFF");//Update key to: FFFFFFFFFFFF
                iRet = obj.halt(icdev); //call halt function to make update active
                if (iRet) {
                    msg.value = msg.value + "Update key error\n";
                }
                else {
                    msg.value = msg.value + "Update key ok\n";
                }
            } catch (e) { alert(e.message); }
        }
        function Fcputest() {

            try {
                Disconnect();
                window.location.href = 'FM1208_Test.html';

            } catch (e) { alert(e.message); }
            return;
        }

        function MifareProtest() {
            var iRet;
            var ncard = 0;
            var data = "";
            var scmd = "0084000008";
            try {

                Findcard();

                data = obj.mifareproReset(icdev);
                if (data != "") {
                    msg.value = msg.value + "Card reset ok, information: \n" + data + "\n";
                }
                else {
                    msg.value = msg.value + "Card reset error\n";
                }


                data = obj.mifareproCommandlink(icdev, scmd);
                if (data != "") {
                    msg.value = msg.value + "Command ok, information: \n" + data + "\n";
                }
                else {
                    msg.value = msg.value + "Command execute error\n";
                }

            } catch (e) { alert(e.message); }
            return;
        }

        function IDCardtest() {
            var iRet;

            if (icdev == 0) {
                msg.value = msg.value + "ERROR";
                return;
            }
            var strcard = "";
            strcard = obj.GetIDCardSN(icdev);

            if (strcard != "") {
                msg.value = msg.value + "Read card ok, ID: \n" + strcard + "\n";
            }
            else {
                msg.value = msg.value + "Read card error\n";
            }
            return;
        }



        var nRead = 0;     //The count one card repeat find
        var hasCard = false;
        var isComOpen = false;
        var icdev = 0;
        var gl_sector = 2;
        var gl_BinBlock = 8;
        var gl_valBlock = 9;

        Connect();

    </script>
</asp:Content>
