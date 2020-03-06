using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ServiceModel;

namespace Claysys.AppForms.OutlookAddIn
{



    public partial class ThisAddIn
    {

        Outlook.NameSpace outlookNameSpace;
        Outlook.MAPIFolder inbox;
        Outlook.Items items;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            outlookNameSpace = this.Application.GetNamespace("MAPI");
            inbox = outlookNameSpace.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.
                    OlDefaultFolders.olFolderInbox);

            items = inbox.Items;
            items.ItemAdd +=
                new Outlook.ItemsEvents_ItemAddEventHandler(items_ItemAdd);
        }



        void items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            try
            {
                MailServiceReference.MailServiceClient mailServiceObj = new MailServiceReference.MailServiceClient();
                if (Item != null)
                {
                    string filterSenderMailID = mailServiceObj.GetTargetMailId();

                    const string PR_SMTP_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
                    Outlook.Recipients recips = mail.Recipients;
                    foreach (Outlook.Recipient recip in recips)
                    {
                        Outlook.PropertyAccessor pa = recip.PropertyAccessor;
                        string smtpAddress =
                            pa.GetProperty(PR_SMTP_ADDRESS).ToString();
                        if (smtpAddress.ToLower() == filterSenderMailID.ToLower())
                        {
                            mailServiceObj.InsertMailBody(mail.SenderEmailAddress, mail.ReceivedByName, mail.Subject, mail.Body);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
                appLog.Source = "Claysys UCU Outlook plugging";
                appLog.WriteEntry("Exception : " + ex);
                throw ex;
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
