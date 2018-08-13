using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;




namespace ReadCardActiveX
{
    public partial class umfatClass

    {
        

        [DllImport("umf.dll", EntryPoint = "initialcom")]
        public static extern int initialcom(int port, int band);
       
        //[DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern int initialcom(/*[in]*/ int port,/*[in]*/long band);
        [DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
         public static extern int beep(/*[in]*/short icdev,/*[in]*/short isec);
        [DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
         public static extern int request(/*[in]*/short hdev,/*[in]*/short mode);
        [DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int exit(/*[in]*/short icdev);
        [DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int findcardHex(/*[in]*/short hdev,/*[in]*/short mode);
        [DllImport("umf.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern string findcardStr(/*[in]*/short hdev,/*[in]*/short mode);

       
    


}
}