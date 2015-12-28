echo off
echo "Construyendo sslw.dll"
cd src
call .\build.bat
cd ..
echo "Construyendo tests"
cd tests
call build.bat
cd ..
