using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using ThoughtWorks.QRCode.Codec.Data;

public partial class Movie_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
   
            //QRCodeDecoder decoder = new QRCodeDecoder();
            //string path = Server.MapPath("/UploadFile/1.bmp");
            //Bitmap bm = new Bitmap(path);
            //string qrdecode = decoder.decode(new QRCodeBitmapImage(bm));
            //bm.Dispose();
            //Response.Write(qrdecode);
            //Response.End();
        }
    }
}