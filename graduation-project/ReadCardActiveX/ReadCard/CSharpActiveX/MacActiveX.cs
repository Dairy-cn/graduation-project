using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; //Guid需要
using mshtml;
using System.Threading;

using System.Collections;

namespace CSharpActiveX
{
    [Guid("FAFDECFE-33AD-48F9-9D37-BEB32B6DC809")]
    public class MacActiveX : ActiveXControl
    {




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


        public int open_reader()   //连接读卡器
        {
            int openresult;
            try
            {
                //openresult = StaticClassReaderB.AutoOpenComPort(ref port_number, ref reader_address, botelv, ref port_index);
                openresult = umfatlClass.initialcom(100, 115200);
            }
            catch
            {
                return 9921;
            }
            return openresult;
        }



        public int CloseCard() //断开读卡器
        {
            int closeresult;
            try
            {
                //closeresult = StaticClassReaderB.CloseSpecComPort(port_number);
                closeresult = umfatlClass.exit((short)icdev);
            }
            catch
            {
                return 982;
            }
            return closeresult;
        }
        //    public string ReadCardID()
        //    {
        //        var strcard="";
        //        strcard=umfatlClass.findcardStr((short)icdev,1);
        //        if (strcard != "")
        //        {
        //            return strcard;



        //        }
        //        else
        //        {

        //            return "";
        //        }

        //    }



        //}

    }
}