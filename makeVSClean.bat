pushd C:\Archivos de Programa\Microsoft Visual Studio 10.0\VC"
call "bin\vcvars32.bat"
popd

"C:\Archivos de Programa\Microsoft Visual Studio 10.0\Common7\IDE\devenv" SifawFramework.sln /clean
pause

