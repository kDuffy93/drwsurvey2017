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
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("admin"))
            {
                plhPrivate.Visible = true;
                plhPublic.Visible = false;
                plhLafargeUser.Visible = false;
            }
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.IsInRole("member"))
                {
                    plhPrivate.Visible = false;
                    plhPublic.Visible = false;
                    plhLafargeUser.Visible = true;
                }
            }
            else
            {
                plhPrivate.Visible = false;
                plhPublic.Visible = true;
                plhLafargeUser.Visible = false;
            }
            
        }
    }
}