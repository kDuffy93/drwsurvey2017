using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page isn't posted back, check the url for an id to see know add or edit
            fillDropDown();
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    //we have a url parameter if the count is > 0 so populate the form
                    getQuestion();

                }

            }

        }

        protected void getQuestion()
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get id from url parameter and store in a variable
                Int32 QuestionID = Convert.ToInt32(Request.QueryString["Question_ID"]);

                var c = (from head in conn.Questions
                         where head.Question_ID == QuestionID
                         select head).FirstOrDefault();

                //populate the form from our department object
                txtQuestion.Text = c.Question1;

                var headingsUnder = c.Headings_Under.ToString();

                var allHeadings = (from cat in conn.Headings

                                     select cat.Heading_ID).ToList();
                var headLength = allHeadings.Count();
                int lastID = allHeadings[headLength - 1];



                for (int i = 0; i < lastID; i++)
                {
                   foreach(ListItem h in chklstHeadings.Items)
                   {
                       if (headingsUnder.Contains((i + 1).ToString()))
                       {
                           if( h.Value==((i+1)+","))
                           {
                               h.Selected=true;
                           }
                       }
                   }
                }
            }
        }

        protected void fillDropDown()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var c = (from cat in conn.Headings

                         select cat).ToList();

                for (int t = 0; t < c.Count; t++)
                {
                    ListItem a = new ListItem();
                    a.Text = c[t].Heading1;
                    a.Value = c[t].Heading_ID + (",");
                    
                    chklstHeadings.Items.Add(a);
                }
            }
        }





        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //instantiate a new deparment object in memory
                Question q = new Question();

                //decide if updating or adding, then save
                if (Request.QueryString.Count > 0)
                {
                    Int32 QuestionID = Convert.ToInt32(Request.QueryString["Question_ID"]);

                    var c = (from head in conn.Questions
                             where head.Question_ID == QuestionID
                             select head).FirstOrDefault();
                    q = c;

                }

                //fill the properties of our object from the form inputs



                // Create the list to store.
                string selectedHeadingValues = null;
                // Loop through each item.
                foreach (ListItem item in chklstHeadings.Items)
                {
                    if (item.Selected)
                    {
                        // If the item is selected, add the value to the list.
                        selectedHeadingValues = selectedHeadingValues + item.Value;
                    }
                    else
                    {

                    }

                }
                q.Question1 = txtQuestion.Text;
                q.Headings_Under = selectedHeadingValues.ToString();
                q.Category_ID = 1;

                if (Request.QueryString.Count == 0)
                {
                    conn.Questions.Add(q);
                }

                conn.SaveChanges();

                //redirect to updated departments page
                Response.Redirect("/lafargeUser/questionList.aspx");
            }
        }
    }
}
