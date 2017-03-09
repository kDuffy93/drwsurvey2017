using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class addPlant : System.Web.UI.Page
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
                Int32 plantID = Convert.ToInt32(Request.QueryString["Plant_ID"]);

                var p = (from plnt in conn.Plants
                    where plnt.Plant_ID == plantID
                    select plnt).FirstOrDefault();

                //populate the form from our department object
                txtPlantName.Text = p.Plant_Name;
                txtAddress.Text = p.Address;
                txtCity.Text = p.City;
                txtPhoneNum.Text = p.Phone_Num;
                txtPostalCode.Text = p.Postal_Code;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           
                //connect
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    //instantiate a new deparment object in memory
                    Plant d = new Plant();

                    //decide if updating or adding, then save
                    if (Request.QueryString.Count > 0)
                    {
                        Int32 plantID = Convert.ToInt32(Request.QueryString["plant_ID"]);

                        d = (from dep in conn.Plants
                            where dep.Plant_ID == plantID
                            select dep).FirstOrDefault();
                    }

                    //fill the properties of our object from the form inputs


                    d.Plant_Name = txtPlantName.Text;
                    d.Address = txtAddress.Text;
                    d.City = txtCity.Text;
                    d.Phone_Num = txtPhoneNum.Text;
                    d.Postal_Code = txtPostalCode.Text;

                    if (Request.QueryString.Count == 0)
                    {
                        conn.Plants.Add(d);
                    }

                    conn.SaveChanges();

                    //redirect to updated departments page
                    Response.Redirect("/lafargeUser/plants.aspx");
                }
            
        
        }
    }
}
