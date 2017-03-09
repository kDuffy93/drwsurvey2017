using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class equipmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.IsInRole("admin") || User.IsInRole("user"))
                {


                    getEquipmentList();
                }
                if (User.IsInRole("member"))
                {
                    getEquipmentList();
                    btnNewEquipment.Visible = false;
                    grdEquipment.Columns[7].Visible = false;
                    grdEquipment.Columns[8].Visible = false;

                }
            }
        }

        protected void getEquipmentList()
        {

            //connect using our connection string from web.config and EF context class
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {

                //use link to query the Departments model
                var equip = from e in conn.Equipments
                    select e;

                //bind the query result to the gridview
                grdEquipment.DataSource = equip.ToList();
                grdEquipment.DataBind();
                
            }
        }


        protected void grdEquipment_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void grdEquipment_OnDataBound(object sender, EventArgs d)
        {
           
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {

                

                }
            }
        }
    }