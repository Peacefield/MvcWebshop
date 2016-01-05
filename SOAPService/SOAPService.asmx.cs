using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAPService
{
    /// <summary>
    /// Summary description for SOAPService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAPService : System.Web.Services.WebService
    {

        [WebMethod]
        public int GetAcceptGiro(string naam, string adres, double bedrag)
        {
            var rnd = new Random();
            var randomNmb = rnd.Next(1, 100);
            System.Diagnostics.Debug.WriteLine("Uniek getal aan het maken van: " + naam + adres + bedrag.ToString() + randomNmb.ToString());
            var uniekGetal = (naam + adres + bedrag.ToString() + randomNmb.ToString()).GetHashCode();
            if (uniekGetal < 0)
                uniekGetal = uniekGetal * -1;

            System.Diagnostics.Debug.WriteLine("GetAcceptGiro verwerken...");
            System.Threading.Thread.Sleep(3000);
            System.Diagnostics.Debug.WriteLine("uniekGetal = " + uniekGetal);
            return uniekGetal;
        }
    }
}
