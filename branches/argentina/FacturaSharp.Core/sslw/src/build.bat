cd ..\build\windows
cl.exe ..\..\src\sslw.c /I../../OpenSSLBuild_W32/include ../../OpenSSLBuild_W32/lib/libeay32.lib ../../OpenSSLBuild_W32/lib/ssleay32.lib /DWIN32 /LD /MD 
copy ..\..\src\sslw.h ..\include\sslw.h
cd ..\..\src
