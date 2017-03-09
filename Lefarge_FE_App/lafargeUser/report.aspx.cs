using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;
using System.Data;

namespace Lefarge_FE_App.admin
{
    public partial class report : System.Web.UI.Page
    {
        DateTime currentlySelectedDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 EquipmentID = Convert.ToInt32(Request.QueryString["selectedEquipment"]);
            
            if (!IsPostBack)
            {
               
                txtEqID.Text = EquipmentID.ToString();
                txtEqUn.Text = EquipmentID.ToString();
                convertIDtoValue(EquipmentID);
                selectDate(EquipmentID);
            }


            if (IsPostBack)
            {

                var SelectedIndex = ddlDates.SelectedIndex;
                selectDate(EquipmentID, SelectedIndex);
            }



        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           
                Session["selectedDate"] = Convert.ToDateTime(ddlDates.SelectedValue);
                Session["selectedDateIndex"] = ddlDates.SelectedIndex;
                imgMain.Visible = true;
                imgMain.ImageUrl = "/admin/surveyImages/mainPics/eqid&" + Request.QueryString["selectedEquipment"].ToString() + "dc_" + (Convert.ToDateTime(ddlDates.SelectedValue)).ToString("MM.dd.yyyy.HH.mm.ss") + "image.jpg";
            

        }
        protected void selectDate(int EquipmentID)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var possibleDates = (from r in conn.Results
                                     where r.Equipment_ID == EquipmentID
                                     select r.Date_Completed).Distinct().ToList();
                currentlySelectedDate = possibleDates[0];
                getReport(EquipmentID, possibleDates[0]);
               


