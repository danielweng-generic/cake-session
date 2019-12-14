#load paths.cake

public static class BuildTasks
{
    public const string BuildCakeSessionApplication = "Build-Cake-Session-Application";

    public const string NugetRestoreCakeSessionApplication = "Nuget-Restore-Cake-Session-Application";
}

Task(BuildTasks.BuildCakeSessionApplication)
    .Does(() =>
{
    MSBuild(CakeSessionApplicationSolution);
});

Task(BuildTasks.NugetRestoreCakeSessionApplication)
    .Does(() =>
{
    NuGetRestore(CakeSessionApplicationSolution);
});