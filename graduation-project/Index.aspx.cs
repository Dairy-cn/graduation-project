using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    public string strUserName = "";
    public string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserLoginName"] == null || Session["UserLoginName"].ToString() == "")
            {
                Response.Write("<script>alert('登录超时，请重新登录！');parent.location.href='login.aspx'</script>");
            }
            else
            {
                userid = Session["userid"].ToString();
                strUserName = Session["UserLoginName"].ToString();
            }
        }
    }
}