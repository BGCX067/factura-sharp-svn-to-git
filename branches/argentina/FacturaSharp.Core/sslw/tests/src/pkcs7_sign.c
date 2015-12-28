/* 
 * Autor: Jonatan Anauati.
 * Email: barakawins@gmail.com
 * Licencia: MIT/X11.
 */

/* 
 * Contiene una aplicacion de prueba de la libreria sslw.
 */
#include <string.h>
#include <sslw.h>

int main (int argc, char ** argv)
{
    char * pk7sm =  NULL;
    if (argc != 4)
    {
        printf ("Modo de uso: %s certfile keyfile message\n", argv[0]);
        exit (1);
    }
    pk7sm = pkcs7_sign_ff (argv[1],argv[2],argv[3]);
    if (pk7sm != NULL)
        printf ("%s",pk7sm);
    else
    {
        printf ("Error\n");
        exit (1);
    }
    exit (0);
}

/* vim: sw=4 sts=4 nu et ai*/
