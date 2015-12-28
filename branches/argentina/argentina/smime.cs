namespace Smime
{
	using System;
	using System.IO;
	using System.Text;
	using System.Security.Cryptography.Pkcs;
	using System.Security.Cryptography.X509Certificates;

	class Signer
	{
		public static byte[] Sign(String pkcs12Path, string password, string message)
		{
			X509Certificate2 cert;
			if (password == null)
			    cert= new X509Certificate2 (pkcs12Path);
			else
			    cert= new X509Certificate2 (pkcs12Path, password);
			ContentInfo content = new ContentInfo (System.Text.Encoding.Default.GetBytes (message));
			SignedCms signedCms = new SignedCms(content, false);
			CmsSigner signer = new CmsSigner(cert);
            		signer.IncludeOption = X509IncludeOption.EndCertOnly;
			signedCms.ComputeSignature (signer);
			return signedCms.Encode ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine ("Uso smime cert [password] msg");
				return;
			}
			string passwd = null;
			string msg    = null;
			if (args.Length == 3)
			{
			    passwd = "";
			    msg    = args[2];
			}
			else
			    msg = args[1];
			System.Console.WriteLine (args[0]);
			byte[] signedData = Signer.Sign (args[0],passwd, msg);
		}

	}
}
