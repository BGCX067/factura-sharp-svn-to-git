// vim: sts=4 sw=4
namespace Argentina.Access
{
    using System;
    using System.Text;
    using FacturaSharp.Core.Pkcs7;
    using System.Xml.Linq;
    //using Argentina.Stub;
    using Argentina.Persistence;

    public class LoginTicket
    {
        ulong uniqueId;
        //LoginCMSServiceWrapper client;
        string request  = null;
        string token    = null;
        string sign     = null;

        public string Token
        {
            get {
                return token;
            }
        }

        public string Sign
        {
            get {
                return sign;
            }
        }
        public LoginTicket 
            (string certfile, 
            string keyfile, 
            uint minutes, 
            bool verbose)
        {
            ulong id = Db.GetWSAUniqueId ()+1;
            string ticketRequest = this.genLoginTicketRequest 
                (id, DateTime.Now, minutes);
            if (verbose)
            {
                System.Console.WriteLine ("*** Mensaje plano:");
                System.Console.WriteLine (ticketRequest);
            }
            string cms = getPk7Sign 
                (certfile, 
                keyfile,
                ticketRequest);
            string resultXML = null;
            Db.UpdateWSAUniqueId (id);
            if (verbose)
            {
                System.Console.WriteLine ("*** Mensaje firmado:");
                System.Console.WriteLine (cms);
            }
            LoginCMSServiceWrapperProduction client = new LoginCMSServiceWrapperProduction ();
            resultXML = client.loginCms (cms);
            if (verbose)
            {
                System.Console.WriteLine ("*** Respuesta desde servidor:");
                System.Console.WriteLine (resultXML);
            }
            // parsear el resultado para así obtener token y sign.
        }

        public LoginTicket (string certfile, string keyfile, uint minutes)
        : this (certfile, keyfile, minutes, false)
        { }

        string genLoginTicketRequest 
            (ulong uniqueId,
            DateTime genTime,
            uint deltaMinutes)
        {
            XDocument document;
            document = new XDocument 
            (
                new XDeclaration ("1.0", "UTF 8", "yes"),
                new XElement
                (
                    "loginTicketRequest",
                    new XAttribute ("version", "1.0"),
                    new XElement 
                    (
                        "header",
                        // TODO: incluir source, ver como obtener Subject en formato rfc2253.
 //                       new XElement ("source",          "C=xx,ST=xx,L=xxxx xxxx,O=xxxxx,OU=xxxxx,serialNumber=CUIT xxxxxxx,CN=xxxxxx,emailAddress=xxxxxxx@xxxxxxx.xxx"),
                        new XElement ("destination",     "cn=wsaa,o=afip,c=ar,serialNumber=CUIT 33693450239"),
                        new XElement ("uniqueId",        uniqueId.ToString()),
                        new XElement ("generationTime",  formatDateTime(genTime)),
                        new XElement ("expirationTime",  formatDateTime(genTime.AddMinutes(deltaMinutes)))
                    ),
                    new XElement ("service","wsfe")
                )
            );
            return document.ToString();
        }

        string formatDateTime (DateTime dt)
        {
            TimeZone local = TimeZone.CurrentTimeZone;
            TimeSpan _offset = local.GetUtcOffset (dt);
            string offset = _offset.ToString ();
            int pos = offset.LastIndexOf (':');
            offset = offset.Remove (pos);
            return dt.ToString ("s")+offset;
        }

        string getPk7Sign (string certFile, string keyFile, string message)
        {
            Signer s = new Signer ();
            StringBuilder pkcs7 = s.pkcs7Sign (certFile, keyFile, message);
            return String.Join
                ("\n",
                Array.FindAll
                    (pkcs7.ToString ().Split ('\n'), 
                    line=> !line.Contains("-")
                    )
                );
        }
    }
}
