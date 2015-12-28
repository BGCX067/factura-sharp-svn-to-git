/*
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com.
 * Licencia: MIT/X11
 */

namespace FacturaSharp.Core.Pkcs7
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text; 

    interface ISigner
    {
        StringBuilder pkcs7Sign
            (string certfile, 
            string keyfile, 
            string message);
    }

    class UnixSigner : ISigner
    {
        [DllImport ("./sslw.so")]
        private extern static  IntPtr pkcs7_sign_ff
            (string certfile, 
            string keyfile, 
            string message);

        [DllImport ("libc")]
        private static extern void free (IntPtr ptr);

        public StringBuilder pkcs7Sign
            (string certfile, 
            string keyfile, 
            string message)
        {
	    
            IntPtr ret = pkcs7_sign_ff (certfile, keyfile, message);
            string signedData = Marshal.PtrToStringAnsi (ret);
            StringBuilder sb = new StringBuilder (signedData);
            free (ret);
            return sb;
        }
        
    }

    class WindowsSigner : ISigner
    {
    	#if PLATFORM_MONO
        [DllImport ("./sslw.so")]
        private extern static  IntPtr pkcs7_sign_ff
            (string certfile, 
            string keyfile, 
            string message);

        [DllImport ("libc")]
        private static extern void free (IntPtr ptr);

        public StringBuilder pkcs7Sign
            (string certfile, 
            string keyfile, 
            string message)
        {
	    
            IntPtr ret = pkcs7_sign_ff (certfile, keyfile, message);
            string signedData = Marshal.PtrToStringAnsi (ret);
            StringBuilder sb = new StringBuilder (signedData);
            free (ret);
            return sb;
        }
	#elif PLATFORM_DOTNET
        /* codigo para punto net. Sin pinvokes.*/
	#endif
        
    }
    
    public class Signer
    {
        public StringBuilder pkcs7Sign
            (string certfile, 
            string keyfile, 
            string message)
        {
            ISigner signer;
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                signer = new UnixSigner();
            else
                signer = new WindowsSigner ();
            return signer.pkcs7Sign (certfile, keyfile, message); 
        }
    }

    #if TESTME
    public class MainClass
    {
        public static void Main (string[] args)
        {
            ISigner signer = new Signer ();
	    // la siguiente demuestra que es capaz de leer archivos de certficados y 
	    // claves privadas en multiples formatos (pem o der).
            StringBuilder sb = signer.pkcs7Sign ("cert.der","key.pem","mensaje de prueba");
            System.Console.Write(sb.ToString ());
        }
    }
    #endif
}
/* vim: sw=4 sts=4 hls=is et nu ai nowrap */
