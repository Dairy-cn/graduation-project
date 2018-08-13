using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //显示当前的会员信息
            if (Request.QueryString["flbh"] != null)
            {
                DataTable tmpda = new DataTable();
                tmpda = DataBase.Get_Table("select * from flxx where flbh='" + Request.QueryString["flbh"].ToString() + "'");
                if (tmpda.Rows.Count > 0)
                {
                    this.TextBox1.Text = tmpda.Rows[0]["flmc"].ToString();
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('名称不能为空！');</script>");
            return;
        }

        if (Request.QueryString["flbh"] == null)
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from flxx where flmc='" + this.TextBox1.Text.Trim() + "'");
            if (tmpda.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('此名称已经存在,请重新输入！');</script>");
                return;
            }
        }
        if (Request.QueryString["flbh"] == null)
        {
            //添加注册的会员信息到数据库中
            DataBase.ExecSql("insert into flxx(flmc,parentId,level) " +
                        " values('" + this.TextBox1.Text.Trim() + "',0,1)");
        }
        else
        {
            DataBase.ExecSql("update flxx set flmc='" + this.TextBox1.Text.Trim() + "' where flbh= '" + Request.QueryString["flbh"].ToString() + "'");
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('保存成功！');window.location.href='CategoryProvien.aspx';</script>");
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("CategoryProvien.aspx");
    }
}