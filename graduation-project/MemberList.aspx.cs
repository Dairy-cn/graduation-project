using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MemberList : System.Web.UI.Page
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

            //学生用户列表
            Bind();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void Bind()
    {
        DataTable dt = DataBase.Get_Table("select * from MemberView");
        if (dt.Rows.Count < 1)
            dt.Rows.Add(dt.NewRow());
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Key = this.GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        if (e.CommandName == "Edit")
        {
            //传递修改的标志 跳转页面
            Response.Redirect("MemberEdit.aspx?id=" + Key);
        }
        if (e.CommandName == "Del")
        {
            //删除相关的会员信息
            DataBase.ExecSql("delete from Member where id='" + Key + "'");
            Bind();
        }
        if (e.CommandName == "Look")
        {
            Response.Redirect("CardPic.aspx?id=" + Key);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            if (e.Row.Cells[0].Text == "&nbsp;")
                e.Row.Cells[this.GridView1.Columns.Count - 1].Visible = false;
        }
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnsave_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberEdit.aspx");
    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int value = int.Parse(this.ddllist.SelectedItem.Value);
        if (value > 0)
        {
            DataTable dt = DataBase.Get_Table("select * from MemberView where flxxId=" + value);
            if (dt.Rows.Count < 1)
                dt.Rows.Add(dt.NewRow());
            this.GridView1.DataSource = dt.DefaultView;
            this.GridView1.DataBind();
        }
        else {
            Bind();
        }
    }
    /// <summary>
    /// 刷新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Bind();
    }
}