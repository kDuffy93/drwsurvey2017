using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;
using System.Web.UI.HtmlControls;

using System.IO;


namespace Lefarge_FE_App
{

    public partial class survey1 :
    System.Web.UI.Page
    {
        public int selectedCategory
        {
            get;
            set;
        }


        public int selectedPlant
        {
            get;
            set;
        }

        protected void Page_Init(object sender, EventArgs e)
        {






        }
        protected void Page_Load(object sender, EventArgs e)
        {

            this.EnableViewState = true;


            buildTable();

            fillSelections();
            convertIDtoValue();

            
            input2.Attributes.Add("onclick", "document.getElementById('" + hidenPic.ClientID + "').click(); return false;"); 

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                tblSurvey.Visible = false;
                input2.Visible = false;
                hidenPic.Visible = false;
            }
            
        }
       
        protected void convertIDtoValue()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var plantID = Convert.ToInt32(txtPlant.Text);
                var catID = Convert.ToInt32(txtCategory.Text);
                var equipID = Convert.ToInt32(txtEquipment.Text);

                var plantName = (from p in conn.Plants
                                 where p.Plant_ID == plantID
                                 select p).FirstOrDefault();
                txtPlant.Text = plantName.Plant_Name;

                var catName = (from c in conn.Categories
                               where c.Category_ID == catID
                               select c).FirstOrDefault();
                txtCategory.Text = catName.Category1;

