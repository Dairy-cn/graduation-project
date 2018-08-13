using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; //Guid需要
using mshtml;
using System.Threading;
using ATLUMFLib;
using System.Collections;

namespace ReadCardActiveX
{
     [Guid("A4933801-4419-4DCF-9090-8CC2A1A8DA86")]
    public class MacActiveX : ActiveXControl
    {


         ATLUMFLib.umfatlClass a = new ATLUMFLib.umfatlClass();

        bool isConnect = false;
        int port = 100;
        long ss = 115200;
        int fCmdRet;
        int icdev = -1;
       

        

        public enum cardregion : byte
        {
            Preserve,
            EPC,
            TID,
            User
        }

        public int InitialcomCard()   //初始化
        {
            int openresult = 0;
            try
            {
                if (isConnect == false)
                {

                    //openresult = StaticClassReaderB.AutoOpenComPort(ref port_number, ref reader_address, botelv, ref port_index);
                    openresult = a.initialcom(100, 115200);
                    if (openresult != -1)
                    {
                        icdev = openresult;
                        var hdev = 1;
                        hdev = a.beep((short)icdev, 500);
                        isConnect = true;

                    }

                    else
                    {
                        isConnect = false;

                    }
                }
            }
            catch
            {

                return -1;
            }


            return openresult;

        }

        
        

        public int CloseCard() //断开读卡器
        {
            int closeresult;
            closeresult = a.exit((short)icdev);
            if (closeresult == 0)
            {
                isConnect = false;
                a.beep((short)icdev, 100);


            }



            return closeresult;
        }
        public string ReadercardStr()
        {
            var strCard = "";


            if (isConnect)
            {
                strCard = a.findcardStr((short)icdev, 1);
                var b = 1;
                b = a.beep((short)icdev, 200);


                if (strCard != "")
                {

                    return strCard;
                }
                else
                {

                    return "false";

                }


            }


            return strCard;

        }

        public string ReaderCardData(int Block, int Mode, int SecNum)//读出地址为Block的数据 0-63
        {
            string CardDataChar = "";
            if (a.authentication((short)icdev, (short)Mode, (short)SecNum) == 0)
            {
                CardDataChar = a.read((short)icdev, (short)Block);

                if (CardDataChar != "")
                {
                    a.beep((short)icdev, 100);

                    return CardDataChar;

                }
                else
                {

                    return "读卡失败";
                }
            }
            else
            {


                return "密码错误";
            }




        }
        //为地址为Block写数据Data
        //
        public string WriteCardData(int Block, int Mode, string Data, int SecNum)
        {


            int st;
            if (a.authentication((short)icdev, (short)Mode, (short)SecNum) == 0)
            {


                st = a.write((short)icdev, (short)Block, Data);


                if (st == 0)
                {

                    a.beep((short)icdev, 1000);
                    return "写卡成功";

                }
                else
                {


                    return "写卡失败";


                }
            }
            else
            {

                return "密码验证失败";
            }


        }
          
            
        }


       
    }


