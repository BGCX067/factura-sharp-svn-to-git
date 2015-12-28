/* 
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com
 * Licencia: MIT/X11.
 */

#include <openssl/x509.h> 

X509 * load (unsigned char * data, int len)
{
    X509 * cert; 
    BIO * bio;
    cert = d2i_X509 (NULL, (const unsigned char **)&data, len);
    if (cert != NULL)
        goto success;
    bio = BIO_new_mem_buf((char*)data , len);
    cert = PEM_read_bio_X509 (bio,NULL,NULL,NULL);
    success:
        BIO_free (bio);
        return cert;
}

X509 * load_file (char * fname)
{
    FILE * fp   = NULL;
    X509 * cert = NULL;

    fp = fopen ((const char *)fname, "r");
    if (fp == NULL)
    {
        perror ("fopen()");
        return NULL;
    }
    cert = d2i_X509_fp(fp, NULL);
    if (cert != NULL)
        goto success;
    if (cert == NULL)
    {
        rewind (fp);
        cert = PEM_read_X509 (fp, NULL, NULL, NULL);
    }
    success:
        fclose (fp);
        return cert;
}

EVP_PKEY * load_key (unsigned char * data, int len)
{
    EVP_PKEY * pkey = NULL; 
    BIO * bio       = NULL;

    pkey = d2i_AutoPrivateKey (NULL, (const unsigned char **)&data, len);
    if (pkey != NULL)
        goto success;
    bio = BIO_new_mem_buf((char*)data , len);
    pkey = PEM_read_bio_PrivateKey(bio, NULL, NULL, NULL);
    success:
        BIO_free (bio);
        return pkey;
}

EVP_PKEY * load_key_file (char * fname)
{
    FILE * fp   = NULL; 
    EVP_PKEY * pkey = NULL;

    fp = fopen ((const char *)fname, "r");
    if (fp == NULL)
    {
        perror ("fopen()");
        return NULL;
    }
    pkey = d2i_PrivateKey_fp (fp, NULL);
    if (pkey != NULL)
        goto success;
    if (pkey == NULL)
    {
        rewind (fp);
        pkey = PEM_read_PrivateKey (fp, NULL, NULL, NULL);
    }
    success:
        fclose (fp);
        return pkey;
}

/* vim: sw=4 sts=4 nu et ai*/
