using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Text;

public partial class KaoQinDetail : System.Web.UI.Page
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

            Bind();
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    public void Bind()
    {
        string KaoQinId = Request["KaoQinId"] == null ? " " : Request["KaoQinId"];
        //更改状态
        DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");
        DataTable dt = DataBase.Get_Table("select KaoQinDetail.*,Member.mname,flxx.flmc from KaoQinDetail left join Member on Member.Id=KaoQinDetail.MemberId left join flxx on Member.flxxId=flxx.flbh where KaoQinId='" + KaoQinId + "'");
        if (dt.Rows.Count < 1)
           dt.Rows.Add(dt.NewRow());
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();
    }

   
    protected void lbtnsave0_Click(object sender, EventArgs e)
    {
        Response.Redirect("KeChengList.aspx");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Key = this.GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        if (e.CommandName == "Del")
        {
            DataBase.ExecSql("delete from KaoQinDetail where id='" + Key + "'");
            Bind();
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
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnsave_Click(object sender, EventArgs e)
    {
        string title = this.TextBox1.Text.Trim();
        string time = this.txtTime.Text.Trim();
        string endtime = this.txtendTime.Text.Trim();
        //更改状态
        string KaoQinId = Request["KaoQinId"] == null ? "" : Request["KaoQinId"];
        //更改状态
        DataBase.ExecSql("update KaoQin set status='进行中' where GETDATE() between beginTime and endtime;update KaoQin set status='已结束' where GETDATE() >endtime;");

        StringBuilder sb = new StringBuilder();
        sb.Append("select KaoQinDetail.*,Member.mname,flxx.flmc from KaoQinDetail left join Member on Member.Id=KaoQinDetail.MemberId left join flxx on Member.flxxId=flxx.flbh ");
        sb.Append(" where KaoQinId=" + KaoQinId);

        if (!string.IsNullOrEmpty(title))
        {
            sb.Append(" and Member.mname like '%" + title + "%'");
        }
        if (!string.IsNullOrEmpty(time) && string.IsNullOrEmpty(endtime))
        {
            sb.Append(" and KaoQinDetail.CreateTime>'" + Convert.ToDateTime(time) + "'");
        }
        else if (string.IsNullOrEmpty(time) && !string.IsNullOrEmpty(endtime))
        {
            sb.Append(" and KaoQinDetail.CreateTime < '" + Convert.ToDateTime(endtime) + "'");
        }
        else
        {
            sb.Append(" and KaoQinDetail.CreateTime between '" + Convert.ToDateTime(endtime) + "' and '" + Convert.ToDateTime(endtime).AddHours(24) + "'");
        }
        int value = int.Parse(this.ddllist.SelectedItem.Value);
        if (value > 0)
        {
            sb.Append(" and Member.flxxId=" + value);
        }

        DataTable dt = DataBase.Get_Table(sb.ToString());
        if (dt.Rows.Count < 1)
            dt.Rows.Add(dt.NewRow());
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();
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