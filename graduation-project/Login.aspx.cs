using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnlogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //判断登陆人员的密码和用户是不是正确
            DataTable tmpda = new DataTable();

            if (this.DropDownList1.SelectedItem.Value =="1")//管理员
            {
                tmpda = DataBase.Get_Table("select * from Admin where dlm='" + txtLoginName.Text.Trim() + "' and mm='" + this.txtPwd.Text.Trim() + "'");
                if (tmpda.Rows.Count <= 0)
                {
                    Response.Write("<script>alert('用户或密码错误');window.location.href='login.aspx';</script>");
                    return;
                }

                //保存用户名到公用Session
                Session["UserLoginName"] = this.txtLoginName.Text.Trim();
                Session["userid"] = tmpda.Rows[0]["Id"].ToString();
                Response.Redirect("Index.aspx");
            }
            else
            {
                tmpda = DataBase.Get_Table("select * from Member where musername='" + txtLoginName.Text.Trim() + "' and mpass='" + this.txtPwd.Text.Trim() + "'");
                if (tmpda.Rows.Count <= 0)
                {
                    Response.Write("<script>alert('用户或密码错误');window.location.href='login.aspx';</script>");
                    return;
                }
              
                //保存用户名到公用Session
                Session["UserLoginName"] = this.txtLoginName.Text.Trim();
                Session["userid"] = tmpda.Rows[0]["Id"].ToString();
                Response.Redirect("User.aspx");
            }
        }
    }
}