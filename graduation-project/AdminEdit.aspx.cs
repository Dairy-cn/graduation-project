using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //显示当前的会员信息
            if (Request.QueryString["id"] != null)
            {
                DataTable tmpda = new DataTable();
                tmpda = DataBase.Get_Table("select * from Admin where id='" + Request.QueryString["id"].ToString() + "'");
                if (tmpda.Rows.Count > 0)
                {
                    this.TextBox1.Text = tmpda.Rows[0]["dlm"].ToString();
                    this.TextBox1.Attributes["ReadOnly"] = "true";
                    this.Textbox5.Attributes["value"] = "********";
                    this.Textbox6.Attributes["value"] = "********";

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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('管理员帐号不能为空！');</script>");
            return;
        }
        if (this.Textbox5.Text.Trim() != this.Textbox6.Text.Trim())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('密码不一致！');</script>");
            return;
        }
        if (Request.QueryString["id"] == null)
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from glyxx where dlm='" + this.TextBox1.Text.Trim() + "'");
            if (tmpda.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('此帐户已经存在,请重新输入！');</script>");
                return;
            }
        }
        if (Request.QueryString["id"] == null)
        {
            //添加注册的会员信息到数据库中
            DataBase.ExecSql("insert into glyxx(dlm,mm) " +
                        " values('" + this.TextBox1.Text.Trim() + "','" + this.Textbox5.Text.Trim() + "')");
        }
        else
        {
            //更新当前的会员信息
            if (this.Textbox5.Text.Trim() != "********")
            {
                DataBase.ExecSql("update Admin set mm='" + this.Textbox5.Text.Trim() + "' where id= '" + Request.QueryString["id"].ToString() + "'");
            }

        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('保存成功！');window.location.href='AdminList.aspx';</script>");
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminList.aspx");
    }
}