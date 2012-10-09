pushd C:\Program Files\Microsoft Visual Studio 11.0\VC"
call "bin\vcvars32.bat"
popd

"C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\devenv" SifawFramework.sln /clean
pause

