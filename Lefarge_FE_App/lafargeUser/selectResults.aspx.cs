using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class selectResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillBtnPnl();
        }
        private void fillBtnPnl()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var SelectedPlant = Convert.ToInt32(Session["selectedPlant"]);
                
                //create a list the holds the plants table
                var b = (from equip in conn.Equipments
                         where equip.Plant_ID == SelectedPlant
                         select equip).ToList();
                    for (int i = 0; i < b.Count; i++)
                    { 
                        HyperLink equipmentButton = new HyperLink();
                        equipmentButton.Text = b[i].Name;
                        equipmentButton.ID = b[i].Unit_Number.ToString();
                        equipmentButton.Attributes.Add("data-role", "button");
                        equipmentButton.Attributes.Add("data-inline", "true");
                        equipmentButton.Attributes.Add("rel", "external");
                        equipmentButton.NavigateUrl = "report.aspx?selectedEquipment=" + b[i].Unit_Number;
                        pnlButtons.Controls.Add(equipmentButton);
                    }
                
                var r = (from result in conn.Results
                         select result).ToList();
                var reid = (from result in conn.Results
                            select result.Equipment_ID).ToList();
                foreach (HyperLink hl in pnlButtons.Controls)
                {
                    
                    if(!reid.Contains (Convert.ToInt32(hl.ID)))
                    {
                        HyperLink buttonToHide = pnlButtons.FindControl(hl.ID) as HyperLink;
                        buttonToHide.Visible = false;
                    }
                }
            }
        }
    }
}