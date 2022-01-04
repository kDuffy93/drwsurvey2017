using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lefarge_FE_App
{
    public partial class _default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtWelcome.Text = "Welcome " + HttpContext.Current.User.Identity.Name;
            if (HttpContext.Current.User.IsInRole("admin") || HttpContext.Current.User.IsInRole("user"))
            {
                plhMember.Visible = false;
                plhUser.Visible = true;
                txtWelcome.Text = "Welcome " + HttpContext.Current.User.Identity.Name.ToString();
            }
            else if (HttpContext.Current.User.IsInRole("member"))
            {
                plhMember.Visible = true;
                plhUser.Visible = false;
                txtWelcomeMember.Text = "Welcome " + HttpContext.Current.User.Identity.Name.ToString();
            }
            else if (!HttpContext.Current.User.IsInRole("admin") || !HttpContext.Current.User.IsInRole("user")|| !HttpContext.Current.User.IsInRole("member"))
            {
                plhMember.Visible = false;
                plhUser.Visible = false;
                txtWelcomeMember.Text = "somethings gone wrong, your account's privledges have been revoked or you're not signed in. Try heading to the login page and try again or contact IT support";
            }
        }
    }
}