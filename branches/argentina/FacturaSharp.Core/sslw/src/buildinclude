/* 
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com
 * Licencia: MIT/X11.
 */

/* sslw.h.
 * Especifica la interfaz ofrecida por sslw.so o sslw.dll.
 */

#ifndef __SSLW_INCLUDED
#define __SSLW_INCLUDED

/*
 * pkcs7_sign.
 * Finalidad: Firma un mensaje segun la especificacion pkcs7.
 * Parametros:
 * -cert_data: datos del certificado.
 * -key_data: datos del private key.
 * -message: el mensaje a firmar.
 * -cert_data_len: longitud (en bytes) de los datos del certificado.
 * -key_data_len: longitud (en bytes) de los datos del private key.
 * Retorno: Un string conteniendo el contenido firmado.
 */
char * pkcs7_sign
    (unsigned char  *   cert_data,
     unsigned char  *   key_data,
     char           *   message,
     int                cert_data_len,
     int                key_data_len);

/*
 * pkcs7_sign_ff.
 * Finalidad: Firma un mensaje segun la especificacion pkcs7.
 * Parametros:
 * -certfile: path del archivo del certificado.
 * -keyfile: path del archivo del private key.
 * -message: el mensaje a firmar.
 * Retorno: Un string conteniendo el contenido firmado.
 */
char * pkcs7_sign_ff (char * certfile, char * keyfile, char * message);
#endif

/* vim: sw=4 sts=4 nu et ai*/
