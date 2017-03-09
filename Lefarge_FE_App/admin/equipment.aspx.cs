using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class equipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter if the count is > 0 so populate the form
                    getEquipmentList();
                }
                
                fillDropDowns();
            }
        }

        protected void getEquipmentList()
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get id from url parameter and store in a variable
                Int32 EquipmentID = Convert.ToInt32(Request.QueryString["Equipment_ID"]);

                var e = (from equip in conn.Equipments
                         where equip.Equipment_ID == EquipmentID
                         select equip).FirstOrDefault();

                //populate the form from our department object
                txtName.Text = e.Name;
                txtBeltType.Text = e.Belt_Type;
                txtNumOfBelts.Text = e.Num_Of_Belts.ToString();
                txtUnitNumber.Text = e.Unit_Number.ToString();
                txtDescription1.Text = e.Description1;
                ddlPlant.SelectedIndex = ((e.Plant_ID) - 1);
                ddlCategory.SelectedIndex = ((e.Category_ID)-1);

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

                //create a list the holds the plants table
                var c = (from cat in conn.Categories
                         select cat).ToList();
                //set the datasource to the created list and bind it to the dropdown
                ddlCategory.DataSource = c;
                ddlCategory.DataBind();



            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //instantiate a new deparment object in memory
                Equipment a = new Equipment();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 EquipmentID = Convert.ToInt32(Request.QueryString["Equipment_ID"]);

                    a = (from equip in conn.Equipments
                         where equip.Equipment_ID == EquipmentID
                         select equip).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs


                a.Name = txtName.Text;
                a.Unit_Number = Convert.ToInt32(txtUnitNumber.Text);
                a.Belt_Type = txtBeltType.Text;
                a.Num_Of_Belts = Convert.ToInt32(txtNumOfBelts.Text);
                a.Description1 = txtDescription1.Text;
                a.Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                a.Plant_ID = Convert.ToInt32(ddlPlant.SelectedValue);

                if (Request.QueryString.Count == 0)
                {
                    conn.Equipments.Add(a);
                }

                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("/lafargeUser/equipmentList.aspx");
            }


        }
    }
}
