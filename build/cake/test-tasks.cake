#load paths.cake
#load utils.cake
#tool "nuget:?package=Microsoft.TestPlatform&version=16.4.0"

public static class TestTasks
{
    public const string TestCakeSessionApplication = "Test-Cake-Session-Application";
}

Task(TestTasks.TestCakeSessionApplication)
    .Does(() =>
{
    var vstestConsole = ResolveTool("vstest.console.exe");

    VSTest($"{Sources}/**/bin/**/*.Test.dll", new VSTestSettings(){
        ToolPath = vstestConsole
    });
});