                var equipName = (from e in conn.Equipments
                                 where e.Unit_Number == equipID
                                 select e).FirstOrDefault();
                txtEquipment.Text = equipName.Name;
            }
        }
        private void fillSelections()
        {
            var plant = Session["selectedPlant"];
            var category = Session["selectedCategory"];
            var equipment = Request.QueryString["selectedEquipment"].ToString();
            // Write the modified stock picks list back to session state.
            txtCategory.Text = category.ToString();
            txtPlant.Text = plant.ToString();
            txtEquipment.Text = equipment;
        }
        protected void buildTable()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var SelectedCategory = Session["selectedCategory"].ToString();
                var neededHeadings = (from headings in conn.Headings
                                      where headings.Categories_Under.Contains(SelectedCategory)

                                      select headings.Heading1).ToList();



                for (int i = 0; i < neededHeadings.Count; i++)
                {
                    TableHeaderRow r = new TableHeaderRow();
                    var heading = neededHeadings[i];
                    TableHeaderCell c = new TableHeaderCell();
                    TableHeaderCell a1 = new TableHeaderCell();
                    

                    TableHeaderCell cellUpload = new TableHeaderCell();
                    cellUpload.Width = 280;

                    FileUpload fu = new FileUpload();
                    fu.AllowMultiple = true;
                    fu.Attributes.Add("capture", "camera");
                    fu.Attributes.Add("type", "file");
                    fu.Attributes.Add("capture", "camera");
                    cellUpload.Controls.Add(fu);

                    cellUpload.ID = "upload" + i;

                    
                    c.Text = heading;
                    c.ID = "heading" + i;
                   
                    var allIDs = (from headings in conn.Headings
                                  where headings.Categories_Under.Contains(SelectedCategory)
                                  select headings.Heading_ID).ToList();
                    var selectedID = allIDs[i];
                    // c.ID = selectedID;
                    r.Controls.Add(c);
                    r.Controls.Add(a1);
                   
                      
                    r.Controls.Add(cellUpload);
                    tblSurvey.Controls.Add(r);
                    getHeadingsQuestions(selectedID);
                    if (i + 1 == neededHeadings.Count)
                    {
                        TableHeaderRow btnRow = new TableHeaderRow();
                        TableHeaderCell btnCell = new TableHeaderCell();
                        Button btnSubmit = new Button();
                        btnSubmit.Click += new EventHandler(btnSubmit_Click);
                        btnSubmit.Text = "submit";
                        btnCell.Controls.Add(btnSubmit);



                        btnRow.Controls.Add(btnCell);
                        tblSurvey.Controls.Add(btnRow);
                    }
                }




            }
        }

        public void getHeadingsQuestions(int selectedID)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var qList = (from questions in conn.Questions
                             where questions.Headings_Under.Contains(selectedID.ToString())
                             select questions.Question1).ToList();

                for (int i = 0; i < qList.Count; i++)
                {
                    TableRow r = new TableRow();
                    var question = qList[i];
                    //ADD THE QUESTION
                    TableCell cellQuestion = new TableCell();
                    cellQuestion.Text = question;
                    cellQuestion.BackColor = Color.Lime;
                    cellQuestion.ForeColor = Color.Black;
                    
                    var allIDs = (from questions in conn.Questions
                                  where questions.Headings_Under.Contains(selectedID.ToString())
                                  select questions.Question_ID).ToList();
                    cellQuestion.ID = allIDs[i].ToString() + ("_Question_H=") + selectedID;



                    TableCell cellResponse = new TableCell();
                    cellResponse.ID = allIDs[i].ToString() + ("_response_H=") + selectedID;
                    RadioButtonList resp = new RadioButtonList();


                    resp.Attributes.Add("ID", allIDs[i].ToString() + "_response_H=" + selectedID + "rbl");
                    for (int w = 0; w < 2; w++)
                    {
                        ListItem answer = new ListItem();
                        if (w == 0)
                        {

                            answer.Text = ("Yes");
                            answer.Value = ("true");

                        }
                        else if (w == 1)
                        {
                            answer.Text = ("No");
                            answer.Value = ("false");

                        }            
                        resp.Items.Add(answer);
                    }

                    cellResponse.Controls.Add(resp);

                    TableCell cellDeficency = new TableCell();
                    TextBox txtDeficency = new TextBox();

                    txtDeficency.Width = 195;
                    txtDeficency.ID = allIDs[i] + ("_Deficency_H=") + selectedID;
                    txtDeficency.TextMode = TextBoxMode.MultiLine;
                    cellDeficency.Controls.Add(txtDeficency);

                    TableCell cellAP = new TableCell();

                    TextBox txtAP = new TextBox();

                    txtAP.Width = 195;
                    txtAP.ID = allIDs[i] + ("_ActionPlan_H=") + selectedID;
                    txtAP.TextMode = TextBoxMode.MultiLine;
                    cellAP.Controls.Add(txtAP);

                    TableCell cellUpload = new TableCell();
                     FileUpload fu = new FileUpload();
                     fu.AllowMultiple = true;
                    fu.Attributes.Add("capture", "camera");
                    fu.Attributes.Add("type", "file");
                    fu.Attributes.Add("capture", "camera");
                    cellUpload.Controls.Add(fu);

                    
                    
                   

                      
                    r.Controls.Add(cellQuestion);
                    r.Controls.Add(cellResponse);
                    r.Controls.Add(cellDeficency);
                    r.Controls.Add(cellAP);
                    r.Controls.Add(cellUpload);

                    tblSurvey.Controls.Add(r);
                }
            }
        }

        protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["sessionTable"] = tblSurvey;
            RadioButtonList button = (RadioButtonList)sender;
            string buttonId = button.Parent.ID;
            TableCell cell = button.Parent as TableCell;
            TableRow row = cell.Parent as TableRow;
            foreach (ListItem item in button.Items)
            {
                if (item.Selected)
                {
                    if (item.Value == "no")
                    {
                        TextBox txtDate = new TextBox();
                        txtDate.Text = Session["surveySubmitTime"].ToString();
                        txtDate.TextMode = TextBoxMode.Date;
                        txtDate.Attributes.Add("enableViewState", "True");
                        row.Cells[4].Controls.Add(txtDate);
                    }
                    else if (item.Value == "yes")
                    {
                        TextBox txtDate = new TextBox();
                        txtDate.Text = Session["surveySubmitTime"].ToString();
                        txtDate.TextMode = TextBoxMode.Date;
                        txtDate.Attributes.Add("enableViewState", "True");
                        row.Cells[4].Controls.Add(txtDate);
                    }
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TableCell cell = button.Parent as TableCell;
            TableRow row = cell.Parent as TableRow;
            Table table = row.Parent as Table;
            DateTime dateAndTime = Convert.ToDateTime(Session["surveySubmitTime"]);
            foreach (TableRow workingRow in table.Rows)
            {
                if (workingRow.GetType() == typeof(TableHeaderRow))
                {
                    using (DefaultConnectionEF conn = new DefaultConnectionEF())
                    {
                        string currentHeading = "";
                        int currentHeadingId = 0;
                        foreach (TableCell currentCell in workingRow.Cells)
                        {
                            if (currentCell == workingRow.Cells[0])
                            {
                                TableHeaderCell c = (TableHeaderCell)currentCell;
                                currentHeading = c.Text;
                                currentHeadingId = (from h in conn.Headings
                                                    where h.Heading1 == currentHeading
                                                    select h.Heading_ID).FirstOrDefault();
                               
                            }


                            foreach (Control control in currentCell.Controls)
                            {
                                if (control.GetType() == typeof(FileUpload))
                                {
                                    FileUpload fu = (FileUpload)control;
                                    if (fu.HasFile == true)
                                    {
                                        IList<HttpPostedFile> collection = fu.PostedFiles;
                                        int picNumber = 1;
                                        var count = fu.PostedFiles.Count();
                                        if(count >= 2)
                                        {

                                        }
                                        foreach (HttpPostedFile ia in collection)
                                        {


                                            Picture p = new Picture();
                                            var date = Session["surveySubmitTime"].ToString();
                                            string imgName = ia.FileName.ToString();
                                            int imageLength = ia.ContentLength;
                                            string imageType = ia.ContentType;

                                            var binaryImagedata = new byte[imageLength];
                                            ia.InputStream.Read(binaryImagedata, 0, imageLength);

                                            var date1 = Convert.ToDateTime(Session["surveySubmitTime"]);
                                            var date1String = date1.ToString("MM.dd.yyyy.HH.mm.ss");

                                            string imgPath = ("surveyImages/surveyPics/" + "heading-" + currentHeadingId + "eqid&" + Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString()) + "dc_" + date1String + "image" + picNumber + ".jpg");
                                            ia.SaveAs(Server.MapPath(("/admin/surveyImages/surveyPics/" + "heading-" + currentHeadingId + "eqid&" + Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString()) + "dc_" + date1String + "image" + picNumber + ".jpg")));
                                            p.URL = imgPath;
                                            p.DateSubmited = date1;
                                            p.equipment_ID = Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString());
                                            p.heading_ID = currentHeadingId;

                                            
                                            p.name = imgName;

                                            imgMain.ImageUrl = imgPath;
                                            conn.Pictures.Add(p);
                                            picNumber++;

                                        }

                                    }



                                }// fu

                            }


                        }
                        conn.SaveChanges();
                    }
                }
                else
                {
                    using (DefaultConnectionEF conn = new DefaultConnectionEF())
                    {
                        var currentHeadingID = 0;
                        var currentQuestionID = 0;


                        Result r = new Result();


                        // set date completed
                        r.Date_Completed = dateAndTime;
                        //save white equipment it is

                        r.Equipment_ID = Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString());
                        foreach (TableCell currentCell in workingRow.Cells)
                        {
                            if (currentCell == workingRow.Cells[0])
                            {
                                TableCell t = (TableCell)currentCell;
                                int indexOfUnderscore;
                                try
                                {
                                    indexOfUnderscore = t.ID.IndexOf("_");
                                    if (indexOfUnderscore == -1)
                                    {

                                    }
                                }
                                catch (NullReferenceException)
                                {
                                    continue;
                                }
                                int indexOfNumSign = t.ID.IndexOf("=") + 1;
                                // set question ID
                                r.Question_ID = Convert.ToInt32(t.ID.Substring(0, indexOfUnderscore));
                                currentQuestionID = Convert.ToInt32(t.ID.Substring(0, indexOfUnderscore));
                                //set heading id
                                r.heading_ID = Convert.ToInt32(t.ID.Substring(indexOfNumSign));
                                currentHeadingID = Convert.ToInt32(t.ID.Substring(indexOfNumSign));

                            }
                            foreach (Control control in currentCell.Controls)
                            {
                                if (control.GetType() == typeof(RadioButtonList))
                                {
                                    RadioButtonList rbl = (RadioButtonList)control;
                                    if (rbl.SelectedValue == "true")
                                    {
                                        r.Response = true;
                                    }
                                    else if (rbl.SelectedValue == "false")
                                    {
                                        r.Response = false;
                                    }
                                } // check control to see if its a rbl
                                if (control.GetType() == typeof(TextBox))
                                {
                                    TextBox txt = (TextBox)control;
                                    if (txt.ID == (r.Question_ID + "_Deficency_H=" + r.heading_ID))
                                    {
                                        r.deficiency_defect = txt.Text;
                                    } // checks if txt box is a defect
                                    else if (txt.ID == (r.Question_ID + "_ActionPlan_H=" + r.heading_ID))
                                    {
                                        r.Action_plan = txt.Text;
                                    } //checks if txtbox is action plan
                                }//checks for txtbox

                                if (control.GetType() == typeof(FileUpload))
                                {
                                    FileUpload fu = (FileUpload)control;
                                    if (fu.HasFile == true)
                                    {
                                        IList<HttpPostedFile> collection = fu.PostedFiles;
                                        int picNumber = 1;
                                        var count = fu.PostedFiles.Count();
                                        if (count >= 2)
                                        {

                                        }
                                        foreach (HttpPostedFile ia in collection)
                                        {
                                            Picture p = new Picture();
                                            var date = Session["surveySubmitTime"].ToString();
                                            string imgName = ia.FileName.ToString();
                                            int imageLength = ia.ContentLength;
                                            string imageType = ia.ContentType;

                                            var binaryImagedata = new byte[imageLength];
                                            ia.InputStream.Read(binaryImagedata, 0, imageLength);
                                            var date1 = Convert.ToDateTime(Session["surveySubmitTime"]);
                                            var date1String = date1.ToString("MM.dd.yyyy.HH.mm.ss");

                                            string imgPath = ("surveyImages/surveyPics/" + "qid~" + r.Question_ID + "heading-" + r.heading_ID + "eqid&" + r.Equipment_ID + "dc_" + date1String + "image" + picNumber + ".jpg");

                                            ia.SaveAs(Server.MapPath(("/admin/surveyImages/surveyPics/" + "qid~" + r.Question_ID + "heading-" + r.heading_ID + "eqid&" + r.Equipment_ID + "dc_" + date1String + "image" + picNumber + ".jpg")));

                                            p.URL = imgPath;
                                            p.DateSubmited = date1;
                                            p.equipment_ID = Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString());
                                            p.heading_ID = currentHeadingID;
                                            p.question_ID = currentQuestionID;
                                           
                                            p.name = imgName;
                                            imgMain.ImageUrl = imgPath;

                                            conn.Pictures.Add(p);

                                            picNumber++;

                                        }


                                    }
                                }// if file upload = true

                            } //foreach control
                           
                        } // checks to see if workign row is not a header row
                        conn.Results.Add(r);
                        conn.SaveChanges();
                    } //default conn
                } //for each table row
                btnNewSurvey.Visible = true;
            }
        }
        protected void btnNewSurvey_Click(object sender, EventArgs e)
        {
            Response.Redirect("startSurvey.aspx");
        }

        protected void btnTimeout_Click(object sender, EventArgs e)
        {
            
        }




        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            var date = DateTime.Now.AddMinutes(-240).ToString();
            
            Session["surveySubmitTime"] = date;
            if (fuMain.HasFile)
            {
                using (DefaultConnectionEF conn = new DefaultConnectionEF())
                {
                    IList<HttpPostedFile> collection = fuMain.PostedFiles;

                    foreach (HttpPostedFile ia in collection)
                    {
                        Picture p = new Picture();
                        
                        string imgName = ia.FileName.ToString();
                        int imageLength = ia.ContentLength;
                        string imageType = ia.ContentType;

                        var binaryImagedata = new byte[imageLength];
                        ia.InputStream.Read(binaryImagedata, 0, imageLength);

                        var date1 = Convert.ToDateTime(Session["surveySubmitTime"]);
                        var date1String = date1.ToString("MM.dd.yyyy.HH.mm.ss");

                        string imgPath = ("surveyImages/mainPics/" +
                            "eqid&" + Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString()) + "dc_" + date1String + "image" +  ".jpg");
                        
                       ia.SaveAs(Server.MapPath(("/admin/surveyImages/mainPics/" +
                             "eqid&" + Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString()) + "dc_" + date1String + "image" + ".jpg")));
                       
                        p.URL= imgPath;
                        p.DateSubmited = date1;
                        p.equipment_ID = Convert.ToInt32(Request.QueryString["selectedEquipment"].ToString());

                       
                        p.name = imgName;




                        imgMain.ImageUrl = imgPath;
                        conn.Pictures.Add(p);



                    }
                   
                    imgMain.Visible = true;
                    btnUpload.Visible = false;
                    fuMain.Visible = false;

                    tblSurvey.Visible = true;

                    input2.Visible = true;
                    hidenPic.Visible = true;
                    conn.SaveChanges();
                    
                       
                }
            }
        }



        

       
    } // partial class close
}//namespace close 