del *.nupkg

REM Use dotnet for packaging now
REM NuGet.exe pack MDM.Generator/MDM.Generator.csproj -Properties Configuration=Release -IncludeReferencedProjects
dotnet pack .\MDM.Generator\MDM.Generator.csproj -c Release -o .

forfiles /m *.nupkg /c "cmd /c NuGet.exe push @FILE -Source https://www.nuget.org/api/v2/package"
