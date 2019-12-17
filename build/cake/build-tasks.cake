#load paths.cake
#load builddata.cake
#addin nuget:?package=Cake.FileHelpers&version=3.2.1

public static class BuildTasks
{
    public const string BuildCakeSessionApplication = "Build-Cake-Session-Application";

    public const string SetVersionCakeSessionApplication = "Set-Version-Cake-Session-Application";

    public const string NugetRestoreCakeSessionApplication = "Nuget-Restore-Cake-Session-Application";
}

Task(BuildTasks.BuildCakeSessionApplication)
    .Does<Builddata>(builddata =>
{
    Information($"Building {CakeSessionApplicationSolution.GetFilename()}");
    Information($"Configuration {builddata.Configuration}");

    var buildsettings = GetBaseBuildSettings()
        .SetConfiguration(builddata.Configuration);

    MSBuild(CakeSessionApplicationSolution, buildsettings);
});

Task(BuildTasks.NugetRestoreCakeSessionApplication)
    .Does(() =>
{
    NuGetRestore(CakeSessionApplicationSolution);
});


Task(BuildTasks.SetVersionCakeSessionApplication)
    .Does<Builddata>(builddata =>
{
    ReplaceRegexInFiles("../**/*.csproj", @"<AssemblyVersion>[\s\S]*?</AssemblyVersion>", $"<AssemblyVersion>{builddata.VersionNumber}</AssemblyVersion>");
});


private MSBuildSettings GetBaseBuildSettings()
{
    var buildsettings = new MSBuildSettings()
        .SetVerbosity(Verbosity.Minimal);

    return buildsettings;
}