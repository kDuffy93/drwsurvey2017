using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Lefarge_FE_App.Models;
using System.Net.Mail;
using Lefarge_FE_App.logic;

namespace Lefarge_FE_App
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
 
        }
      
        protected void Application_Error(object sender, EventArgs e)
        {
        

          
          //  HttpException objError = Server.GetLastError() as HttpException;
             
             
          //  if (objError.GetHttpCode() == 404)
          //  {
          //      Server.Transfer("/404.aspx");
          //      return;
          //  }

          ///*  //email the error
          //  MailMessage objMail = new MailMessage();

          //  objMail.Subject = "BrechinFES ERROR";
          //  objMail.Body = "Type: " + objError.GetType() + "<br />Source: " + objError.Source + "<br />Message: " + objError.Message + "<br />StackTrace: " + objError.StackTrace;
          //  objMail.From = new MailAddress("support@lafargefes.mail");
          //  objMail.To.Add("kyleduffy83@gmail.com");
          //  objMail.IsBodyHtml = true;

          //  SmtpClient objClient = new SmtpClient();
          //  objClient.Send(objMail);
          // * */

          //  Server.ClearError();
          //  Server.Transfer("/error.aspx");
        }
       
    }
}