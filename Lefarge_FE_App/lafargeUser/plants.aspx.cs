using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.ModelBinding;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class listPlants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                if (!IsPostBack)
                {
                    GetPlants();
                }
            }
            if(User.IsInRole("member"))
            {
                GetPlants();
                btnNewPlant.Visible = false;
                grdPlants.Columns[6].Visible = false;
                grdPlants.Columns[7].Visible = false;
            }
        }
          protected void GetPlants()
        {

            //connect using our connection string from web.config and EF context class
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
               
                //use link to query the Departments model
                var plnts = from d in conn.Plants
                           select d;

                //bind the query result to the gridview
                grdPlants.DataSource = plnts.ToList();
                grdPlants.DataBind();
            }
        }
          protected void grdPlants_RowDeleting(object sender, GridViewDeleteEventArgs e)
          {
              //connect
              using (DefaultConnectionEF conn = new DefaultConnectionEF())
              {
                  //get the selected DepartmentID
                  Int32 PlantID = Convert.ToInt32(grdPlants.DataKeys[e.RowIndex].Values["Plant_ID"]);

                  var d = (from dep in conn.Plants
                           where dep.Plant_ID == PlantID
                           select dep).FirstOrDefault();

                  //process the delete
                  conn.Plants.Remove(d);
                  conn.SaveChanges();

                  //update the grid
                  GetPlants();
              }
          }

    }
}



   

      
