#load cake/build-tasks.cake
#load cake/builddata.cake
#load cake/test-tasks.cake
#load cake/config-tasks.cake


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
      Configuration = Argument("configuration", "Release"),
      ConfigInteger = Argument("configinteger", 0),
      ConfigString = Argument("configstring", "String"),
      VersionNumber = Argument("versionnumber", "1.0.0.0")
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
   .IsDependentOn(BuildTasks.SetVersionCakeSessionApplication)
   .IsDependentOn(BuildTasks.NugetRestoreCakeSessionApplication)
   .IsDependentOn(BuildTasks.BuildCakeSessionApplication);

Task("TestApplication")
   .IsDependentOn(TestTasks.TestCakeSessionApplication);

Task("ReleaseApplication")
   .IsDependentOn(ConfigTasks.SetConfigValues);


Task("Error-Abort-Build")
   .Does(() => {
      throw new Exception("Läuft nicht");
   });

Task("Error-Abort-Build-Continue")
   .ContinueOnError()
   .Does(() => {
      throw new Exception("Läuft nicht");
   });


Task("Error-Abort-Build-Handle")
   .Does(() => {
      throw new Exception("Läuft nicht");
   })
   .OnError(ex => {
      Information($"Exception: {ex.Message} was thrown!!!");
   });

// erst zum schluss wird gefailed. Alle Tasks werden aber durchlaufen.
Task("Error-Abort-Build-Defer")
   .Does(() => {
      Information("Failing task 1");
      throw new Exception("Läuft nicht");
   })
   .Does(() => {
      Information("Failing task 2");
      throw new Exception("Dat auch nicht!!");
   })
   .DeferOnError();


RunTarget(target);