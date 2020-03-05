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

                    string recievedMailID = mail.ReceivedByName.Split(' ').Last();
                    recievedMailID = recievedMailID.Substring(1, recievedMailID.Length - 2);

                    if (recievedMailID.ToLower() == filterSenderMailID.ToLower())
                    {
                        mailServiceObj.InsertMailBody(mail.SenderEmailAddress, mail.ReceivedByName, mail.Subject, mail.Body);
                    }
                }
            }
            catch (Exception ex)
            {
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
