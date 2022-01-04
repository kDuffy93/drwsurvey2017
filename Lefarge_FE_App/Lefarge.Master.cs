using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;

namespace Lefarge_FE_App
{
    public partial class Lefarge : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("user"))
            {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
                plhLafargeUser.Visible = false;
                plhUnprivlidges.Visible = false;
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("admin"))
            {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
                plhUnprivlidges.Visible = false;
                plhLafargeUser.Visible = false;
            }
            
                else if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("member"))
                {
                    plhPrivate.Visible = false;
                    plhPublic.Visible = false;
                plhUnprivlidges.Visible = false;
                plhLafargeUser.Visible = true;
                }
            else if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                    plhPrivate.Visible = false;
                 plhPublic.Visible = true;
                   plhUnprivlidges.Visible = false;
                  plhLafargeUser.Visible = false;
              
            }

            else
            {
                plhUnprivlidges.Visible = true;
                plhPrivate.Visible = false;
                plhPublic.Visible = false;
                plhLafargeUser.Visible = false;
            }
            
        }
    }
}