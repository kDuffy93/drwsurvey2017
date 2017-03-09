using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter if the count is > 0 so populate the form
                    GetPlant();
                }
            }
        }

        protected void GetPlant()
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get id from url parameter and store in a variable
                Int32 categoryID = Convert.ToInt32(Request.QueryString["Category_ID"]);

                var c = (from category in conn.Categories
                         where category.Category_ID == categoryID
                         select category).FirstOrDefault();

                //populate the form from our department object
                txtCategory.Text = c.Category1;
                }
        }


       

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //instantiate a new deparment object in memory
                Category c = new Category();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 CategoryID = Convert.ToInt32(Request.QueryString["Category_ID"]);

                    c = (from category in conn.Categories
                         where category.Category_ID == CategoryID
                         select category).FirstOrDefault();

                }

                //fill the properties of our object from the form inputs


                c.Category1 = txtCategory.Text;

                if (Request.QueryString.Count == 0)
                {
                    conn.Categories.Add(c);
                }

                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("/lafargeUser/categories.aspx");
            }

        }
    }
}
