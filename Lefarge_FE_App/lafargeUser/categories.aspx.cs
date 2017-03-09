using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(User.IsInRole("admin") || User.IsInRole("user"))
                { 
            if (!IsPostBack)
            {
                GetCategories();
            }
            }

            if (User.IsInRole("member"))
            {
                GetCategories();
                grdCategories.Columns[2].Visible = false;
                grdCategories.Columns[3].Visible = false;
               
                btnNewCategory.Visible = false;
            }
        }
        protected void GetCategories()
        {

            //connect using our connection string from web.config and EF context class
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //use link to query the Departments model
                var cat = from c in conn.Categories
                            select c;

                //bind the query result to the gridview
                grdCategories.DataSource = cat.ToList();
                grdCategories.DataBind();
            }
        }
        protected void grdCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get the selected DepartmentID
                Int32 CategoryID = Convert.ToInt32(grdCategories.DataKeys[e.RowIndex].Values["Category_ID"]);

                var c = (from cat in conn.Categories
                         where cat.Category_ID == CategoryID
                         select cat).FirstOrDefault();

                //process the delete
                conn.Categories.Remove(c);
                conn.SaveChanges();

                //update the grid
                GetCategories();
            }
        }

    }
}
