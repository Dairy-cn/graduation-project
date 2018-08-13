using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class KeChengList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void Bind()
    {
        //更改状态
        DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");
        DataTable dt = DataBase.Get_Table("select * from KaoQin");
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
       
       
       Session["KaoqinsID"] = Key;
        if (e.CommandName == "UpdateEdit")
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from KaoQin where id='" + Key + "'");
            if (tmpda.Rows.Count > 0)
            {
                string status = tmpda.Rows[0]["status"].ToString();
                DateTime dt1 = Convert.ToDateTime(tmpda.Rows[0]["beginTime"].ToString());
                DateTime dt2 = Convert.ToDateTime(tmpda.Rows[0]["endTime"].ToString());
                if (status == "进行中")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤正在进行,不能进行编辑！');</script>");
                    return;
                }
                if (status == "已结束")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤已结束,不能进行编辑！');</script>");
                    return;
                }
            }
            //传递修改的标志 跳转页面
            Response.Redirect("KaoQinEdit.aspx?id=" + Key);
        }
        if (e.CommandName == "Del")
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from KaoQin where id='" + Key + "'");
            if (tmpda.Rows.Count > 0)
            {
                string status = tmpda.Rows[0]["status"].ToString();
                DateTime dt1 = Convert.ToDateTime(tmpda.Rows[0]["beginTime"].ToString());
                DateTime dt2 = Convert.ToDateTime(tmpda.Rows[0]["endTime"].ToString());
                if (status == "进行中")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤正在进行,不能进行删除！');</script>");
                    return;
                }
                if (status == "已结束")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤已结束,不能进行删除！');</script>");
                    return;
                }
            }
            DataBase.ExecSql("delete from KaoQin where id='" + Key + "'");
            Bind();
        }
        if (e.CommandName == "KaoQin")
        {
            DataTable tmpda = new DataTable();
            tmpda = DataBase.Get_Table("select * from KaoQin where id='" + Key + "'");
            if (tmpda.Rows.Count > 0)
            {
                string status = tmpda.Rows[0]["status"].ToString();
                DateTime dt1 = Convert.ToDateTime(tmpda.Rows[0]["beginTime"].ToString());
                DateTime dt2 = Convert.ToDateTime(tmpda.Rows[0]["endTime"].ToString());
                if (status == "未开始")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤还未开始,不能进行考勤操作！');</script>");
                    return;
                }
                if (status == "已结束")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('考勤已结束,不能进行考勤操作了！');</script>");
                    return;
                }
            }
            Response.Redirect("Movie/Detail.aspx?id=" + Key);
        }
        if (e.CommandName == "KaoQinList")
        {
            Response.Redirect("KaoQinDetail.aspx?KaoQinId=" + Key);
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
        Response.Redirect("KaoQinEdit.aspx");
    }

    /// <summary>
    /// 刷新加载全部
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnsave0_Click(object sender, EventArgs e)
    {
        Bind();
    }
}