cd build
cl.exe ..\src\pkcs7_sign.c ..\..\build\windows\sslw.lib /I..\..\build\include 
copy ..\..\build\windows\sslw.dll .
copy ..\..\OpenSSLBuild_W32\bin\ssleay32.dll .
copy ..\..\OpenSSLBuild_W32\bin\libeay32.dll .
cd ..