                ddlDates.DataSource = possibleDates;
                ddlDates.DataBind();


            }
        }
        protected void selectDate(int EquipmentID, int index)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var possibleDates = (from r in conn.Results
                                     where r.Equipment_ID == EquipmentID
                                     select r.Date_Completed).Distinct().ToList();
                currentlySelectedDate = possibleDates[index];
                getReport(EquipmentID, possibleDates[index]);


                ddlDates.SelectedIndex = index;


            }
        }
        protected void convertIDtoValue(int EquipmentID)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var equipName = (from q in conn.Equipments
                                 where q.Unit_Number == EquipmentID
                                 select q).FirstOrDefault();
                txtEqID.Text = equipName.Name;

            }
        }
        protected void getReport(int EquipmentID, DateTime selectedDate)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //use link to query the Departments model
                var result = from r in conn.Results
                             where r.Equipment_ID == EquipmentID & r.Date_Completed == selectedDate 
                             select r;
                //bind the query result to the gridview
                grdResults.DataSource = result.ToList();
                grdResults.DataBind();
            }
        }


        protected void grdResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow dr = e.Row as GridViewRow;


                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    Int32 qID = Convert.ToInt32(dr.Cells[0].Text);

                    var tempQuestion = (from q in conn.Questions
                                        where q.Question_ID == qID
                                        select q).FirstOrDefault();

                    dr.Cells[0].Text = tempQuestion.Question1;

                    var hID = Convert.ToInt32(dr.Cells[4].Text);
                    var tempDate = currentlySelectedDate;
                    var tempHeading = (from h in conn.Headings
                                       where h.Heading_ID == hID
                                       select h).FirstOrDefault();
                    dr.Cells[4].Text = tempHeading.Heading1.ToString();
                    //Button tempButton = new Button();
                    //tempButton.ID = "btnQid=" + qID + "Hid:" + hID;
                    //tempButton.Text = tempHeading.Heading1;
                    //tempButton.Attributes.Add("data-hid", hID.ToString());
                    //tempButton.Attributes.Add("data-date", ddlDates.SelectedValue.ToString());
                    //tempButton.Attributes.Add("data-eqid", txtEqID.Text.ToString());
                    //tempButton.Attributes.Add("onclick", "document.getElementById('" + Button2.ClientID + "').click(); return false;");
                    //tempButton.Click += new EventHandler(header_click);


                    Button tempButton2 = new Button();
                    tempButton2.ID = "btnQid=" + qID + "Hid:" + hID;
                    tempButton2.Text = "View Heading Images";

                    HyperLink hyperlink1 = new HyperLink();
                    hyperlink1.Attributes.Add("data-role", "button");
                    hyperlink1.Attributes.Add("data-inline", "true");
                    hyperlink1.Attributes.Add("rel", "external");
                    hyperlink1.ID = "hlQid=" + qID + "Hid=" + hID + "2";
                    hyperlink1.Text = "View Images";
                    hyperlink1.NavigateUrl = "~/lafargeUser/tempImages.aspx?qid=" + qID + "&Hid=" + hID + "&dc=" + tempDate + "&eqid=" + Convert.ToInt32(Request.QueryString["selectedEquipment"]);

                    HyperLink hyperlink2 = new HyperLink();
                    hyperlink2.Attributes.Add("data-role", "button");
                    hyperlink2.Attributes.Add("data-inline", "true");
                    hyperlink2.Attributes.Add("rel", "external");
                    hyperlink2.ID = "hlQid=" + qID + "Hid=" + hID;
                    hyperlink2.Text = "View Heading Images";
                    hyperlink2.NavigateUrl = "~/lafargeUser/tempImages.aspx?Hid=" + hID + "&dc=" + tempDate + "&eqid=" + Convert.ToInt32(Request.QueryString["selectedEquipment"]);

                    //tempButton2.Attributes.Add("onclick", "document.getElementById('" + Button2.ClientID + "').click(); return false;");





                    dr.Cells[6].Controls.Add(hyperlink2);
                    dr.Cells[7].Controls.Add(hyperlink1);

                  
                    
                    var response = dr.Cells[1].Text;

                    if (response == "True")
                    {
                        dr.Cells[1].Text = "yes";

                    }
                    else if (response == "False")
                    {
                        dr.Cells[1].Text = "no";
                    }

                }
            }
        }

        private void header_click(object sender, EventArgs e)
        {
            var b = sender as Button;
            string hid = b.Attributes["data-hid"].ToString();
            string date = b.Attributes["data-date"].ToString();
            string eqid = b.Attributes["data-eqid"].ToString();
            string qid = b.Attributes["data-qid"].ToString();
            Response.Redirect("default.aspx");
        }

        private void TempButton2_Command(object sender, CommandEventArgs e)
        {
            var b = sender as Button;
            string hid = b.Attributes["data-hid"].ToString();
            string date = b.Attributes["data-date"].ToString();
            string eqid = b.Attributes["data-eqid"].ToString();
            string qid = b.Attributes["data-qid"].ToString();
            
        }

        protected void ddlDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            Session["selectedDate"] = Convert.ToDateTime(ddl.SelectedValue);
            Session["selectedDateIndex"] = ddl.SelectedIndex;

            imgMain.ImageUrl = "/admin/surveyImages/mainPics/eqid&" + Request.QueryString["selectedEquipment"].ToString() + "dc_" + (Convert.ToDateTime(ddlDates.SelectedValue)).ToString("MM.dd.yyyy.HH.mm.ss") + "image.jpg";
            
           
        }

        protected void ddlDates_DataBinding(object sender, EventArgs e)
        {
            var b = sender as DropDownList;
            // var firstDate = b.SelectedValue;

            /* foreach (DataRow dr in grdResults.Rows)
              {
                 if(!(dr[5].Text.Contains(firstDate)))
                 {
                     grdResults.Rows.Remove(dr);
                 }
               
              }*/
        }
        

        protected void grdResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="viewImages")
            {
                var b = sender as Button;
                string hid = b.Attributes["data-hid"].ToString();
                string date = b.Attributes["data-date"].ToString();
                string eqid = b.Attributes["data-eqid"].ToString();
                string qid = b.Attributes["data-qid"].ToString();
                Response.Redirect("default.aspx");
            }
        }

        protected void dlPhotos_ItemCreated(object sender, DataListItemEventArgs e)
        {

        }

        protected void dlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }
    }
}




