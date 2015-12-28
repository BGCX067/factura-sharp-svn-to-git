/* 
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com
 * Licencia: MIT/X11.
 */
#include <openssl/x509.h> 
#include <openssl/pkcs7.h>
#include <string.h>

#include "include/ssl_wrapper.h"

#ifdef WIN32
#define DLLEXPORT __declspec(dllexport)
#endif

char * _pkcs7_sign (X509 * cert, EVP_PKEY * pkey, char * message)
{
    PKCS7       * scms          = NULL;
    BIO         * message_bio   = NULL;
    BIO         * signed_message= NULL;

    char * bio_data_ptr         = NULL;
    char * smessage             = NULL;
    long   bio_data_len         = 0;

    message_bio = BIO_new_mem_buf (message, strlen(message));
    if (message_bio == NULL)
    {
        goto finally;
    }
    SSL_library_init();
    //scms = PKCS7_sign(cert, pkey, NULL, message_bio, PKCS7_DETACHED);
    scms = PKCS7_sign(cert, pkey, NULL, message_bio, 0);
    if (scms == NULL)
    {
        /* long err= ERR_get_error ();
        char * err_txt = ERR_error_string (err);
        printf ("Error firmando pkcs7 (%i): %s\n",(int)err,((err_txt==NULL)?" ":err_txt));*/
        goto finally;
    }

    signed_message = BIO_new (BIO_s_mem());
    if (signed_message == NULL)
    {
        /*printf ("Error creando buffer.\n");*/
        goto finally;
    }
    if (PEM_write_bio_PKCS7 (signed_message, scms) <= 0)
    {
        /*printf ("Error transportando a PEM.\n");*/
        goto finally;
    }
    bio_data_len =BIO_get_mem_data (signed_message, &bio_data_ptr);
    smessage = (char *)malloc (bio_data_len+1);
    if (smessage == NULL)
    {
        /*perror ("malloc ()");*/
        goto finally;
    }
    memcpy (smessage, bio_data_ptr, bio_data_len);
    smessage[bio_data_len]='\0';
    finally:
        if (message_bio != NULL)
            BIO_free(message_bio);
        if (signed_message != NULL)
            BIO_free(signed_message);
        if (cert != NULL)
            X509_free(cert);
        if (pkey != NULL)
            EVP_PKEY_free(pkey);
        return smessage;
}

#ifdef WIN32
DLLEXPORT
#endif
char * pkcs7_sign_ff
    (char * certfile,
    char * keyfile,
    char * message)
{
    X509        * cert          = NULL;
    EVP_PKEY    * pkey          = NULL;
    char        * signed_cms    = NULL;

    cert = load_file (certfile);
    if (cert == NULL)
        goto finally;
    pkey = load_key_file (keyfile);
    if (pkey == NULL)
        goto finally;
    signed_cms = _pkcs7_sign (cert, pkey, message);
    finally:
        if (cert != NULL)
            X509_free (cert);
        if (pkey != NULL)
            EVP_PKEY_free (pkey);
        return  signed_cms;
}
/*
 * Firma un mensaje segun pkcs7.
 * Parametros:
 * cert_data: datos del certificado.
 * key_data: datos del private key.
 * message: el mensaje a firmar.
 * cert_data_len: longitud (en bytes) de los datos del certificado.
 * key_data_len: longitud (en bytes) de los datos del private key.
 *
*/
#ifdef WIN32
DLLEXPORT
#endif
char * pkcs7_sign
    (unsigned char * cert_data,
    unsigned char * key_data,
    char * message,
    int cert_data_len,
    int key_data_len)

{
    X509        * cert          = NULL;
    EVP_PKEY    * pkey          = NULL;
    char        * signed_cms    = NULL;
    
    cert = load (cert_data, cert_data_len);
    if (cert == NULL)
        goto finally;
    //pkey = load_key (key_data, key_data_len);
    pkey = load_key (key_data, key_data_len);
    if (pkey == NULL)
        goto finally;
    signed_cms = _pkcs7_sign (cert, pkey, message);
    finally:
        if (cert != NULL)
            X509_free (cert);
        if (pkey != NULL)
            EVP_PKEY_free (pkey);
        return  signed_cms;
}

/* vim: sw=4 sts=4 nu et ai*/
