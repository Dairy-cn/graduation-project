using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MyKaoQin : System.Web.UI.Page
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
        string UserId = Request["id"] == null ? "" : Request["id"];
        //更改状态
        DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");
        DataTable dt = DataBase.Get_Table("select KaoQinDetail.*,Member.mname,KaoQin.Name,KaoQin.Address from KaoQinDetail left join Member on Member.Id=KaoQinDetail.MemberId left join KaoQin on KaoQin.id=KaoQinDetail.KaoQinId where MemberId='" + UserId+"'");
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
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnsave_Click(object sender, EventArgs e)
    {
        string title = this.TextBox1.Text.Trim();
        string time = this.txtTime.Text.Trim();


        string UserId = Request["id"] == null ? "" : Request["id"];
        //更改状态
        DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");
        StringBuilder sb = new StringBuilder();
        sb.Append("select KaoQinDetail.*,Member.mname,KaoQin.Name,KaoQin.Address from KaoQinDetail left join Member on Member.Id=KaoQinDetail.MemberId left join KaoQin on KaoQin.id=KaoQinDetail.KaoQinId ");
        sb.Append(" where MemberId=" + UserId);

        if (!string.IsNullOrEmpty(title))
        {
            sb.Append(" and KaoQin.Name like '%" + title + "%'");
        }
        if (!string.IsNullOrEmpty(time))
        {
            sb.Append(" and KaoQinDetail.CreateTime between '" + Convert.ToDateTime(time) + "' and '" + Convert.ToDateTime(time).AddHours(24) + "'");
        }

        DataTable dt = DataBase.Get_Table(sb.ToString());
        if (dt.Rows.Count < 1)
            dt.Rows.Add(dt.NewRow());
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();

    }
  
}