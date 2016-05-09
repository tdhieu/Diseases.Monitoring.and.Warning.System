using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Localization;
using System.Globalization;
using System.Net.Mail;
namespace Adicom.Web.Code
{
    public class WebUtils
    {
        public static string GetLanguageValue(string viValue, string enValue)
        {
            return ResourceManager.CurrentCultureName.Equals("en-US") ? enValue : viValue;
        }
        public static string FormatNumber(float number)
        {
            if (number == 0)
                return "0";
            else
            {
                if (number - Math.Truncate(number) != 0)
                {
                    CultureInfo c = new CultureInfo("en-US");
                    IFormatProvider format = c.NumberFormat;
                    return number.ToString("#,###.00", format);
                }
                else
                {

                    return number.ToString("#,###");
                }
            }
        }

        public static void sendmail(string from, string emailAddress, string subject, string body)
        {
            // System.Web.Mail.SmtpMail.SmtpServer is obsolete in 2.0

            // System.Net.Mail.SmtpClient is the alternate class for this in 2.0

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                MailAddress fromAddress = new MailAddress(from);

                //Default port will be 25

                smtpClient.Port = 25;

                //From address will be given as a MailAddress Object

                message.From = fromAddress;

                // To address collection of MailAddress

                message.To.Add(emailAddress);
                message.Subject = subject;

                // CC and BCC optional

                // MailAddressCollection class is used to send the email to various users


                // You can specify Address directly as string


                //Body can be Html or text format

                //Specify true if it  is html message

                message.IsBodyHtml = true;

                // Message body content

                message.Body = body;

                // Send SMTP mail

                smtpClient.Send(message);


            }
            catch (Exception ex)
            {
                
            }
        }
        public static string saveImages(FileUpload fileUpload, string folderName)
        {
            string strRootFolder = HttpContext.Current.Request.PhysicalApplicationPath;
            strRootFolder = strRootFolder.Substring(0, strRootFolder.LastIndexOf(@"\"));
            strRootFolder += "\\" + folderName + "\\";
            string imageFolder = folderName + DateTime.Now.ToString("yyyyddMM");
            strRootFolder += imageFolder + "\\";
            if (!System.IO.Directory.Exists(strRootFolder))
                System.IO.Directory.CreateDirectory(strRootFolder);
            string StrFileName =
                      fileUpload.PostedFile.FileName.Substring(fileUpload.PostedFile.FileName.LastIndexOf("\\") + 1);
            string StrFileType = fileUpload.PostedFile.ContentType;
            int IntFileSize = fileUpload.PostedFile.ContentLength;
            if (IntFileSize <= 0)
            {
                return "";
            }
            else
            {

                fileUpload.PostedFile.SaveAs(strRootFolder +
                                        StrFileName);
                
                return folderName + "/" + imageFolder + "/" + StrFileName;
            }
        }
        public static void deleImage(string name)
        {
            string[] arry = name.Split('/');
            string Folder = HttpContext.Current.Request.PhysicalApplicationPath + arry[0]+ "\\"+ arry[1]+"\\";
           // System.IO.Directory.Delete(Folder,true);

        }
    }
}
