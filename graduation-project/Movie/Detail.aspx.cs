using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

public partial class Movie_Detail : System.Web.UI.Page
{
    public string id = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {




        if (!Page.IsPostBack)
        {
            
            //绑定班级
            DataTable list = DataBase.Get_Table("select * from flxx where level=1");
            if (list.Rows.Count <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "info", "<script>alert('请先维护班级信息！');window.location.href='KeChengList.aspx';</script>");
                return;
            }
            ddllist.DataSource = list.DefaultView;
            ddllist.DataTextField = "flmc";
            ddllist.DataValueField = "flbh";
            ddllist.DataBind();

            int value = int.Parse(list.Rows[0]["flbh"].ToString());
            this.HidClassId.Value = list.Rows[0]["flbh"].ToString();
            //显示当前的会员信息
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"];
            }

            //统计
            //统计
            //统计
            StringBuilder sb = new StringBuilder();
            sb.Append("select PeopleCount,KaoQinCount");
            sb.Append(" from (");
            sb.Append(" select (select COUNT(*) from Member where flxxId=" + value + ") as PeopleCount,");
            sb.Append(" (select COUNT(*) from KaoQinDetail inner join Member on KaoQinDetail.MemberId=Member.Id and Member.flxxId=" + value + ") as KaoQinCount");
            sb.Append(" ) a");
            DataTable dt = DataBase.Get_Table(sb.ToString());
            if (dt.Rows.Count > 0)
            {
                int PeopleCount = int.Parse(dt.Rows[0]["PeopleCount"].ToString());
                int KaoQinCount = int.Parse(dt.Rows[0]["KaoQinCount"].ToString());
              
                this.Label1.Text = dt.Rows[0]["PeopleCount"].ToString() + "人";
                this.Label2.Text = dt.Rows[0]["KaoQinCount"].ToString() + "人";
                Double verygoodlength = 0;
                if (PeopleCount == 0)
                {
                    verygoodlength = 0;
                    
                }
                else
                {
                    verygoodlength = ((Double)KaoQinCount / PeopleCount)*100;

                 
                    
                
                }

                this.Label3.Text = string.Format("{0:F2}", Convert.ToDouble(verygoodlength)) + "%";
                
            }
            else
            {
                this.Label1.Text = "0人";
                this.Label2.Text = "0人";
                this.Label3.Text = string.Format("{0:F2}", Convert.ToDouble(0)) + "%";
            }
        }
       
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int value =int.Parse(this.ddllist.SelectedItem.Value);
        this.HidClassId.Value = value.ToString();

        //统计
        StringBuilder sb = new StringBuilder();
        sb.Append("select PeopleCount,KaoQinCount");
        sb.Append(" from (");
        sb.Append(" select (select COUNT(*) from Member where flxxId=" + value + ") as PeopleCount,");
        sb.Append(" (select COUNT(*) from KaoQinDetail inner join Member on KaoQinDetail.MemberId=Member.Id and Member.flxxId=" + value + ") as KaoQinCount");
        sb.Append(" ) a");
        DataTable dt = DataBase.Get_Table(sb.ToString());
        if (dt.Rows.Count > 0)
        {
            int PeopleCount = int.Parse(dt.Rows[0]["PeopleCount"].ToString());
            int KaoQinCount = int.Parse(dt.Rows[0]["KaoQinCount"].ToString());
            Double verygoodlength = 0;
            this.Label1.Text = dt.Rows[0]["PeopleCount"].ToString() + "人";
            this.Label2.Text = dt.Rows[0]["KaoQinCount"].ToString() + "人";
            if (PeopleCount==0)
            {
                verygoodlength = 0;
            }
            else
            {
                verygoodlength = ((Double)KaoQinCount / PeopleCount) * 100;
               
            }


            this.Label3.Text = string.Format("{0:F2}", Convert.ToDouble(verygoodlength)) + "%";
        }
        else
        {
            this.Label1.Text = "0人";
            this.Label2.Text = "0人";
            this.Label3.Text = string.Format("{0:F2}", Convert.ToDouble(0)) + "%";
        }
    }




                              



























































































































































































































    }

    
   

