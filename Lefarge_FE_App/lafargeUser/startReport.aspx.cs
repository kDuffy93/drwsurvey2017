using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class startReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDropDowns();
            }
        }

        protected void fillDropDowns()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //create a list the holds the plants table
                var p = (from plnt in conn.Plants
                         select plnt).ToList();
                //set the datasource to the created list and bind it to the dropdown
                ddlPlant.DataSource = p;
                ddlPlant.DataBind();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Session["selectedPlant"] = ddlPlant.SelectedItem.Value;
           
            Response.Redirect("selectResults.aspx");
        }
    }
}