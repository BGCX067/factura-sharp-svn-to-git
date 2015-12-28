namespace Argentina.Access
{
    using Argentina.Stub.LoginCMSService;

    public abstract class LoginCMSServiceWrapper 
    {
        string url = null;
        LoginCMSService service = null;

        public LoginCMSServiceWrapper (string url)
        { 
            this.url = url;
        }

        public string loginCms(string in0)
        {
            service = new LoginCMSService ();
            service.Url = this.url;
            return service.loginCms (in0);
        }
    }

    public class LoginCMSServiceWrapperProduction
    : LoginCMSServiceWrapper
    {
        static string _Url = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
        public LoginCMSServiceWrapperProduction ()
        : base (_Url)
        { }
        public LoginCMSServiceWrapperProduction (string url)
        : base (url)
        {}
    }

    public class LoginCMSServiceWrapperTesting
        : LoginCMSServiceWrapper
    {
        static string _Url = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
        public LoginCMSServiceWrapperTesting ()
        : base (_Url)
        { }
        public LoginCMSServiceWrapperTesting (string url)
        : base (url)
        {}
    }
}
