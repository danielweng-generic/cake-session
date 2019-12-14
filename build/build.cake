#load cake/build-tasks.cake
#load cake/builddata.cake
#load cake/test-tasks.cake


///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup<Builddata>(ctx =>
{
   return new Builddata()
   {
      Configuration = Argument("configuration", "Release")
   };
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Default")
.Does(() => {
   Information("Hello Cake!");
});

Task("BuildApplication")
   .IsDependentOn(BuildTasks.NugetRestoreCakeSessionApplication)
   .IsDependentOn(BuildTasks.BuildCakeSessionApplication);

Task("TestApplication")
   .IsDependentOn(TestTasks.TestCakeSessionApplication);

RunTarget(target);