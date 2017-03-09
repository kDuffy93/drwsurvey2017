using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lefarge_FE_App.Models;
using System.Data;

namespace Lefarge_FE_App.lafargeUser
{
    public partial class tempImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            var Hid = Convert.ToInt32(Request.QueryString["Hid"].ToString());
            var eqID = Convert.ToInt32(Request.QueryString["eqid"].ToString());
         var dc = Convert.ToDateTime(Request.QueryString["dc"].ToString());
            if (!String.IsNullOrEmpty(Request.QueryString["qid"]))
            {
                var Qid = Convert.ToInt32(Request.QueryString["qid"].ToString());
                loadImages(Hid, eqID, dc, Qid);
            }
            if (String.IsNullOrEmpty(Request.QueryString["qid"]))
            {
                loadImages(Hid, eqID, dc);
            }
        }
        public void loadImages(int hid,int eqid, DateTime dc)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var reqImageURLs = (from p in conn.Pictures
                                    where p.equipment_ID == eqid && p.heading_ID == hid && p.DateSubmited == dc
                                    select p).ToList();
                DLTempImage.DataSource = reqImageURLs;
                DLTempImage.DataBind();
            }
        }
        public void loadImages(int hid, int eqid, DateTime dc, int qid)
        {
            using (DefaultConnectionEF conn = new DefaultConnectionEF())
            {
                var reqImageURLs = (from p in conn.Pictures
                                    where p.equipment_ID == eqid && p.heading_ID == hid && p.DateSubmited == dc && p.question_ID == qid
                                    select p).ToList();
                var count = reqImageURLs.Count();
                var url = "/admin/surveyImages/surveyPics/qid~"+ qid + "heading-"+ hid + "eqid&" + eqid + "dc_"+ dc.ToString("MM.dd.yyyy.hh.mm.ss") + "image1"  +".jpg";
                DLTempImage.DataSource = reqImageURLs;
              
             
                                    DLTempImage.DataBind();
                
            }
        }

       

        protected void DLTempImage_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Image lastImageBound = (Image)e.Item.FindControl("imageContainer");
            Label lblqID =(Label)e.Item.FindControl("qID");
            Label lblhID = (Label)e.Item.FindControl("hID");
          //  int qID = Convert.ToInt32(lblqID.Text);
           // int hID = Convert.ToInt32(lblhID.Text);
//Console.Write("qid: " + qID + "  hID: " + hID);
        }

        protected void imageContainer_DataBinding(object sender, EventArgs e)
        {
            Console.Write("databound");
        }

        

       
        protected void txtHeadingAndQuestion (int qID, int hID)
        {

        }
    }
}