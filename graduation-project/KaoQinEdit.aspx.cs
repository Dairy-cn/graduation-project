using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class KaoQinEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //更改状态
            DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");
            //显示当前的会员信息
            if (Request.QueryString["id"] != null)
            {
                DataTable tmpda = new DataTable();
                tmpda = DataBase.Get_Table("select * from KaoQin where id='" + Request.QueryString["id"].ToString() + "'");
                if (tmpda.Rows.Count > 0)
                {
                    this.TextBox1.Text = tmpda.Rows[0]["Name"].ToString();
                    this.TextBox2.Text = tmpda.Rows[0]["Address"].ToString();
                    this.BeginTime.Value = tmpda.Rows[0]["beginTime"].ToString();
                    this.EndTime.Value = tmpda.Rows[0]["endTime"].ToString();
                    
                }
            }

            if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString() == "See")
            {
                this.Button1.Visible = false;
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
        if (TextBox1.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤课程不能为空！');</script>");
            return;
        }
        if (TextBox2.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('课程地址不能为空！');</script>");
            return;
        }
        if (BeginTime.Value.Trim() == "" || EndTime.Value.Trim()=="")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('截至时间不能为空！');</script>");
            return;
        }
        DateTime dt1 = Convert.ToDateTime(BeginTime.Value.Trim());
        DateTime dt2 = Convert.ToDateTime(EndTime.Value.Trim());
        if (dt1>dt2)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('开始时间不能大于结束时间！');</script>");
            return;
        }
      
        if (Request.QueryString["id"] == null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into KaoQin(Name,Address,beginTime,endTime,status)");
            sb.Append(" values(");
            sb.Append(" '" + TextBox1.Text.Trim() + "',");
            sb.Append(" '" + TextBox2.Text.Trim() + "',");
            sb.Append(" '" + dt1.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            sb.Append(" '" + dt2.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            sb.Append(" '未开始'");
            sb.Append(")");
            DataBase.ExecSql(sb.ToString());
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update KaoQin set ");
            sb.Append(" Name='" + TextBox1.Text.Trim() + "',");
            sb.Append(" Address='" + TextBox2.Text.Trim() + "',");
            sb.Append(" beginTime='" + dt1.ToString("yyyy-MM-dd HH:mm:ss") + "',");
            sb.Append(" endTime='" + dt2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sb.Append(" where Id=" + Request.QueryString["id"]);
            DataBase.ExecSql(sb.ToString());
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('保存成功！');window.location.href='KeChengList.aspx';</script>");
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("KeChengList.aspx");
    }
}