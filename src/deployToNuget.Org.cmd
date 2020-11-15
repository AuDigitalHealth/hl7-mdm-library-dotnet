del *.nupkg

nuget restore
msbuild 
msbuild MedicalDocumentManagement.sln /p:Configuration=Release

NuGet.exe pack MDM.Generator/MDM.Generator.csproj -Properties Configuration=Release -IncludeReferencedProjects

pause

forfiles /m *.nupkg /c "cmd /c NuGet.exe push @FILE -Source https://www.nuget.org/api/v2/package"
