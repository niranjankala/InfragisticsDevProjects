using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfragistcsDev.ASPNET.MVC.Models
{
    public class DAQlmLicenseInfo
    {
        public string ActivationKey { get; set; }
        public string ProductName { get; set; }
        public DateTime? SubscriptionExpiryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string ComputerID { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserData1 { get; set; }
        public string ReceiptID { get; set; }
        public string LicenseType { get; set; }
        public string State { get; set; }
    }

}