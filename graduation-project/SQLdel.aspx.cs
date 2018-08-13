using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SQLdel : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string straction = Request.QueryString["action"].ToString();
            switch (straction)
            {
                case "delAdmin":
                    if (string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        ShowInfo.AlertAndRedirect("删除成功！", "AdminList.aspx", this.Page);
                    }
                    int Key = int.Parse(Request.QueryString["id"]);
                    if (Key ==12)
                    {
                        ShowInfo.AlertAndRedirect("不能删除超级管理员！", "AdminList.aspx", this.Page);
                    }
                    else
                    {
                        DataBase.ExecSql("delete from Admin where id='" + Key + "'");
                        ShowInfo.AlertAndRedirect("删除成功！", "AdminList.aspx", this.Page);
                    }
                    break;
                case "delMember":
                    if (string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        ShowInfo.AlertAndRedirect("删除成功！", "MemberList.aspx", this.Page);
                    }
                    int Member = int.Parse(Request.QueryString["id"]);
                    DataBase.ExecSql("delete from Member where id='" + Member + "'");
                    ShowInfo.AlertAndRedirect("删除成功！", "MemberList.aspx", this.Page);
                    break;
                case "Default":
                    break;
            }
        }
    }
}