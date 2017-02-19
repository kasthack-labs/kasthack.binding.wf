cd src
%systemroot%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
cd ..
NuGet pack kasthack.binding.wf.nuspec
Nuget Push kasthack.binding.wf.*.nupkg -Source https://www.nuget.org/api/v2/package
del kasthack.binding.wf.*.nupkg
pause