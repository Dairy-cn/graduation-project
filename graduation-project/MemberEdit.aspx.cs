using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using ThoughtWorks.QRCode.Codec;
using System.Text.RegularExpressions;

public partial class MemberEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定班级
            DataTable list = DataBase.Get_Table("select * from flxx where level=1");
            ddllist.DataSource = list.DefaultView;
            ddllist.DataTextField = "flmc";
            ddllist.DataValueField = "flbh";
            ddllist.DataBind();

            //显示当前的会员信息
            if (Request.QueryString["id"] != null)
            {
                DataTable tmpda = new DataTable();
                tmpda = DataBase.Get_Table("select * from Member where id='" + Request.QueryString["id"].ToString() + "'");
                if (tmpda.Rows.Count > 0)
                {
                    this.LinkButton1.Visible = false;
                    this.txtmusername.Text = tmpda.Rows[0]["musername"].ToString();
                    this.txtmusername.Attributes["ReadOnly"] = "true";
                    this.txtmpass.Attributes["value"] = tmpda.Rows[0]["mpass"].ToString();
                    this.txtpass2.Attributes["value"] = tmpda.Rows[0]["mpass"].ToString();
                    this.txtmname.Text = tmpda.Rows[0]["mname"].ToString();
                    this.DropDownList1.SelectedItem.Text = tmpda.Rows[0]["msex"].ToString();
                    this.txtmemail.Text = tmpda.Rows[0]["memail"].ToString();
                    this.txtmcard.Text = tmpda.Rows[0]["mcard"].ToString();
                    this.txtmqq.Text = tmpda.Rows[0]["mqq"].ToString();
                    this.txtmmbile.Text = tmpda.Rows[0]["mmobile"].ToString();
                    this.txtmaddress.Text = tmpda.Rows[0]["maddress"].ToString();
                    this.DropDownList2.SelectedItem.Text = tmpda.Rows[0]["question"].ToString();
                    this.txtmanswer.Text = tmpda.Rows[0]["answer"].ToString();
                    this.ddllist.SelectedValue = tmpda.Rows[0]["flxxId"].ToString();
                }
            }

            if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString() == "See")
            {
                this.Button1.Visible = false;
            }
            if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString() == "Look")
            {
                this.Button2.Visible = false;
            }
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        int value = int.Parse(this.ddllist.SelectedItem.Value);
        if (value <= 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请选择班级！');</script>");
            return;
        }
        if (txtmusername.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('登录帐号不能为空！');</script>");
            txtmusername.Focus();
            return;
        }
        if (txtmpass.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请输入登录密码！');</script>");
            txtmpass.Focus();
            return;
        }
        if (txtpass2.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请输入登录确认密码！');</script>");
            this.txtpass2.Focus();
            return;
        }
        if (this.txtmpass.Text.Trim() != txtpass2.Text.Trim())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('对不起，你两次输入密码不一致！');</script>");
            return;
        }
        if (txtmname.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('对不起，请输入您的真实姓名！');</script>");
            this.txtmname.Focus();
            return;
        }
        if (this.txtmanswer.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('对不起，请输入您的安全问题答案！');</script>");
            txtmanswer.Focus();
            return;
        }
        if (Request.QueryString["id"] == null)
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from Member where musername='" + this.txtmusername.Text.Trim() + "'");
            if (tmpda.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('此帐户已经存在,请重新输入！');</script>");
                return;
            }
        }
        else
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from Member where musername='" + this.txtmusername.Text.Trim() + "' and Id !=" + Request.QueryString["id"]);
            if (tmpda.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('此帐户已经存在,请重新输入！');</script>");
                return;
            }
        }

        if (txtmemail.Text.Trim() != "")
        {
            //校验邮箱格式是否正确
            string pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool flag = Regex.IsMatch(txtmemail.Text.Trim(), pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (flag == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('邮箱格式输入错误！');</script>");
                return;
            }
        }
        if (txtmmbile.Text.Trim() != "")
        {
            //校验手机格式是否正确
            string pattern = "^(13|15|18)[0-9]{9}$";
            bool flag = Regex.IsMatch(txtmmbile.Text.Trim(), pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (flag == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('手机格式输入错误！');</script>");
                return;
            }
        }
        if (Request.QueryString["id"] == null)
        {
           
            
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Member(musername,mname,mpass,memail,mcard,mqq,mmobile,maddress,question,answer,msex,flxxId)");
            sb.Append(" values(");
           
            
            sb.Append(" '" + txtmusername.Text.Trim() + "',");
            sb.Append(" '" + txtmname.Text.Trim() + "',");
            sb.Append(" '" + txtmpass.Text.Trim() + "',");
            sb.Append(" '" + txtmemail.Text.Trim() + "',");
            sb.Append(" '" + txtmcard.Text.Trim() + "',");
            sb.Append(" '" + txtmqq.Text.Trim() + "',");
            sb.Append(" '" + txtmmbile.Text.Trim() + "',");
            sb.Append(" '" + txtmaddress.Text.Trim() + "',");
            sb.Append(" '" + DropDownList2.SelectedItem.Text + "',");
            sb.Append(" '" + txtmanswer.Text.Trim() + "',");
            sb.Append(" '" + DropDownList1.SelectedItem.Text.Trim() + "',");
            
            sb.Append(" " + value + "");

            sb.Append(")");
            //添加注册的会员信息到数据库中
            DataBase.ExecSql(sb.ToString());
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update Member set musername='" + txtmusername.Text.Trim() + "',");
            sb.Append(" mname='" + txtmname.Text.Trim() + "',");
            sb.Append(" mpass='" + txtmpass.Text.Trim() + "',");
            sb.Append(" memail='" + txtmemail.Text.Trim() + "',");
            sb.Append(" mcard='" + txtmcard.Text.Trim() + "',");
            sb.Append(" mqq='" + txtmqq.Text.Trim() + "',");
            sb.Append(" mmobile='" + txtmmbile.Text.Trim() + "',");
            sb.Append(" maddress='" + txtmaddress.Text.Trim() + "',");
            sb.Append(" question='" + DropDownList2.SelectedItem.Text + "',");
            sb.Append(" answer='" + txtmanswer.Text.Trim() + "',");
            sb.Append(" msex='" + DropDownList1.SelectedItem.Text.Trim() + "',");
            sb.Append(" flxxId=" + value + "");
            sb.Append(" where Id=" + Request.QueryString["id"].ToString());

            DataBase.ExecSql(sb.ToString());
        }
        if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString() == "Look")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('保存成功！');</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('保存成功！');window.location.href='MemberList.aspx';</script>");
        }
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberList.aspx");
    }
    /// <summary>
    /// 检测名称是否存在
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (txtmusername.Text.Trim() != "")
        {
            Exists();
        }
    }
    /// <summary>
    /// 检测用户名是否存在
    /// </summary>
    public void Exists()
    {
        DataTable tmpda = new DataTable();
        tmpda = DataBase.Get_Table("select * from Member where musername='" + this.txtmusername.Text.Trim() + "'");
        if (tmpda.Rows.Count > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('此帐户已经存在,请重新输入！');</script>");
            return;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('可以正常使用！');</script>");
            return;
        }
    }

    /// <summary>
    /// 日期转换成unix时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public long DateTimeToUnixTimestamp(DateTime dateTime)
    {
        //var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
        //return Convert.ToInt64((dateTime - start).TotalSeconds);

        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        DateTime dtNow = DateTime.Parse(dateTime.ToString());
        TimeSpan toNow = dtNow.Subtract(dtStart);
        string timeStamp = toNow.Ticks.ToString();
        timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
        return Convert.ToInt32(timeStamp);
    }

   
 

    

    protected void txtmusername_TextChanged(object sender, EventArgs e)
    {


      



        return;

    }
}