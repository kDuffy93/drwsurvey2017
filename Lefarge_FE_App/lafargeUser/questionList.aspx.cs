using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;

namespace Lefarge_FE_App
{
    public partial class questionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                if (!IsPostBack)
                {
                    getQuestion();
                }
            }
            if (User.IsInRole("member"))
            {
                getQuestion();
                btnNewQuestion.Visible = false;
                grdQuestions.Columns[3].Visible = false;
                grdQuestions.Columns[4].Visible = false;
            }
        }
        protected void getQuestion()
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var questions = from q in conn.Questions
                           select q;

                //bind the query result to the gridview
                grdQuestions.DataSource = questions.ToList();
                grdQuestions.DataBind();

            }
        }
        protected void grdQuestions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                //get the selected DepartmentID
                Int32 QuestionID = Convert.ToInt32(grdQuestions.DataKeys[e.RowIndex].Values["Question_ID"]);

                var c = (from head in conn.Questions
                         where head.Question_ID == QuestionID
                         select head).FirstOrDefault();

                //process the delete
                conn.Questions.Remove(c);
                conn.SaveChanges();

                //update the grid
                getQuestion();
            }
        }
    }
}