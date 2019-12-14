public static class BuildTasks
{
    public const string BuildCakeSessionApplication = "Build-Cake-Session-Application";
}

Task(BuildTasks.BuildCakeSessionApplication)
    .Does(() =>
{
    MSBuild("../src/CakeSessionApplication/CakeSessionApplication.sln");
});