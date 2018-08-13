using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

public partial class Movie_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ModJsonResult model = new ModJsonResult();
            string CardStr = Request["CardStrNum"] == null ? "" : Request["CardStrNum"];
            string KaoQinId = Request["KaoQinId"] == null ? "" : Request["KaoQinId"];
            string Class = Request["Class"] == null ? "" : Request["Class"];
            if (CardStr != "")
            {

         



                DataTable tmpdas = new DataTable();
                tmpdas = DataBase.Get_Table("select * from Member where musername='" + CardStr + "'");

                if (tmpdas.Rows.Count > 0)//存在用户
                {
                    if (tmpdas.Rows[0]["flxxId"].ToString() != Class)
                    {
                        model.success = false;
                        model.msg = "您不属于该班级,不能进行签到!"+Class;

                    }
                    else
                    {
                        DataTable tmpClass = new DataTable();
                        tmpClass = DataBase.Get_Table("select flmc from flxx where flbh=(select flxxId from Member where musername='" + CardStr + "')");
                        string userClass = tmpClass.Rows[0]["flmc"].ToString();
                        string userId = tmpdas.Rows[0]["id"].ToString();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("delete from KaoQinDetail where KaoQinId='" + KaoQinId + "'and MemberId='" + userId + "'");
                        sb.AppendLine();
                        sb.Append("insert into KaoQinDetail(KaoQinId,MemberId,Status)");
                        sb.Append(" values(");
                        sb.Append(" '" + KaoQinId + "',");
                        sb.Append(" '" + userId + "',");
                        sb.Append(" 1");
                        sb.Append(" )");
                        DataBase.ExecSql(sb.ToString());

                        model.success = true;
                        string name = tmpdas.Rows[0]["mname"].ToString();
                        DataTable tmpKemus = new DataTable();


                        tmpKemus = DataBase.Get_Table("select Name from Kaoqin where id='" + KaoQinId + "'");




                        model.msg = model.msg + userClass + "的" + name + "同学，课程签到成功!";
                    }
                }
                else
                {
                    model.success = false;

                    model.msg = "找不到您的信息，请联系老师确认";
                }


            }






            else
            {

                model.success = false;

                model.msg = "签到失败，未寻到卡，请检查卡是否放置正确2";


            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Response.Clear();
            Response.Write(jsSerializer.Serialize(model).ToString());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.End();
        }
    }

    public class ModJsonResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        private bool _success = true;
        public bool success
        {
            get { return _success; }
            set { _success = value; }
        }
        /// <summary>
        /// 提示
        /// </summary>
        private string _msg = "";
        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

    /// <summary>
    /// 日期转换成unix时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public long DateTimeToUnixTimestamp(DateTime dateTime)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(dateTime.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
        return Convert.ToInt32(timeStamp);
    }
}