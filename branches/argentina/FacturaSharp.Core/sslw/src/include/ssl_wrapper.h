/* 
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com
 * Licencia: MIT/X11.
 */

#ifndef SSL_WRAPPER_INCLUDED
#define SSL_WRAPPER_INCLUDED 

#include <openssl/x509.h> 
#include "ssl_wrapper.c"

X509 * load (unsigned char * data, int len);
X509 * load_file (char * fname);

EVP_PKEY * load_key (unsigned char * data, int len);
EVP_PKEY * load_key_file (char * fname);

#endif

/* vim: sw=4 sts=4 nu et ai*/
